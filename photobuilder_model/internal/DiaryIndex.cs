using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photobuilder.Model
{
    class DiaryIndex
    {
        //private DiaryBuilderSettings _settings;
        private JObject _jRoot;

        public bool isLoaded { get { return _jRoot != null; } }

        public DiaryIndex(IDiaryBuilderSettings settings)
        {
            //_settings = settings;
            try
            {
                _jRoot = JObject.Parse(
                    File.ReadAllText(settings.indexFile));
            }
            catch
            {
                _jRoot = null;
            }
        }

        public static void saveIndex(IDiaryBuilderSettings settings, Diary diary)
        {
            //create a JSON container object
            JObject jIndex = new JObject(
                //version of this file format
                new JProperty("version", "1.0"),

                //encode the settings as JSON
                new JProperty("settings", new JObject(

                    new JProperty("thumb",
                        new JObject(
                            new JProperty("path", "thumb"),
                            new JProperty("width", settings.thumbWidth),
                            new JProperty("height", settings.thumbHeight))),

                    new JProperty("large",
                        new JObject(
                            new JProperty("path", "large"),
                            new JProperty("height", settings.largeHeight))))),

                //encode the index as JSON
                new JProperty("index", diary.toJson()));

            //save it all to disk
            File.WriteAllText(
                settings.indexFile,
                jIndex.ToString(Newtonsoft.Json.Formatting.Indented));
        }

        public string getHashForDay(DateTime date)
        {
            string result = null;

            if (_jRoot != null)
            {
                //get all the weeks for the year and month
                IEnumerable<JToken> weeks = _jRoot["index"]["years"]
                    .Children()
                    .Where(y => y.Value<int>("year") == date.Year)
                    .Select(y => y["months"])
                    .Children()
                    .Where(m => m.Value<int>("month") == date.Month)
                    .Select(m => m["weeks"])
                    .Children();

                //see if any of these weeks contains the day with a photo
                foreach (JToken week in weeks)
                {
                    JToken day = week["days"]
                        .Children()
                        .Where(d => d.Value<bool>("active") && d.Value<int>("day") == date.Day)
                        .FirstOrDefault();

                    if (day != null)
                    {
                        JToken photo = day["photo"];
                        if (photo != null)
                        {
                            result = photo.Value<string>("hash");
                            break;
                        }
                    }
                }
            }

            return result;
        }

    }
}
