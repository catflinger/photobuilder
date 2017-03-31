namespace Photobuilder.Model
{
    public struct BuildResult
    {
        public enum States
        {
            Idle,
            Initialising,
            Scanning,
            Processing,
            Finished
        }

        public int photosFound { get; internal set; }
        public int photosToProcess { get; internal set; }
        public int photosProcessed { get; internal set; }

        public States buildState { get; internal set; }
    }

    public class DiaryBuildStatus
    {
        private BuildResult _results;
        public BuildResult result => _results;

        public DiaryBuildStatus()
        {
            _results = new BuildResult();
            _results.buildState = BuildResult.States.Idle;
        }

        public void reset()
        {
            _results = new BuildResult();
            reportProgress();
        }

        protected virtual void reportProgress()
        {
            //to be overidden by the calling application if progress indication is required
        }

        internal void idle()
        {
            _results.buildState = BuildResult.States.Idle;
            reportProgress();
        }

        internal void initialising()
        {
            _results.buildState = BuildResult.States.Initialising;
            reportProgress();
        }

        internal void scannig()
        {
            _results.buildState = BuildResult.States.Scanning;
            reportProgress();
        }

        internal void processing()
        {
            _results.buildState = BuildResult.States.Processing;
            reportProgress();
        }

        internal void finished()
        {
            _results.buildState = BuildResult.States.Finished;
            reportProgress();
        }

        internal void foundPhoto()
        {
            _results.photosFound++;
            reportProgress();
        }

        internal void photoToProcess()
        {
            _results.photosToProcess++;
            reportProgress();
        }

        internal void photoProcessed()
        {
            _results.photosProcessed++;
            reportProgress();
        }


    }
}
