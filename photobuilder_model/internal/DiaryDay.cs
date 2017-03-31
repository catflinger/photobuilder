using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;


namespace Photobuilder.Model
{
    class DiaryDay
    {
        private IDiaryBuilderSettings _settings;
        private DiaryBuildStatus _bs;

        //the date that this day object represents.  Note that there can be more than one day object
        //for a given date: see the active property below.
        private DateTime _day;

        //active if day is inside its correct month.  Inactive days are found at the beginning and end of calendar months
        //and are present because they are present in a week that overlaps a month boundary.  Typically an inactive day in
        //one month will have a corresponding active day in the adjoining month
        public bool active { get; private set; }

        //indicates that the day has a user-submitted photo, not just a blank or a placeholder image
        public bool hasContent { get; private set; }

        private DiaryImageBase image { get; set; }

        public string name { get { return _day.DayOfWeek.ToString(); } }

        public DiaryDay(IDiaryBuilderSettings settings, DiaryBuildStatus status, DateTime day, bool active)
        {
            _settings = settings;
            _bs = status;
            _day = day;
            this.active = active;
            image = null;
            hasContent = false;
        }

        public int addPhotos(IEnumerable<Photo> photos)
        {
            int count = 0;

            if (active)
            {
                Photo photo = photos.FirstOrDefault(p => p.date.Date == _day.Date);

                if (photo != null)
                {
                    DiaryImage img = new DiaryImage(_settings, _bs, photo);
                    hasContent = true;

                    if (!img.skipProcessing)
                    {
                        _bs.photoToProcess();
                    }

                    image = img;
                    count++;
                }
                else
                {
                    image = new DiaryImageBlank(_settings, _bs);
                }
            }
            else
            {
                image = new DiaryImagePlaceholder(_settings, _bs);
            }

            return count;
        }

        public void makeImages()
        {
            if (hasContent)
            {
                image.makeImages();
            }
        }


        public JObject toJson()
        {
            return new JObject(
                new JProperty("name", name),
                new JProperty("date", active ? (DateTime?)_day : null ),
                new JProperty("day",  active ? (int?)_day.Day : null),
                new JProperty("active", active),
                new JProperty("hasContent", hasContent),
                new JProperty("photo", image.toJson()));
        }
    }

}

