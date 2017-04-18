using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Photobuilder.Model;

namespace Photobuilder
{
    public partial class Form1 : Form
    {
        private AppSettings _settings;
        private DiaryBuildStatus _buildStatus;
        private DiaryBuilder _builder;

        public Form1()
        {
            InitializeComponent();
            _settings = new AppSettings();

            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);

            _buildStatus = new BuildStatus(backgroundWorker1);
            _builder = new DiaryBuilder();
        }

        // This event handler is where the actual diary building happens
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _builder.makeDiary(new BuildSettings(_settings), _buildStatus);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(String.Format("An error occurred during the build: {0}", e.Error.Message));
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Build Cancelled");
            }
            else
            {
                MessageBox.Show("Build Completed");
            }

            // Enable the Start button.
            buttonProcess.Enabled = true;
            mnuSettings.Enabled = true;
            mnuUpload.Enabled = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BuildResult result = (BuildResult)e.UserState;
            txtFound.Text = result.photosFound.ToString();
            txtProcessed.Text = result.photosProcessed.ToString();

            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            FormSettings form = new FormSettings(_settings);
            DialogResult result = form.ShowDialog();
        }

        private void mnuUploadLatest_Click(object sender, EventArgs e)
        {
            FormUpload form = new FormUpload();
            form.settings = _settings;
            form.ShowDialog();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            buttonProcess.Enabled = false;
            mnuSettings.Enabled = false;
            mnuUpload.Enabled = false;

            backgroundWorker1.RunWorkerAsync();
        }

        private void mnuMarkAll_Click(object sender, EventArgs e)
        {
            DiaryUploader uploader = new DiaryUploader(new BuildSettings(_settings));

            uploader.markAllAsUploaded();

            MessageBox.Show("Done.");
        }

        private void mnuClearAll_Click(object sender, EventArgs e)
        {
            DiaryUploader uploader = new DiaryUploader(new BuildSettings(_settings));

            uploader.markAllAsNotUploaded();

            MessageBox.Show("Done.");
        }
    }
}
