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

        public IEnumerable<Photo> photos { get { return _photos; } }

        public PhotoSource(AppSettings settings)
        {
            _settings = settings;
            _photos = new List<Photo>();
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

                //check that this is a suitably named file
                if (photo != null)
                {
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
