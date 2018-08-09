namespace Backup
{
    partial class Backup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Backup));
            this.lbLocations = new System.Windows.Forms.ListBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbDir = new System.Windows.Forms.TextBox();
            this.btDirAdd = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btDirBrowse = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btFileBrowse = new System.Windows.Forms.Button();
            this.btFileAdd = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbSave = new System.Windows.Forms.GroupBox();
            this.tbTarget = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.lbDate = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.lbTarget = new System.Windows.Forms.Label();
            this.btTarget = new System.Windows.Forms.Button();
            this.folderBrowserDialogTarget = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLocations
            // 
            this.lbLocations.FormattingEnabled = true;
            this.lbLocations.Location = new System.Drawing.Point(12, 12);
            this.lbLocations.Name = "lbLocations";
            this.lbLocations.Size = new System.Drawing.Size(745, 329);
            this.lbLocations.TabIndex = 0;
            this.lbLocations.SelectedIndexChanged += new System.EventHandler(this.lbLocations_SelectedIndexChanged);
            // 
            // btDelete
            // 
            this.btDelete.Enabled = false;
            this.btDelete.Location = new System.Drawing.Point(683, 359);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 1;
            this.btDelete.Text = "Verwijderen";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.UserProfile;
            // 
            // tbDir
            // 
            this.tbDir.Location = new System.Drawing.Point(6, 6);
            this.tbDir.Name = "tbDir";
            this.tbDir.Size = new System.Drawing.Size(238, 20);
            this.tbDir.TabIndex = 0;
            this.tbDir.Click += new System.EventHandler(this.btDirBrowse_Click);
            // 
            // btDirAdd
            // 
            this.btDirAdd.Location = new System.Drawing.Point(6, 32);
            this.btDirAdd.Name = "btDirAdd";
            this.btDirAdd.Size = new System.Drawing.Size(302, 23);
            this.btDirAdd.TabIndex = 1;
            this.btDirAdd.Text = "Toevoegen";
            this.btDirAdd.UseVisualStyleBackColor = true;
            this.btDirAdd.Click += new System.EventHandler(this.btDirAdd_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 347);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(326, 135);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btDirBrowse);
            this.tabPage1.Controls.Add(this.btDirAdd);
            this.tabPage1.Controls.Add(this.tbDir);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(318, 109);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Map";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btDirBrowse
            // 
            this.btDirBrowse.Location = new System.Drawing.Point(250, 5);
            this.btDirBrowse.Name = "btDirBrowse";
            this.btDirBrowse.Size = new System.Drawing.Size(58, 23);
            this.btDirBrowse.TabIndex = 2;
            this.btDirBrowse.Text = "Bladeren";
            this.btDirBrowse.UseVisualStyleBackColor = true;
            this.btDirBrowse.Click += new System.EventHandler(this.btDirBrowse_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btFileBrowse);
            this.tabPage2.Controls.Add(this.btFileAdd);
            this.tabPage2.Controls.Add(this.tbFile);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(318, 61);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bestand";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btFileBrowse
            // 
            this.btFileBrowse.Location = new System.Drawing.Point(250, 5);
            this.btFileBrowse.Name = "btFileBrowse";
            this.btFileBrowse.Size = new System.Drawing.Size(58, 23);
            this.btFileBrowse.TabIndex = 5;
            this.btFileBrowse.Text = "Bladeren";
            this.btFileBrowse.UseVisualStyleBackColor = true;
            this.btFileBrowse.Click += new System.EventHandler(this.btFileBrowse_Click);
            // 
            // btFileAdd
            // 
            this.btFileAdd.Location = new System.Drawing.Point(6, 32);
            this.btFileAdd.Name = "btFileAdd";
            this.btFileAdd.Size = new System.Drawing.Size(302, 23);
            this.btFileAdd.TabIndex = 4;
            this.btFileAdd.Text = "Toevoegen";
            this.btFileAdd.UseVisualStyleBackColor = true;
            this.btFileAdd.Click += new System.EventHandler(this.btFileAdd_Click);
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(6, 6);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(238, 20);
            this.tbFile.TabIndex = 3;
            this.tbFile.Click += new System.EventHandler(this.btFileBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            // 
            // gbSave
            // 
            this.gbSave.Controls.Add(this.btTarget);
            this.gbSave.Controls.Add(this.btSave);
            this.gbSave.Controls.Add(this.tbTarget);
            this.gbSave.Controls.Add(this.tbName);
            this.gbSave.Controls.Add(this.tbDate);
            this.gbSave.Controls.Add(this.lbTarget);
            this.gbSave.Controls.Add(this.lbName);
            this.gbSave.Controls.Add(this.lbDate);
            this.gbSave.Location = new System.Drawing.Point(345, 348);
            this.gbSave.Name = "gbSave";
            this.gbSave.Size = new System.Drawing.Size(332, 134);
            this.gbSave.TabIndex = 5;
            this.gbSave.TabStop = false;
            this.gbSave.Text = "Inplannen";
            // 
            // tbTarget
            // 
            this.tbTarget.Location = new System.Drawing.Point(51, 74);
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.Size = new System.Drawing.Size(211, 20);
            this.tbTarget.TabIndex = 1;
            this.tbTarget.Click += new System.EventHandler(this.btTarget_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(51, 46);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(275, 20);
            this.tbName.TabIndex = 1;
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(51, 20);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(275, 20);
            this.tbDate.TabIndex = 1;
            this.tbDate.Text = "d dddd MMMM yyyy";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(6, 21);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(38, 13);
            this.lbDate.TabIndex = 0;
            this.lbDate.Text = "Datum";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(9, 100);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 6;
            this.btSave.Text = "Opslaan";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(6, 49);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Naam";
            // 
            // lbTarget
            // 
            this.lbTarget.AutoSize = true;
            this.lbTarget.Location = new System.Drawing.Point(6, 77);
            this.lbTarget.Name = "lbTarget";
            this.lbTarget.Size = new System.Drawing.Size(29, 13);
            this.lbTarget.TabIndex = 0;
            this.lbTarget.Text = "Doel";
            // 
            // btTarget
            // 
            this.btTarget.Location = new System.Drawing.Point(268, 72);
            this.btTarget.Name = "btTarget";
            this.btTarget.Size = new System.Drawing.Size(58, 23);
            this.btTarget.TabIndex = 3;
            this.btTarget.Text = "Bladeren";
            this.btTarget.UseVisualStyleBackColor = true;
            this.btTarget.Click += new System.EventHandler(this.btTarget_Click);
            // 
            // folderBrowserDialogTarget
            // 
            this.folderBrowserDialogTarget.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(745, 23);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 494);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.gbSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.lbLocations);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Backup";
            this.Text = "Backup";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbSave.ResumeLayout(false);
            this.gbSave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbLocations;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox tbDir;
        private System.Windows.Forms.Button btDirAdd;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btDirBrowse;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btFileBrowse;
        private System.Windows.Forms.Button btFileAdd;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox gbSave;
        private System.Windows.Forms.TextBox tbTarget;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label lbTarget;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btTarget;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogTarget;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

