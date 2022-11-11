namespace Checksum
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.textboxFilePath = new System.Windows.Forms.TextBox();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.textboxComputedHash = new System.Windows.Forms.TextBox();
            this.labelComputedHash = new System.Windows.Forms.Label();
            this.buttonSelectFileDialog = new System.Windows.Forms.Button();
            this.buttonCalculateHash = new System.Windows.Forms.Button();
            this.computeFileHash = new System.ComponentModel.BackgroundWorker();
            this.pollCurrentBytesCompleted = new System.Windows.Forms.Timer(this.components);
            this.buttonCancelHash = new System.Windows.Forms.Button();
            this.progressBarBytesRead = new System.Windows.Forms.ProgressBar();
            this.textBoxCurrentByteCount = new System.Windows.Forms.TextBox();
            this.textBoxTotalByteCount = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxCompare = new System.Windows.Forms.GroupBox();
            this.buttonCompareHash = new System.Windows.Forms.Button();
            this.labelHashToCompare = new System.Windows.Forms.Label();
            this.textboxHashToCompare = new System.Windows.Forms.TextBox();
            this.groupBoxCalculated = new System.Windows.Forms.GroupBox();
            this.rbtnMD5 = new System.Windows.Forms.RadioButton();
            this.rbtnSHA1 = new System.Windows.Forms.RadioButton();
            this.rbtnSHA256 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBoxCompare.SuspendLayout();
            this.groupBoxCalculated.SuspendLayout();
            this.SuspendLayout();
            // 
            // textboxFilePath
            // 
            this.textboxFilePath.Location = new System.Drawing.Point(15, 74);
            this.textboxFilePath.Name = "textboxFilePath";
            this.textboxFilePath.ReadOnly = true;
            this.textboxFilePath.Size = new System.Drawing.Size(434, 20);
            this.textboxFilePath.TabIndex = 0;
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(15, 58);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(26, 13);
            this.labelFilePath.TabIndex = 2;
            this.labelFilePath.Text = "File:";
            // 
            // textboxComputedHash
            // 
            this.textboxComputedHash.Location = new System.Drawing.Point(118, 86);
            this.textboxComputedHash.Name = "textboxComputedHash";
            this.textboxComputedHash.ReadOnly = true;
            this.textboxComputedHash.Size = new System.Drawing.Size(422, 20);
            this.textboxComputedHash.TabIndex = 0;
            this.textboxComputedHash.Text = "12345678901234567890123456789012345";
            // 
            // labelComputedHash
            // 
            this.labelComputedHash.AutoSize = true;
            this.labelComputedHash.Location = new System.Drawing.Point(11, 89);
            this.labelComputedHash.Name = "labelComputedHash";
            this.labelComputedHash.Size = new System.Drawing.Size(86, 13);
            this.labelComputedHash.TabIndex = 2;
            this.labelComputedHash.Text = "Computed Hash:";
            // 
            // buttonSelectFileDialog
            // 
            this.buttonSelectFileDialog.Location = new System.Drawing.Point(576, 74);
            this.buttonSelectFileDialog.Name = "buttonSelectFileDialog";
            this.buttonSelectFileDialog.Size = new System.Drawing.Size(119, 23);
            this.buttonSelectFileDialog.TabIndex = 3;
            this.buttonSelectFileDialog.Text = "Select File";
            this.buttonSelectFileDialog.UseVisualStyleBackColor = true;
            this.buttonSelectFileDialog.Click += new System.EventHandler(this.buttonOpenFileDialog_Click);
            // 
            // buttonCalculateHash
            // 
            this.buttonCalculateHash.Location = new System.Drawing.Point(561, 51);
            this.buttonCalculateHash.Name = "buttonCalculateHash";
            this.buttonCalculateHash.Size = new System.Drawing.Size(119, 23);
            this.buttonCalculateHash.TabIndex = 3;
            this.buttonCalculateHash.Text = "Calculate Hash";
            this.buttonCalculateHash.UseVisualStyleBackColor = true;
            this.buttonCalculateHash.Click += new System.EventHandler(this.buttonGetHash_Click);
            // 
            // computeFileHash
            // 
            this.computeFileHash.WorkerReportsProgress = true;
            this.computeFileHash.WorkerSupportsCancellation = true;
            this.computeFileHash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.computeFileHash_DoWork);
            this.computeFileHash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.computeFileHash_RunWorkerCompleted);
            // 
            // pollCurrentBytesCompleted
            // 
            this.pollCurrentBytesCompleted.Interval = 250;
            this.pollCurrentBytesCompleted.Tick += new System.EventHandler(this.pollCurrentBytesCompleted_Tick);
            // 
            // buttonCancelHash
            // 
            this.buttonCancelHash.Location = new System.Drawing.Point(561, 51);
            this.buttonCancelHash.Name = "buttonCancelHash";
            this.buttonCancelHash.Size = new System.Drawing.Size(119, 23);
            this.buttonCancelHash.TabIndex = 5;
            this.buttonCancelHash.Text = "Cancel";
            this.buttonCancelHash.UseVisualStyleBackColor = true;
            this.buttonCancelHash.Visible = false;
            this.buttonCancelHash.Click += new System.EventHandler(this.buttonCancelHash_Click);
            // 
            // progressBarBytesRead
            // 
            this.progressBarBytesRead.Location = new System.Drawing.Point(118, 51);
            this.progressBarBytesRead.Name = "progressBarBytesRead";
            this.progressBarBytesRead.Size = new System.Drawing.Size(316, 23);
            this.progressBarBytesRead.TabIndex = 6;
            // 
            // textBoxCurrentByteCount
            // 
            this.textBoxCurrentByteCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxCurrentByteCount.CausesValidation = false;
            this.textBoxCurrentByteCount.Location = new System.Drawing.Point(440, 53);
            this.textBoxCurrentByteCount.Name = "textBoxCurrentByteCount";
            this.textBoxCurrentByteCount.ReadOnly = true;
            this.textBoxCurrentByteCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxCurrentByteCount.TabIndex = 7;
            // 
            // textBoxTotalByteCount
            // 
            this.textBoxTotalByteCount.Location = new System.Drawing.Point(455, 74);
            this.textBoxTotalByteCount.Name = "textBoxTotalByteCount";
            this.textBoxTotalByteCount.ReadOnly = true;
            this.textBoxTotalByteCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotalByteCount.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(728, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBoxCompare
            // 
            this.groupBoxCompare.Controls.Add(this.buttonCompareHash);
            this.groupBoxCompare.Controls.Add(this.labelHashToCompare);
            this.groupBoxCompare.Controls.Add(this.textboxHashToCompare);
            this.groupBoxCompare.Location = new System.Drawing.Point(15, 245);
            this.groupBoxCompare.Name = "groupBoxCompare";
            this.groupBoxCompare.Size = new System.Drawing.Size(696, 38);
            this.groupBoxCompare.TabIndex = 10;
            this.groupBoxCompare.TabStop = false;
            // 
            // buttonCompareHash
            // 
            this.buttonCompareHash.Location = new System.Drawing.Point(561, 9);
            this.buttonCompareHash.Name = "buttonCompareHash";
            this.buttonCompareHash.Size = new System.Drawing.Size(119, 23);
            this.buttonCompareHash.TabIndex = 4;
            this.buttonCompareHash.Text = "Compare Hash";
            this.buttonCompareHash.UseVisualStyleBackColor = true;
            this.buttonCompareHash.Click += new System.EventHandler(this.buttonCompareHash_Click);
            // 
            // labelHashToCompare
            // 
            this.labelHashToCompare.AutoSize = true;
            this.labelHashToCompare.Location = new System.Drawing.Point(14, 15);
            this.labelHashToCompare.Name = "labelHashToCompare";
            this.labelHashToCompare.Size = new System.Drawing.Size(95, 13);
            this.labelHashToCompare.TabIndex = 3;
            this.labelHashToCompare.Text = "Hash to Compare: ";
            // 
            // textboxHashToCompare
            // 
            this.textboxHashToCompare.Location = new System.Drawing.Point(121, 12);
            this.textboxHashToCompare.Name = "textboxHashToCompare";
            this.textboxHashToCompare.Size = new System.Drawing.Size(419, 20);
            this.textboxHashToCompare.TabIndex = 1;
            this.textboxHashToCompare.Text = "12345678901234567890123456789012345";
            // 
            // groupBoxCalculated
            // 
            this.groupBoxCalculated.Controls.Add(this.label2);
            this.groupBoxCalculated.Controls.Add(this.rbtnSHA256);
            this.groupBoxCalculated.Controls.Add(this.label1);
            this.groupBoxCalculated.Controls.Add(this.textBoxCurrentByteCount);
            this.groupBoxCalculated.Controls.Add(this.rbtnSHA1);
            this.groupBoxCalculated.Controls.Add(this.textboxComputedHash);
            this.groupBoxCalculated.Controls.Add(this.progressBarBytesRead);
            this.groupBoxCalculated.Controls.Add(this.rbtnMD5);
            this.groupBoxCalculated.Controls.Add(this.labelComputedHash);
            this.groupBoxCalculated.Controls.Add(this.buttonCalculateHash);
            this.groupBoxCalculated.Controls.Add(this.buttonCancelHash);
            this.groupBoxCalculated.Location = new System.Drawing.Point(15, 114);
            this.groupBoxCalculated.Name = "groupBoxCalculated";
            this.groupBoxCalculated.Size = new System.Drawing.Size(693, 115);
            this.groupBoxCalculated.TabIndex = 11;
            this.groupBoxCalculated.TabStop = false;
            // 
            // rbtnMD5
            // 
            this.rbtnMD5.AutoSize = true;
            this.rbtnMD5.Location = new System.Drawing.Point(121, 16);
            this.rbtnMD5.Name = "rbtnMD5";
            this.rbtnMD5.Size = new System.Drawing.Size(48, 17);
            this.rbtnMD5.TabIndex = 12;
            this.rbtnMD5.TabStop = true;
            this.rbtnMD5.Text = "MD5";
            this.rbtnMD5.UseVisualStyleBackColor = true;
            // 
            // rbtnSHA1
            // 
            this.rbtnSHA1.AutoSize = true;
            this.rbtnSHA1.Location = new System.Drawing.Point(186, 16);
            this.rbtnSHA1.Name = "rbtnSHA1";
            this.rbtnSHA1.Size = new System.Drawing.Size(53, 17);
            this.rbtnSHA1.TabIndex = 13;
            this.rbtnSHA1.TabStop = true;
            this.rbtnSHA1.Text = "SHA1";
            this.rbtnSHA1.UseVisualStyleBackColor = true;
            // 
            // rbtnSHA256
            // 
            this.rbtnSHA256.AutoSize = true;
            this.rbtnSHA256.Location = new System.Drawing.Point(281, 16);
            this.rbtnSHA256.Name = "rbtnSHA256";
            this.rbtnSHA256.Size = new System.Drawing.Size(65, 17);
            this.rbtnSHA256.TabIndex = 15;
            this.rbtnSHA256.TabStop = true;
            this.rbtnSHA256.Text = "SHA256";
            this.rbtnSHA256.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Hash Algorithm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Progress:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 307);
            this.Controls.Add(this.groupBoxCalculated);
            this.Controls.Add(this.groupBoxCompare);
            this.Controls.Add(this.textBoxTotalByteCount);
            this.Controls.Add(this.buttonSelectFileDialog);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.textboxFilePath);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checksum";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxCompare.ResumeLayout(false);
            this.groupBoxCompare.PerformLayout();
            this.groupBoxCalculated.ResumeLayout(false);
            this.groupBoxCalculated.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxFilePath;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.TextBox textboxComputedHash;
        private System.Windows.Forms.Label labelComputedHash;
        private System.Windows.Forms.Button buttonSelectFileDialog;
        private System.Windows.Forms.Button buttonCalculateHash;
        private System.ComponentModel.BackgroundWorker computeFileHash;
        private System.Windows.Forms.Timer pollCurrentBytesCompleted;
        private System.Windows.Forms.Button buttonCancelHash;
        private System.Windows.Forms.ProgressBar progressBarBytesRead;
        private System.Windows.Forms.TextBox textBoxCurrentByteCount;
        private System.Windows.Forms.TextBox textBoxTotalByteCount;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxCompare;
        private System.Windows.Forms.Button buttonCompareHash;
        private System.Windows.Forms.Label labelHashToCompare;
        private System.Windows.Forms.TextBox textboxHashToCompare;
        private System.Windows.Forms.GroupBox groupBoxCalculated;
        private System.Windows.Forms.RadioButton rbtnSHA256;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnSHA1;
        private System.Windows.Forms.RadioButton rbtnMD5;
        private System.Windows.Forms.Label label2;
    }
}

