/*
    This file is part of Imgur Snipping Tool.

    Imgur Snipping Tool is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Imgur Snipping Tool is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Imgur Snipping Tool.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Xml;

namespace snippingtool
{
    public class Imgur
    {
        public struct ProgressData {
            public int max_value;
            public int value;
        }

        public struct UploadResults {
            public string original;
            public string imgur_page;
            public string delete_page;
        }

        public delegate void uploadProgressUpdate(ProgressData data);
        private uploadProgressUpdate _uploadprogressUpdateProperty;
        public uploadProgressUpdate UploadProgressUpdateProperty
        {
            get { return _uploadprogressUpdateProperty; }
            set { _uploadprogressUpdateProperty = value; }
        }

        public delegate void uploadComplete(UploadResults results);
        private uploadComplete _uploadCompleteProperty;
        public uploadComplete UploadCompleteProperty
        {
            get { return _uploadCompleteProperty; }
            set { _uploadCompleteProperty = value; }
        }

        private const int MAX_URI_LENGTH = 32766;
        private const string POST_URL = "http://api.imgur.com/2/upload";
        private const int UPDATE_CHUNKS = 1024;

        private string apiKey;

        public Imgur(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public UploadResults PostImage(Image image, ImageFormat format)
        {
            MemoryStream imageDataStream = new MemoryStream();
            image.Save(imageDataStream, format);

            // get the raw bytes
            byte[] imageDataBytes;
            imageDataBytes = imageDataStream.ToArray();

            // construct the post string
            string base64img = System.Convert.ToBase64String(imageDataBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < base64img.Length; i += MAX_URI_LENGTH)
            {
                sb.Append(Uri.EscapeDataString(base64img.Substring(i, Math.Min(MAX_URI_LENGTH, base64img.Length - i))));
            }

            string uploadRequestString = "image=" + sb.ToString() + "&key=" + apiKey;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(POST_URL);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ServicePoint.Expect100Continue = false;

            Stream reqStream = webRequest.GetRequestStream();
            byte[] reqBuffer = Encoding.UTF8.GetBytes(uploadRequestString);

            // send the bytes in chunks so we can check the progress
            int overflow = reqBuffer.Length % UPDATE_CHUNKS;
            ProgressData progress = new ProgressData();
            progress.max_value = reqBuffer.Length;
            progress.value = 0;
            int size = UPDATE_CHUNKS;
            for (int i = 0; i < reqBuffer.Length; i += UPDATE_CHUNKS)
            {
                if (i + UPDATE_CHUNKS > reqBuffer.Length-1)
                    size = overflow;
                reqStream.Write(reqBuffer, i, size);

                // update the progress
                progress.value = i + size;
                if (_uploadprogressUpdateProperty != null)
                    _uploadprogressUpdateProperty(progress);
            }
            reqStream.Close();


            WebResponse response = webRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader responseReader = new StreamReader(responseStream);

            string responseString = responseReader.ReadToEnd();


            UploadResults results = ParseResponse(responseString);
            if (_uploadCompleteProperty != null)
                _uploadCompleteProperty(results);

            return results;
        }

        private UploadResults ParseResponse(string xml)
        {
            UploadResults results = new UploadResults();
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                string lastNodeName = "";
                reader.ReadToFollowing("links");
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        lastNodeName = reader.Name;
                    }

                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        switch (lastNodeName)
                        {
                            case "original":
                                results.original = reader.Value;
                                break;

                            case "imgur_page":
                                results.imgur_page = reader.Value;
                                continue;

                            case "delete_page":
                                results.delete_page = reader.Value;
                                continue;

                            default:
                                break;
                        }

                        lastNodeName = "";
                    }
                }

                return results;
            }
        }
    }
}
