using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Photobuilder
{
    public partial class FormSettings : Form
    {
        AppSettings _settings;

        public string contentFolder { get; set; }

        public FormSettings(AppSettings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        private void FormPhotodiarySettings_Load(object sender, EventArgs e)
        {
            txtSourceFolder.Text = _settings.sourceFolder;
            txtDistFolder.Text = _settings.distFolder;
            txtThumbWidth.Text = _settings.thumbWidth.ToString();
            txtThumbHeight.Text = _settings.thumbHeight.ToString();
            txtLargeHeight.Text = _settings.largeHeight.ToString();
            nudQualityThumb.Value = _settings.thumbQuality;
            nudQualityLarge.Value = _settings.largeQuality;
            chkIncremental.Checked = _settings.incrementalProcessing;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dlgContentFolder.ShowDialog() == DialogResult.OK)
            {
                txtSourceFolder.Text = dlgContentFolder.SelectedPath;
            }
        }

        private void btnSearchDist_Click(object sender, EventArgs e)
        {
            if (dlgContentFolder.ShowDialog() == DialogResult.OK)
            {
                txtDistFolder.Text = dlgContentFolder.SelectedPath;
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int thumbWidth = -1;
            int thumbHeight = -1;
            int largeHeight = -1;

            if (txtSourceFolder.Text.ToLower() != txtDistFolder.Text.ToLower())
            {
                if (Directory.Exists(txtSourceFolder.Text))
                {
                    if (Directory.Exists(txtDistFolder.Text))
                    {
                        if (Directory.Exists(txtDistFolder.Text + @"\large") && Directory.Exists(txtDistFolder.Text + @"\thumb"))
                        {
                            int.TryParse(txtThumbWidth.Text, out thumbWidth);
                            int.TryParse(txtThumbHeight.Text, out thumbHeight);
                            int.TryParse(txtLargeHeight.Text, out largeHeight);

                            if(thumbWidth > 0 && thumbHeight > 0 && largeHeight > 0)
                            {
                                //save the settings
                                _settings.sourceFolder = txtSourceFolder.Text;
                                _settings.distFolder = txtDistFolder.Text;
                                _settings.thumbWidth = thumbWidth;
                                _settings.thumbHeight = thumbHeight;
                                _settings.largeHeight = largeHeight;

                                _settings.thumbQuality = (long)nudQualityThumb.Value;

                                _settings.incrementalProcessing = chkIncremental.Checked;

                                _settings.Save();

                                //show message and restart
                                this.DialogResult = DialogResult.OK;
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Image sizes must be whole numbers greater than zero");
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Distribution folder does not contain subfolders /large and /thumb");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot access dist folder");
                    }
                }
                else
                {
                    MessageBox.Show("Cannot access source folder");
                }
            }
            else
            {
                MessageBox.Show("Source and destination folders cannot bethe same");
            }
        }
    }
}
