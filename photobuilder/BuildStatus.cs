using System;
using System.ComponentModel;

using Photobuilder.Model;

namespace Photobuilder
{
    class BuildStatus : DiaryBuildStatus
    {
        private BackgroundWorker _worker;

        public BuildStatus(BackgroundWorker worker)
            :base()
        {
            _worker = worker;
        }

        protected override void reportProgress()
        {
            double pc = 0;

            if (result.photosToProcess > 0)
            {
                pc = 100 * (double)result.photosProcessed / (double)result.photosToProcess;
            }

            _worker.ReportProgress((int)Math.Floor(pc), result);
        }

    }
}
