using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photobuilder.Model
{
    /// <summary>
    /// This class models the constrcted diary including manipulated photos and index.  
    /// </summary>
    class Diary
    {
        private AppSettings _settings;
        private BuildStatus _bs;
        public List<DiaryYear> years { get; private set; }

        private BlankImage _blank;
        private PlaceholderImage _placeholder;

        public Diary(AppSettings settings, BuildStatus status)
        {
            _settings = settings;
            _bs = status;

            years = new List<DiaryYear>();
            _blank = new BlankImage(_settings, _bs);
            _placeholder = new PlaceholderImage(_settings, _bs);
        }

        public void cleanOutputFolders()
        {
            //clear any existing content from the output folder
            cleanFolder(_settings.distFolder);

            //create new subfolders for output
            Directory.CreateDirectory(String.Format("{0}/large", _settings.distFolder));
            Directory.CreateDirectory(String.Format("{0}/thumb", _settings.distFolder));
        }

        public void buildIndex(IEnumerable<int> yearList)
        {
            //create an empty index in the form of a calendar covering the requested years
            foreach (var year in yearList)
            {
                years.Add(new DiaryYear(_settings, _bs, year));
            }
        }

        public void addPhotos(IEnumerable<Photo> photos)
        {
            //go through the calendar day-by-day and look for photos
            foreach (DiaryYear year in years)
            {
                year.addPhotos(photos);
            }
        }

        public void makeImages(IEnumerable<Photo> photos)
        {
            //make web-friendly images for each photo
            _blank.makeImages();
            _placeholder.makeImages();

            foreach (DiaryYear year in years)
            {
                year.makeImages();
            }
        }

        public JObject toJson()
        {
            return new JObject(
                new JProperty("blank", _blank.toJson()),
                new JProperty("placeholder", _placeholder.toJson()),
                new JProperty("years",
                    new JArray(years.Select(y => y.toJson()))));
        }


        private void cleanFolder(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                //don't delete .git files or anything else starting with .
                if (!file.Name.StartsWith("."))
                {
                    file.Delete();
                }
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

    }
}
