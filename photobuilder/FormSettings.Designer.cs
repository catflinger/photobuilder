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
            this.btnSearchSource = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.dlgContentFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThumbWidth = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.txtThumbHeight = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nudQualityThumb = new System.Windows.Forms.NumericUpDown();
            this.chkIncremental = new System.Windows.Forms.CheckBox();
            this.nudQualityLarge = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLargeHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDistFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchDist = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboDayOfWeek = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudQualityThumb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQualityLarge)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchSource
            // 
            this.btnSearchSource.Location = new System.Drawing.Point(390, 9);
            this.btnSearchSource.Name = "btnSearchSource";
            this.btnSearchSource.Size = new System.Drawing.Size(99, 20);
            this.btnSearchSource.TabIndex = 1;
            this.btnSearchSource.Text = "Search";
            this.btnSearchSource.UseVisualStyleBackColor = true;
            this.btnSearchSource.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(213, 246);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 34);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(307, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source folder";
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Location = new System.Drawing.Point(146, 9);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(229, 20);
            this.txtSourceFolder.TabIndex = 5;
            // 
            // dlgContentFolder
            // 
            this.dlgContentFolder.Description = "Select the content folder containg the gallery.xml file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Thumbnail size";
            // 
            // txtThumbWidth
            // 
            this.txtThumbWidth.Location = new System.Drawing.Point(146, 123);
            this.txtThumbWidth.MaxLength = 4;
            this.txtThumbWidth.Name = "txtThumbWidth";
            this.txtThumbWidth.Size = new System.Drawing.Size(38, 20);
            this.txtThumbWidth.TabIndex = 7;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(273, 126);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(33, 13);
            this.lbl3.TabIndex = 8;
            this.lbl3.Text = "pixels";
            // 
            // txtThumbHeight
            // 
            this.txtThumbHeight.Location = new System.Drawing.Point(219, 123);
            this.txtThumbHeight.MaxLength = 4;
            this.txtThumbHeight.Name = "txtThumbHeight";
            this.txtThumbHeight.Size = new System.Drawing.Size(38, 20);
            this.txtThumbHeight.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(197, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(362, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Quality";
            // 
            // nudQualityThumb
            // 
            this.nudQualityThumb.Location = new System.Drawing.Point(424, 126);
            this.nudQualityThumb.Name = "nudQualityThumb";
            this.nudQualityThumb.Size = new System.Drawing.Size(99, 20);
            this.nudQualityThumb.TabIndex = 23;
            this.nudQualityThumb.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // chkIncremental
            // 
            this.chkIncremental.AutoSize = true;
            this.chkIncremental.Location = new System.Drawing.Point(146, 70);
            this.chkIncremental.Name = "chkIncremental";
            this.chkIncremental.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIncremental.Size = new System.Drawing.Size(197, 17);
            this.chkIncremental.TabIndex = 28;
            this.chkIncremental.Text = "Only process new and changed files";
            this.chkIncremental.UseVisualStyleBackColor = true;
            // 
            // nudQualityLarge
            // 
            this.nudQualityLarge.Location = new System.Drawing.Point(424, 161);
            this.nudQualityLarge.Name = "nudQualityLarge";
            this.nudQualityLarge.Size = new System.Drawing.Size(99, 20);
            this.nudQualityLarge.TabIndex = 25;
            this.nudQualityLarge.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(362, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Quality";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "pixels high";
            // 
            // txtLargeHeight
            // 
            this.txtLargeHeight.Location = new System.Drawing.Point(146, 158);
            this.txtLargeHeight.MaxLength = 4;
            this.txtLargeHeight.Name = "txtLargeHeight";
            this.txtLargeHeight.Size = new System.Drawing.Size(38, 20);
            this.txtLargeHeight.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Large image";
            // 
            // txtDistFolder
            // 
            this.txtDistFolder.Location = new System.Drawing.Point(146, 35);
            this.txtDistFolder.Name = "txtDistFolder";
            this.txtDistFolder.Size = new System.Drawing.Size(229, 20);
            this.txtDistFolder.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Dist folder";
            // 
            // btnSearchDist
            // 
            this.btnSearchDist.Location = new System.Drawing.Point(390, 35);
            this.btnSearchDist.Name = "btnSearchDist";
            this.btnSearchDist.Size = new System.Drawing.Size(99, 20);
            this.btnSearchDist.TabIndex = 29;
            this.btnSearchDist.Text = "Search";
            this.btnSearchDist.UseVisualStyleBackColor = true;
            this.btnSearchDist.Click += new System.EventHandler(this.btnSearchDist_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "First day of week";
            // 
            // comboDayOfWeek
            // 
            this.comboDayOfWeek.FormattingEnabled = true;
            this.comboDayOfWeek.Location = new System.Drawing.Point(146, 190);
            this.comboDayOfWeek.Name = "comboDayOfWeek";
            this.comboDayOfWeek.Size = new System.Drawing.Size(121, 21);
            this.comboDayOfWeek.TabIndex = 33;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 316);
            this.Controls.Add(this.comboDayOfWeek);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDistFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearchDist);
            this.Controls.Add(this.chkIncremental);
            this.Controls.Add(this.nudQualityLarge);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nudQualityThumb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtThumbHeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLargeHeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtThumbWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSourceFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSearchSource);
            this.Name = "FormSettings";
            this.Text = "Q";
            this.Load += new System.EventHandler(this.FormPhotodiarySettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQualityThumb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQualityLarge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchSource;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.FolderBrowserDialog dlgContentFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThumbWidth;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.TextBox txtThumbHeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudQualityThumb;
        private System.Windows.Forms.CheckBox chkIncremental;
        private System.Windows.Forms.NumericUpDown nudQualityLarge;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLargeHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDistFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchDist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboDayOfWeek;
    }
}