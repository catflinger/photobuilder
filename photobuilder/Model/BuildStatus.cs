using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photobuilder.Model
{
    struct BuildResult
    {
        public int photosFound { get; set; }
        public int photosToProcess { get; set; }
        public int photosProcessed { get; set; }
    }

    class BuildStatus
    {
        private BackgroundWorker _worker;
        private BuildResult _results;

        public BuildStatus(BackgroundWorker worker)
        {
            _worker = worker;
            _results = new BuildResult();
        }

        public void foundPhoto()
        {
            _results.photosFound++;
            reportProgress();
        }

        public void photoToProcess()
        {
            _results.photosToProcess++;
            reportProgress();
        }

        public void photoProcessed()
        {
            _results.photosProcessed++;
            reportProgress();
        }

        public void reset()
        {
            _results = new BuildResult();
        }

        private void reportProgress()
        {
            double pc = 0;

            if (_results.photosToProcess > 0)
            {
                pc = 100* (double)_results.photosProcessed / (double)_results.photosToProcess;
            }

            _worker.ReportProgress((int)Math.Floor(pc), _results);
        }
    }
}
