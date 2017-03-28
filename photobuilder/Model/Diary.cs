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
        public List<DiaryYear> years { get; private set; }

        private BlankImage _blank;
        private PlaceholderImage _placeholder;


        public Diary(AppSettings settings)
        {
            _settings = settings;

            years = new List<DiaryYear>();
            _blank = new BlankImage(_settings);
            _placeholder = new PlaceholderImage(_settings);
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
                years.Add(new DiaryYear(_settings, year));
            }
        }

        public int addPhotos(IEnumerable<Photo> photos)
        {
            int photoCount = 0;


            //go through the calendar day-by-day and look for photos
            foreach (DiaryYear year in years)
            {
                photoCount += year.addPhotos(photos);
            }
            return photoCount;
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
        public void makeIndex()
        {
            //create a JSON container object
            JObject jo = new JObject(
                //version of this file format
                new JProperty("version", "1.0"),

                //encode the settings as JSON
                new JProperty("settings", new JObject(

                    new JProperty("thumb",
                        new JObject(
                            new JProperty("path", "thumb"),
                            new JProperty("width", _settings.thumbWidth),
                            new JProperty("height", _settings.thumbHeight))),

                    new JProperty("large",
                        new JObject(
                            new JProperty("path", "large"),
                            new JProperty("height", _settings.largeHeight))))),

                //encode the index as JSON
                new JProperty("index",
                    new JObject(
                        new JProperty("blank", _blank.toJson()),
                        new JProperty("placeholder", _placeholder.toJson()),
                        new JProperty("years",
                            new JArray(years.Select(y => y.toJson()))))));

            string indexFile = String.Format("{0}/{1}", _settings.distFolder, _settings.indexFile);

            //save it all to disk
            File.WriteAllText(
                indexFile,
                jo.ToString(Newtonsoft.Json.Formatting.Indented));

        }

        private JObject toJson()
        {
            return new JObject();
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
