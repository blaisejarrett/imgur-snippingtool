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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Net;
using System.Xml;
using System.Diagnostics;

namespace snippingtool
{


    public partial class MainForm : Form
    {
        private const string API_KEY = "830bececb56919ddd399ee27d45ffec4";
        private Imgur imgur;
        private const string COPIED_CLIPBOARD = "{0} link was copied to your clipboard";

        public void uploadProgressUpdateThreadSafe(snippingtool.Imgur.ProgressData data)
        {
            progressBar1.Maximum = data.max_value;
            progressBar1.Value = data.value;
        }

        public void uploadCompleteThreadSafe(snippingtool.Imgur.UploadResults results)
        {
            imgur_textbox.Text = results.imgur_page;
            original_textbox.Text = results.original;
            delete_textbox.Text = results.delete_page;

            Clipboard.SetText(results.imgur_page);
            copied_label.Text = String.Format(COPIED_CLIPBOARD, "Imgur");
            tabControl1.SelectedTab = tabPage2;
            ((Control)this.tabPage2).Enabled = true;
        }

        /// <summary>
        /// Gets called from another thread when the upload has a progress update
        /// </summary>
        /// <param name="data"></param>
        public void uploadProgressUpdate(snippingtool.Imgur.ProgressData data)
        {
            this.Invoke(new snippingtool.Imgur.uploadProgressUpdate(uploadProgressUpdateThreadSafe), new object[] { data });
        }

        /// <summary>
        /// Gets called from another thread when the upload has completed
        /// </summary>
        /// <param name="data"></param>
        public void uploadComplete(snippingtool.Imgur.UploadResults results)
        {
            this.Invoke(new snippingtool.Imgur.uploadComplete(uploadCompleteThreadSafe), new object[] { results });
        }

        public MainForm()
        {
            InitializeComponent();
            ((Control)this.tabPage2).Enabled = false;

            imgur = new Imgur(API_KEY);
            imgur.UploadProgressUpdateProperty = uploadProgressUpdate;
            imgur.UploadCompleteProperty = uploadComplete;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                this.Opacity = .0; // Hides dialog window while selecting 
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var bmp = SnippingTool.Snip();
            this.Opacity = 1; // Shows dialog window while uploading
            if (bmp != null)
            {
                try
                {
                    imgur.PostImage(bmp, ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void OpenBrowser_click(object sender, EventArgs e)
        {
            Label box = (Label)sender;
            // load up the browser link

            switch (box.Text)
            { 
                case "Imgur":
                    Process.Start(imgur_textbox.Text);
                    break;
                case "Original":
                    Process.Start(original_textbox.Text);
                    break;
                case "Delete":
                    Process.Start(delete_textbox.Text);
                    break;
                default:
                    break;
            }
        }

        private void Copy_click(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            Clipboard.SetText(box.Text);
            
            switch (box.Name)
            { 
                case "imgur_textbox":
                    copied_label.Text = String.Format(COPIED_CLIPBOARD, "Imgur");
                    break;
                case "original_textbox":
                    copied_label.Text = String.Format(COPIED_CLIPBOARD, "Original");
                    break;
                case "delete_textbox":
                    copied_label.Text = String.Format(COPIED_CLIPBOARD, "Delete");
                    break;

                default:
                    break;
            }
        }
    }
}
