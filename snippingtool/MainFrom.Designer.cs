namespace snippingtool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.copied_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.delete_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.original_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imgur_textbox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 80);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(532, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(546, 132);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(538, 106);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Snip";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(532, 77);
            this.button1.TabIndex = 3;
            this.button1.Text = "Rectangle Snip";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.copied_label);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.delete_textbox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.original_textbox);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.imgur_textbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(538, 106);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "URLs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // copied_label
            // 
            this.copied_label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.copied_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.copied_label.Location = new System.Drawing.Point(3, 90);
            this.copied_label.Name = "copied_label";
            this.copied_label.Size = new System.Drawing.Size(532, 13);
            this.copied_label.TabIndex = 6;
            this.copied_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Delete";
            this.label3.DoubleClick += new System.EventHandler(this.OpenBrowser_click);
            // 
            // delete_textbox
            // 
            this.delete_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.delete_textbox.Location = new System.Drawing.Point(50, 61);
            this.delete_textbox.Name = "delete_textbox";
            this.delete_textbox.ReadOnly = true;
            this.delete_textbox.Size = new System.Drawing.Size(480, 20);
            this.delete_textbox.TabIndex = 4;
            this.delete_textbox.DoubleClick += new System.EventHandler(this.Copy_click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Original";
            this.label2.DoubleClick += new System.EventHandler(this.OpenBrowser_click);
            // 
            // original_textbox
            // 
            this.original_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.original_textbox.Location = new System.Drawing.Point(50, 35);
            this.original_textbox.Name = "original_textbox";
            this.original_textbox.ReadOnly = true;
            this.original_textbox.Size = new System.Drawing.Size(480, 20);
            this.original_textbox.TabIndex = 2;
            this.original_textbox.DoubleClick += new System.EventHandler(this.Copy_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Imgur";
            this.label1.DoubleClick += new System.EventHandler(this.OpenBrowser_click);
            // 
            // imgur_textbox
            // 
            this.imgur_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgur_textbox.Location = new System.Drawing.Point(50, 9);
            this.imgur_textbox.Name = "imgur_textbox";
            this.imgur_textbox.ReadOnly = true;
            this.imgur_textbox.Size = new System.Drawing.Size(480, 20);
            this.imgur_textbox.TabIndex = 0;
            this.imgur_textbox.DoubleClick += new System.EventHandler(this.Copy_click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 132);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Imgur Snipping Tool";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox imgur_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox original_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox delete_textbox;
        private System.Windows.Forms.Label copied_label;
    }
}

