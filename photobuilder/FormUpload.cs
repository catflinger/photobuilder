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
        private enum ProcessingState
        {
            processing,
            cancelling,
            finished
        }
        private ProcessingState state;

        public FormUpload()
        {
            InitializeComponent();
        }


        private void FormUpload_Load(object sender, EventArgs e)
        {
            //kick of the upload automatically
            state = ProcessingState.processing;
            button1.Text = "Cancel";
            button1.Enabled = true;

            backgroundWorker1.RunWorkerAsync();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case ProcessingState.finished:
                    Close();
                    break;

                case ProcessingState.cancelling:
                    //do nothing
                    break;

                case ProcessingState.processing:
                    //cancel the operation
                    state = ProcessingState.cancelling;
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
            state = ProcessingState.finished;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //run the task
            Thread.Sleep(3000);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //update the progress
        }
    }
}
