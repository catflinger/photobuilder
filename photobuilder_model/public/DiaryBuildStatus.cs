namespace Photobuilder.Model
{
    public struct BuildResult
    {
        public int photosFound { get; internal set; }
        public int photosToProcess { get; internal set; }
        public int photosProcessed { get; internal set; }
    }

    public class DiaryBuildStatus
    {
        private BuildResult _results;
        public BuildResult result => _results;

        public DiaryBuildStatus()
        {
            _results = new BuildResult();
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

        internal void finished()
        {
            reportProgress();
        }

    }
}
