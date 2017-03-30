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
        private AppSettings _settings;
        private IList<Photo> _photos;
        private DiaryIndex _prevIndex;

        public IEnumerable<Photo> photos { get { return _photos; } }

        public PhotoSource(AppSettings settings, DiaryIndex index)
        {
            _settings = settings;
            _photos = new List<Photo>();
            _prevIndex = index;
        }

        public void loadPhotos() {

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
                Photo photo = Photo.fromFileInfo(fi);

                //check that this was a suitably named file
                if (photo != null)
                {
                    if (_prevIndex != null)
                    {
                        photo.hashPrev = _prevIndex.getHashForDay(photo.date);
                    }
                    _photos.Add(photo);
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
