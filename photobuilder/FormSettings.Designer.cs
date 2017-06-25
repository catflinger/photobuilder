namespace Photobuilder
{
    partial class FormSettings
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dlgContentFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.txtFtpHost = new System.Windows.Forms.TextBox();
            this.txtFtpPath = new System.Windows.Forms.TextBox();
            this.txtFtpPassword = new System.Windows.Forms.TextBox();
            this.txtFtpUser = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonPlaceholder = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panelPlaceholder = new System.Windows.Forms.Panel();
            this.buttonBlank = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panelBlank = new System.Windows.Forms.Panel();
            this.comboDayOfWeek = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDistFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchDist = new System.Windows.Forms.Button();
            this.chkIncremental = new System.Windows.Forms.CheckBox();
            this.nudQualityLarge = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nudQualityThumb = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtThumbHeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLargeHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.txtThumbWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchSource = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQualityLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQualityThumb)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(521, 234);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 34);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(625, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dlgContentFolder
            // 
            this.dlgContentFolder.Description = "Select the content folder containg the gallery.xml file";
            // 
            // txtFtpHost
            // 
            this.txtFtpHost.Location = new System.Drawing.Point(76, 27);
            this.txtFtpHost.Name = "txtFtpHost";
            this.txtFtpHost.Size = new System.Drawing.Size(229, 20);
            this.txtFtpHost.TabIndex = 40;
            // 
            // txtFtpPath
            // 
            this.txtFtpPath.Location = new System.Drawing.Point(76, 53);
            this.txtFtpPath.Name = "txtFtpPath";
            this.txtFtpPath.Size = new System.Drawing.Size(229, 20);
            this.txtFtpPath.TabIndex = 41;
            // 
            // txtFtpPassword
            // 
            this.txtFtpPassword.Location = new System.Drawing.Point(77, 105);
            this.txtFtpPassword.Name = "txtFtpPassword";
            this.txtFtpPassword.PasswordChar = '*';
            this.txtFtpPassword.Size = new System.Drawing.Size(121, 20);
            this.txtFtpPassword.TabIndex = 42;
            this.txtFtpPassword.UseSystemPasswordChar = true;
            // 
            // txtFtpUser
            // 
            this.txtFtpUser.Location = new System.Drawing.Point(76, 79);
            this.txtFtpUser.Name = "txtFtpUser";
            this.txtFtpUser.Size = new System.Drawing.Size(121, 20);
            this.txtFtpUser.TabIndex = 43;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "host";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "password";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 46;
            this.label14.Text = "user";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 47;
            this.label15.Text = "path";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFtpHost);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtFtpPath);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtFtpPassword);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtFtpUser);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(449, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 169);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FTP details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonPlaceholder);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.panelPlaceholder);
            this.groupBox2.Controls.Add(this.buttonBlank);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.panelBlank);
            this.groupBox2.Controls.Add(this.comboDayOfWeek);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDistFolder);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnSearchDist);
            this.groupBox2.Controls.Add(this.chkIncremental);
            this.groupBox2.Controls.Add(this.nudQualityLarge);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.nudQualityThumb);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtThumbHeight);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtLargeHeight);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lbl3);
            this.groupBox2.Controls.Add(this.txtThumbWidth);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtSourceFolder);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSearchSource);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 290);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Diary";
            // 
            // buttonPlaceholder
            // 
            this.buttonPlaceholder.Location = new System.Drawing.Point(255, 244);
            this.buttonPlaceholder.Name = "buttonPlaceholder";
            this.buttonPlaceholder.Size = new System.Drawing.Size(24, 24);
            this.buttonPlaceholder.TabIndex = 66;
            this.buttonPlaceholder.Text = "...";
            this.buttonPlaceholder.UseVisualStyleBackColor = true;
            this.buttonPlaceholder.Click += new System.EventHandler(this.buttonPlaceholder_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Placeholder colour";
            // 
            // panelPlaceholder
            // 
            this.panelPlaceholder.Location = new System.Drawing.Point(120, 240);
            this.panelPlaceholder.Name = "panelPlaceholder";
            this.panelPlaceholder.Size = new System.Drawing.Size(120, 29);
            this.panelPlaceholder.TabIndex = 64;
            // 
            // buttonBlank
            // 
            this.buttonBlank.Location = new System.Drawing.Point(255, 209);
            this.buttonBlank.Name = "buttonBlank";
            this.buttonBlank.Size = new System.Drawing.Size(24, 24);
            this.buttonBlank.TabIndex = 63;
            this.buttonBlank.Text = "...";
            this.buttonBlank.UseVisualStyleBackColor = true;
            this.buttonBlank.Click += new System.EventHandler(this.buttonBlank_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Blank image colour";
            // 
            // panelBlank
            // 
            this.panelBlank.Location = new System.Drawing.Point(120, 205);
            this.panelBlank.Name = "panelBlank";
            this.panelBlank.Size = new System.Drawing.Size(120, 29);
            this.panelBlank.TabIndex = 61;
            // 
            // comboDayOfWeek
            // 
            this.comboDayOfWeek.FormattingEnabled = true;
            this.comboDayOfWeek.Location = new System.Drawing.Point(120, 175);
            this.comboDayOfWeek.Name = "comboDayOfWeek";
            this.comboDayOfWeek.Size = new System.Drawing.Size(121, 21);
            this.comboDayOfWeek.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "First day of week";
            // 
            // txtDistFolder
            // 
            this.txtDistFolder.Location = new System.Drawing.Point(120, 47);
            this.txtDistFolder.Name = "txtDistFolder";
            this.txtDistFolder.Size = new System.Drawing.Size(229, 20);
            this.txtDistFolder.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Dist folder";
            // 
            // btnSearchDist
            // 
            this.btnSearchDist.Location = new System.Drawing.Point(364, 47);
            this.btnSearchDist.Name = "btnSearchDist";
            this.btnSearchDist.Size = new System.Drawing.Size(26, 20);
            this.btnSearchDist.TabIndex = 56;
            this.btnSearchDist.Text = "...";
            this.btnSearchDist.UseVisualStyleBackColor = true;
            // 
            // chkIncremental
            // 
            this.chkIncremental.AutoSize = true;
            this.chkIncremental.Location = new System.Drawing.Point(120, 82);
            this.chkIncremental.Name = "chkIncremental";
            this.chkIncremental.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIncremental.Size = new System.Drawing.Size(197, 17);
            this.chkIncremental.TabIndex = 55;
            this.chkIncremental.Text = "Only process new and changed files";
            this.chkIncremental.UseVisualStyleBackColor = true;
            // 
            // nudQualityLarge
            // 
            this.nudQualityLarge.Location = new System.Drawing.Point(317, 146);
            this.nudQualityLarge.Name = "nudQualityLarge";
            this.nudQualityLarge.Size = new System.Drawing.Size(99, 20);
            this.nudQualityLarge.TabIndex = 54;
            this.nudQualityLarge.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(255, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "Quality";
            // 
            // nudQualityThumb
            // 
            this.nudQualityThumb.Location = new System.Drawing.Point(317, 111);
            this.nudQualityThumb.Name = "nudQualityThumb";
            this.nudQualityThumb.Size = new System.Drawing.Size(99, 20);
            this.nudQualityThumb.TabIndex = 52;
            this.nudQualityThumb.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(255, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Quality";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(159, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "X";
            // 
            // txtThumbHeight
            // 
            this.txtThumbHeight.Location = new System.Drawing.Point(175, 108);
            this.txtThumbHeight.MaxLength = 4;
            this.txtThumbHeight.Name = "txtThumbHeight";
            this.txtThumbHeight.Size = new System.Drawing.Size(38, 20);
            this.txtThumbHeight.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "pixels high";
            // 
            // txtLargeHeight
            // 
            this.txtLargeHeight.Location = new System.Drawing.Point(120, 143);
            this.txtLargeHeight.MaxLength = 4;
            this.txtLargeHeight.Name = "txtLargeHeight";
            this.txtLargeHeight.Size = new System.Drawing.Size(38, 20);
            this.txtLargeHeight.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Large image";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(215, 111);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(33, 13);
            this.lbl3.TabIndex = 45;
            this.lbl3.Text = "pixels";
            // 
            // txtThumbWidth
            // 
            this.txtThumbWidth.Location = new System.Drawing.Point(120, 108);
            this.txtThumbWidth.MaxLength = 4;
            this.txtThumbWidth.Name = "txtThumbWidth";
            this.txtThumbWidth.Size = new System.Drawing.Size(38, 20);
            this.txtThumbWidth.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Thumbnail size";
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Location = new System.Drawing.Point(120, 21);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(229, 20);
            this.txtSourceFolder.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Source folder";
            // 
            // btnSearchSource
            // 
            this.btnSearchSource.Location = new System.Drawing.Point(364, 21);
            this.btnSearchSource.Name = "btnSearchSource";
            this.btnSearchSource.Size = new System.Drawing.Size(26, 20);
            this.btnSearchSource.TabIndex = 40;
            this.btnSearchSource.Text = "...";
            this.btnSearchSource.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 323);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FormSettings";
            this.Text = "Q";
            this.Load += new System.EventHandler(this.FormPhotodiarySettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQualityLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQualityThumb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog dlgContentFolder;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox txtFtpHost;
        private System.Windows.Forms.TextBox txtFtpPath;
        private System.Windows.Forms.TextBox txtFtpPassword;
        private System.Windows.Forms.TextBox txtFtpUser;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonPlaceholder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelPlaceholder;
        private System.Windows.Forms.Button buttonBlank;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelBlank;
        private System.Windows.Forms.ComboBox comboDayOfWeek;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDistFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchDist;
        private System.Windows.Forms.CheckBox chkIncremental;
        private System.Windows.Forms.NumericUpDown nudQualityLarge;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudQualityThumb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtThumbHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLargeHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.TextBox txtThumbWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchSource;
    }
}