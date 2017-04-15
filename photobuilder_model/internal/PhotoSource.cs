using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photobuilder.Model
{
    class PhotoSource
    {
        private IDiaryBuilderSettings _settings;
        private DiaryBuildStatus _status;
        private IList<Photo> _photos;
        private DiaryIndex _prevIndex;

        public IEnumerable<Photo> photos { get { return _photos; } }

        public PhotoSource(IDiaryBuilderSettings settings, DiaryBuildStatus status, DiaryIndex index)
        {
            _settings = settings;
            _status = status;
            _photos = new List<Photo>();
            _prevIndex = index;
        }

        public void loadPhotos()
        {
            //make a list of photos in the source directory
            DirectoryInfo source = new DirectoryInfo(_settings.sourceFolder);
            getPhotos(source);
        }

        public IEnumerable<int> getYearList()
        {
            //return a list of years that the photo collection spans
            return _photos.GroupBy(p => p.date.Year).Select(gp => gp.Key);
        }

        private void getPhotos(DirectoryInfo current)
        {
            //add all the files in this folder
            foreach (FileInfo fi in current.GetFiles())
            {
                Photo photo = Photo.fromFileInfo(fi, _prevIndex);

                //check that this was a suitably named file
                if (photo != null)
                {
                    _photos.Add(photo);
                    _status.foundPhoto();
                }
            }

            //now recurse into subdirectories
            foreach (DirectoryInfo di in current.GetDirectories())
            {
                getPhotos(di);
            }
        }

    }
}
