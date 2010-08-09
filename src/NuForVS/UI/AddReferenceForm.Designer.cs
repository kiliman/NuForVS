namespace NuForVS.UI
{
    partial class AddReferenceForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddReferenceForm));
            this.panelList = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.searchGems = new System.Windows.Forms.TextBox();
            this.searchResultsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.gemList = new System.Windows.Forms.ListView();
            this.gemInstalled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gemVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelAbout = new System.Windows.Forms.Panel();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.linkWebSite = new System.Windows.Forms.LinkLabel();
            this.labelLicense = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.view3 = new System.Windows.Forms.Label();
            this.view2 = new System.Windows.Forms.Label();
            this.view1 = new System.Windows.Forms.Label();
            this.view0 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.consoleOutput = new System.Windows.Forms.TextBox();
            this.installGem = new System.Windows.Forms.Button();
            this.gemToInstall = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.configText = new System.Windows.Forms.TextBox();
            this.saveConfig = new System.Windows.Forms.Button();
            this.cancelConfig = new System.Windows.Forms.Button();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelList
            // 
            this.panelList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelList.Controls.Add(this.pictureBox1);
            this.panelList.Controls.Add(this.label3);
            this.panelList.Controls.Add(this.comboBox1);
            this.panelList.Controls.Add(this.richTextBox1);
            this.panelList.Controls.Add(this.searchGems);
            this.panelList.Controls.Add(this.searchResultsList);
            this.panelList.Controls.Add(this.gemList);
            this.panelList.Location = new System.Drawing.Point(145, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(639, 303);
            this.panelList.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(610, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sort by:";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Default",
            "Name Ascending",
            "Name Descending",
            "Path Ascending",
            "Path Descending",
            "Version Ascending",
            "Version Descending"});
            this.comboBox1.Location = new System.Drawing.Point(311, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Default";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(457, 34);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(175, 269);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // searchGems
            // 
            this.searchGems.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.searchGems.ForeColor = System.Drawing.SystemColors.ControlText;
            this.searchGems.Location = new System.Drawing.Point(458, 5);
            this.searchGems.Name = "searchGems";
            this.searchGems.Size = new System.Drawing.Size(169, 23);
            this.searchGems.TabIndex = 1;
            this.searchGems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchGems_KeyUp);
            // 
            // searchResultsList
            // 
            this.searchResultsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchResultsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchResultsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.searchResultsList.FullRowSelect = true;
            this.searchResultsList.Location = new System.Drawing.Point(29, 54);
            this.searchResultsList.Name = "searchResultsList";
            this.searchResultsList.Size = new System.Drawing.Size(455, 274);
            this.searchResultsList.SmallImageList = this.images;
            this.searchResultsList.TabIndex = 0;
            this.searchResultsList.UseCompatibleStateImageBehavior = false;
            this.searchResultsList.View = System.Windows.Forms.View.Details;
            this.searchResultsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gemList_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 23;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Version";
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Remote";
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "checkmark.bmp");
            // 
            // gemList
            // 
            this.gemList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gemList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gemInstalled,
            this.gemName,
            this.gemVersion});
            this.gemList.FullRowSelect = true;
            this.gemList.Location = new System.Drawing.Point(0, 34);
            this.gemList.Name = "gemList";
            this.gemList.Size = new System.Drawing.Size(455, 274);
            this.gemList.SmallImageList = this.images;
            this.gemList.TabIndex = 0;
            this.gemList.UseCompatibleStateImageBehavior = false;
            this.gemList.View = System.Windows.Forms.View.Details;
            this.gemList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gemList_MouseDoubleClick);
            // 
            // gemInstalled
            // 
            this.gemInstalled.Text = "";
            this.gemInstalled.Width = 23;
            // 
            // gemName
            // 
            this.gemName.Text = "Name";
            this.gemName.Width = 200;
            // 
            // gemVersion
            // 
            this.gemVersion.Text = "Version";
            this.gemVersion.Width = 200;
            // 
            // panelAbout
            // 
            this.panelAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAbout.BackColor = System.Drawing.Color.White;
            this.panelAbout.Controls.Add(this.labelAuthor);
            this.panelAbout.Controls.Add(this.linkWebSite);
            this.panelAbout.Controls.Add(this.labelLicense);
            this.panelAbout.Controls.Add(this.labelCopyright);
            this.panelAbout.Controls.Add(this.labelVersion);
            this.panelAbout.Controls.Add(this.labelTitle);
            this.panelAbout.Controls.Add(this.pictureBox3);
            this.panelAbout.Location = new System.Drawing.Point(397, 351);
            this.panelAbout.Name = "panelAbout";
            this.panelAbout.Size = new System.Drawing.Size(603, 300);
            this.panelAbout.TabIndex = 11;
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(92, 91);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(231, 15);
            this.labelAuthor.TabIndex = 5;
            this.labelAuthor.Text = "Author: Michael Carter (Twitter: @kiliman)";
            // 
            // linkWebSite
            // 
            this.linkWebSite.AutoSize = true;
            this.linkWebSite.Location = new System.Drawing.Point(92, 135);
            this.linkWebSite.Name = "linkWebSite";
            this.linkWebSite.Size = new System.Drawing.Size(228, 15);
            this.linkWebSite.TabIndex = 4;
            this.linkWebSite.TabStop = true;
            this.linkWebSite.Text = "http://wiki.github.com/kiliman/NuForVS/";
            this.linkWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWebSite_LinkClicked);
            // 
            // labelLicense
            // 
            this.labelLicense.AutoSize = true;
            this.labelLicense.Location = new System.Drawing.Point(92, 113);
            this.labelLicense.Name = "labelLicense";
            this.labelLicense.Size = new System.Drawing.Size(193, 15);
            this.labelLicense.TabIndex = 3;
            this.labelLicense.Text = "Licensed under Apache 2.0 License.";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(92, 69);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(287, 15);
            this.labelCopyright.TabIndex = 2;
            this.labelCopyright.Text = "Copyright © 2010 SystemEx.NET. All Rights Reserved.";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(92, 47);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(76, 15);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Version: 0.1.0";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(86, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(247, 32);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Nu for Visual Studio";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(16, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.view3);
            this.panelMenu.Controls.Add(this.view2);
            this.panelMenu.Controls.Add(this.view1);
            this.panelMenu.Controls.Add(this.view0);
            this.panelMenu.Controls.Add(this.pictureBox2);
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(140, 303);
            this.panelMenu.TabIndex = 10;
            // 
            // view3
            // 
            this.view3.AutoSize = true;
            this.view3.Location = new System.Drawing.Point(25, 106);
            this.view3.Name = "view3";
            this.view3.Size = new System.Drawing.Size(40, 15);
            this.view3.TabIndex = 9;
            this.view3.Tag = "About";
            this.view3.Text = "About";
            this.view3.Click += new System.EventHandler(this.changeView_Click);
            // 
            // view2
            // 
            this.view2.AutoSize = true;
            this.view2.Location = new System.Drawing.Point(25, 82);
            this.view2.Name = "view2";
            this.view2.Size = new System.Drawing.Size(49, 15);
            this.view2.TabIndex = 9;
            this.view2.Tag = "Options";
            this.view2.Text = "Options";
            this.view2.Click += new System.EventHandler(this.changeView_Click);
            // 
            // view1
            // 
            this.view1.AutoSize = true;
            this.view1.Location = new System.Drawing.Point(25, 58);
            this.view1.Name = "view1";
            this.view1.Size = new System.Drawing.Size(82, 15);
            this.view1.TabIndex = 9;
            this.view1.Tag = "SearchResults";
            this.view1.Text = "Search Results";
            this.view1.Click += new System.EventHandler(this.changeView_Click);
            // 
            // view0
            // 
            this.view0.AutoSize = true;
            this.view0.Location = new System.Drawing.Point(26, 34);
            this.view0.Name = "view0";
            this.view0.Size = new System.Drawing.Size(88, 15);
            this.view0.TabIndex = 9;
            this.view0.Tag = "AvailableGems";
            this.view0.Text = "Available Gems";
            this.view0.Click += new System.EventHandler(this.changeView_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 24);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // consoleOutput
            // 
            this.consoleOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(16)))), ((int)(((byte)(0)))));
            this.consoleOutput.Font = new System.Drawing.Font("Consolas", 8F);
            this.consoleOutput.ForeColor = System.Drawing.Color.Lime;
            this.consoleOutput.Location = new System.Drawing.Point(0, 337);
            this.consoleOutput.Multiline = true;
            this.consoleOutput.Name = "consoleOutput";
            this.consoleOutput.ReadOnly = true;
            this.consoleOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleOutput.Size = new System.Drawing.Size(784, 108);
            this.consoleOutput.TabIndex = 1;
            // 
            // installGem
            // 
            this.installGem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.installGem.Location = new System.Drawing.Point(685, 306);
            this.installGem.Name = "installGem";
            this.installGem.Size = new System.Drawing.Size(87, 27);
            this.installGem.TabIndex = 2;
            this.installGem.Text = "Install Gem";
            this.installGem.UseVisualStyleBackColor = true;
            this.installGem.Click += new System.EventHandler(this.installGem_Click);
            // 
            // gemToInstall
            // 
            this.gemToInstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gemToInstall.Location = new System.Drawing.Point(110, 309);
            this.gemToInstall.Name = "gemToInstall";
            this.gemToInstall.Size = new System.Drawing.Size(569, 23);
            this.gemToInstall.TabIndex = 3;
            this.gemToInstall.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gemToInstall_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Gem:";
            // 
            // panelOptions
            // 
            this.panelOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(86)))));
            this.panelOptions.Controls.Add(this.cancelConfig);
            this.panelOptions.Controls.Add(this.saveConfig);
            this.panelOptions.Controls.Add(this.configText);
            this.panelOptions.Location = new System.Drawing.Point(46, 351);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(280, 266);
            this.panelOptions.TabIndex = 11;
            // 
            // configText
            // 
            this.configText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.configText.Location = new System.Drawing.Point(0, 0);
            this.configText.Multiline = true;
            this.configText.Name = "configText";
            this.configText.Size = new System.Drawing.Size(280, 234);
            this.configText.TabIndex = 0;
            // 
            // saveConfig
            // 
            this.saveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveConfig.Location = new System.Drawing.Point(4, 240);
            this.saveConfig.Name = "saveConfig";
            this.saveConfig.Size = new System.Drawing.Size(75, 23);
            this.saveConfig.TabIndex = 1;
            this.saveConfig.Text = "Save";
            this.saveConfig.UseVisualStyleBackColor = true;
            this.saveConfig.Click += new System.EventHandler(this.saveConfig_Click);
            // 
            // cancelConfig
            // 
            this.cancelConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelConfig.Location = new System.Drawing.Point(85, 240);
            this.cancelConfig.Name = "cancelConfig";
            this.cancelConfig.Size = new System.Drawing.Size(75, 23);
            this.cancelConfig.TabIndex = 1;
            this.cancelConfig.Text = "Cancel";
            this.cancelConfig.UseVisualStyleBackColor = true;
            this.cancelConfig.Click += new System.EventHandler(this.cancelConfig_Click);
            // 
            // AddReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(199)))), ((int)(((byte)(216)))));
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.panelAbout);
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gemToInstall);
            this.Controls.Add(this.installGem);
            this.Controls.Add(this.consoleOutput);
            this.Controls.Add(this.panelList);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "AddReferenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Nu Reference...";
            this.panelList.ResumeLayout(false);
            this.panelList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelAbout.ResumeLayout(false);
            this.panelAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.ListView gemList;
        private System.Windows.Forms.ColumnHeader gemName;
        private System.Windows.Forms.ColumnHeader gemVersion;
        private System.Windows.Forms.TextBox consoleOutput;
        private System.Windows.Forms.Button installGem;
        private System.Windows.Forms.TextBox gemToInstall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader gemInstalled;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox searchGems;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label view3;
        private System.Windows.Forms.Label view2;
        private System.Windows.Forms.Label view1;
        private System.Windows.Forms.Label view0;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Panel panelAbout;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ListView searchResultsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.LinkLabel linkWebSite;
        private System.Windows.Forms.Label labelLicense;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Button cancelConfig;
        private System.Windows.Forms.Button saveConfig;
        private System.Windows.Forms.TextBox configText;
    }
}