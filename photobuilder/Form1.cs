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
        protected struct BuildResult
        {
            public int countFound;
            public int countProcessed;
        }

        private AppSettings _settings;

        public Form1()
        {
            InitializeComponent();
            _settings = new AppSettings();

            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonProcess.Enabled = false;
            buttonSettings.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            FormSettings form = new FormSettings(_settings);
            DialogResult result = form.ShowDialog();
        }

        private BuildResult makeDiary(BackgroundWorker worker)
        {
            BuildResult result = new BuildResult();

            DiaryIndex oldIndex = new DiaryIndex(_settings);
            PhotoSource source = new PhotoSource(_settings, oldIndex);
            Diary diary = new Diary(_settings);

            //remove any existing output
            if (!_settings.incrementalProcessing)
            {
                diary.cleanOutputFolders();
            }

            //load the source photos off disk
            source.loadPhotos();

            //get a list of all the years that the source images span
            IEnumerable<int> yearList = source.getYearList();

            //populate the diary with months, weeks, days et for the years in scope
            diary.buildIndex(yearList);

            //match up the photos to the days in the diary
            result.countFound = diary.addPhotos(source.photos);

            worker.ReportProgress(0, result);

            //make web images from the source photos for the output and index them
            result.countProcessed = diary.makeImages(source.photos);

            worker.ReportProgress(100, result);

            //create and save the index file
            DiaryIndex.saveIndex(_settings, diary);

            return result;
        }

        // This event handler is where the actual diary building happens
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Assign the result of the computation to the Result property of the DoWorkEventArgs
            // This is will be available to the RunWorkerCompleted eventhandler.
            e.Result = makeDiary(worker);
        }

        // This event handler deals with the results of the background operation.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(String.Format("An error occurred during the build: {0}", e.Error.Message));
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Build Canceled");
            }
            else
            {
                // Finally, handle the case where the build succeeded.
                BuildResult result = (BuildResult)e.Result;

                txtFound.Text = result.countFound.ToString();
                txtProcessed.Text = result.countProcessed.ToString();
            }

            // Enable the Start button.
            buttonProcess.Enabled = true;
            buttonSettings.Enabled = true;
        }
        
        // This event handler updates the progress bar.
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BuildResult result = (BuildResult)e.UserState;
            txtFound.Text = result.countFound.ToString();
            txtProcessed.Text = result.countProcessed.ToString();

            this.progressBar1.Value = e.ProgressPercentage;
        }
    }
}
