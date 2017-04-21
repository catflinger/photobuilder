using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photobuilder.Model
{
    internal static class Extensions
    {
        public static DiaryIndex.DayInfo toDayInfo(this JObject jo)
        {
            return new DiaryIndex.DayInfo()
            {
                hash = jo["photo"].Value<string>("hash"),
                uploaded = jo["photo"].Value<bool>("uploaded"),
                hasContent = jo.Value<bool>("hasContent"),
                thumb = jo["photo"].Value<string>("thumb"),
                large = jo["photo"].Value<string>("large"),
                date = jo.Value<DateTime>("date")
            };
        }
    }
    class DiaryIndex
    {
        public class DayInfo
        {
            public string hash { get; internal set; }
            public bool uploaded { get; internal set; }
            public bool hasContent { get; internal set; }
            public string thumb { get; internal set; }
            public string large { get; internal set; }
            public DateTime date { get; internal set; }

            internal DayInfo() { }
        }

        private IDiaryBuilderSettings _settings;
        private JObject _jRoot;

        public bool isLoaded { get { return _jRoot != null; } }

        public DiaryIndex(IDiaryBuilderSettings settings)
        {
            _settings = settings;
            try
            {
                _jRoot = JObject.Parse(
                    File.ReadAllText(settings.indexFilepath));
            }
            catch
            {
                _jRoot = null;
            }
        }

        public void save()
        {
            //save it back to disk
            File.WriteAllText(
                _settings.indexFilepath,
                _jRoot.ToString(Newtonsoft.Json.Formatting.Indented));
        }

        public static void createIndexFileFromDiary(IDiaryBuilderSettings settings, Diary diary)
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
                settings.indexFilepath,
                jIndex.ToString(Newtonsoft.Json.Formatting.Indented));
        }

        public IEnumerable<DayInfo> getDayInfo()
        {
            return getDays().Select(d => d.toDayInfo());
        }

        public DayInfo getDayInfo(DateTime date)
        {
            DayInfo result = null;

            JObject day = getDay(date);

            if (day != null)
            {
                JToken photo = day["photo"];
                if (photo != null)
                {
                    result = day.toDayInfo();
                }
            }

            return result;
        }

        public void markAsUploaded(DateTime date)
        {
            JObject day = getDay(date);
            if (day != null)
            {
                JObject photo = (JObject)day["photo"];
                photo["uploaded"] = true;
            }
        }

        public void markAllAsUploaded()
        {
            foreach(JObject day in getDays())
            {
                JObject photo = (JObject)day["photo"];
                photo["uploaded"] = true;
            }
        }

        public void markAllAsNotUploaded()
        {
            foreach (JObject day in getDays())
            {
                JObject photo = (JObject)day["photo"];
                photo["uploaded"] = false;
            }
        }

        private JObject getDay(DateTime date)
        {
            JObject result = null;

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
                        result = (JObject)day;
                        break;
                    }
                }
            }

            return result;

        }

        private IEnumerable<JObject> getDays()
        {
            return _jRoot["index"]["years"]
            .Children()
            .Select(y => y["months"])
            .Children()
            .Select(m => m["weeks"])
            .Children()
            .Select(w => w["days"])
            .Children()
            .Where(d => d.Value<bool>("active") == true)
            .Select(d => (JObject)d);
        }
    }
}
