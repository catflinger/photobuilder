using Photobuilder.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photobuilder
{
    public partial class FormUpload : Form
    {
        private enum ButtonState
        {
            processing,
            cancelling,
            finished
        }
        private ButtonState buttonState;

        private DiaryUploader uploader;
        private BuildStatus uploadStatus;

        public FormUpload()
        {
            InitializeComponent();
        }

        public AppSettings settings { get; set; }

        private void FormUpload_Load(object sender, EventArgs e)
        {
            //kick of the upload automatically
            uploader = new DiaryUploader();
            uploadStatus = new BuildStatus(backgroundWorker1);
            buttonState = ButtonState.processing;
            button1.Text = "Cancel";
            button1.Enabled = true;

            backgroundWorker1.RunWorkerAsync();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            switch (buttonState)
            {
                case ButtonState.finished:
                    Close();
                    break;

                case ButtonState.cancelling:
                    //do nothing
                    break;

                case ButtonState.processing:
                    //cancel the operation
                    buttonState = ButtonState.cancelling;
                    button1.Text = "Cancelling...";
                    button1.Enabled = false;

                    backgroundWorker1.CancelAsync();
                    break;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Text = "Close";
            button1.Enabled = true;
            buttonState = ButtonState.finished;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //run the task
            uploader.uploadDiary(new BuildSettings(settings), uploadStatus);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //update the progress
            BuildResult result = (BuildResult)e.UserState;

            textTotal.Text = result.imagesFound.ToString();
            textToUpload.Text = result.imagesToUpload.ToString();
            textUploaded.Text = result.imagesUploaded.ToString();
            labelCurrentFile.Text = result.currentFile;

            //check if the user has requested to cancel the operation
            if (backgroundWorker1.CancellationPending)
            {
                uploadStatus.cancelOperation();
            }

            if (result.buildState == BuildResult.States.Uploading && result.imagesToUpload > 0)
            {
                progressBar1.Value = (100 * result.imagesUploaded) / result.imagesToUpload;
            }
            else
            {
                progressBar1.Value = 0;
            }
        }
    }
}
