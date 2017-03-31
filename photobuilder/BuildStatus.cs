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

            switch (result.buildState)
            {
                case BuildResult.States.Idle:
                    pc = 0;
                    break;

                case BuildResult.States.Initialising:
                    pc = 0;
                    break;

                case BuildResult.States.Scanning:
                    //TO DO: how to report progress when we do not yet know how many files there are in total?
                    pc = 0;
                    break;

                case BuildResult.States.Processing:
                    if (result.photosToProcess != 0)
                    {
                        pc = 100 * (double)result.photosProcessed / (double)result.photosToProcess;
                    }
                    else
                    {
                        pc = 100;
                    }
                    break;

                case BuildResult.States.Finished:
                    pc = 100;
                    break;

                default:
                    break;
            }

            _worker.ReportProgress((int)Math.Floor(pc), result);
        }

    }
}
