using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Photobuilder.Model
{
    class DiaryMonth
    {
        private DateTime _firstDayOfMonth;
        private AppSettings _settings;

        public List<DiaryWeek> weeks = new List<DiaryWeek>();

        public int monthNumber {  get { return _firstDayOfMonth.Month;  } }

        public int photoCount { get; private set; }

        public DiaryMonth(AppSettings settings, DateTime firstDay)
        {
            _settings = settings;
            _firstDayOfMonth = firstDay;

            DateTime day = _firstDayOfMonth;

            //keep adding weeks until we have one that starts in the following month
            do
            {
                //every month contains at least one week
                DiaryWeek week = new DiaryWeek(_settings, day);
                weeks.Add(week);

                //increment day
                day = week.firstDayOfNextWeek;
            }
            while (day.Month == _firstDayOfMonth.Month);
        }

        public int addPhotos(IEnumerable<Photo> photos)
        {
            //add the photos into the year list
            foreach (DiaryWeek week in weeks)
            {
                photoCount += week.addPhotos(photos);
            }
            return photoCount;
        }

        public int makeImages()
        {
            int count = 0;

            foreach (DiaryWeek week in weeks)
            {
                count += week.makeImages();
            }

            return count;
        }



        public JObject toJson()
        {
            return new JObject(
                new JProperty("hasContent", photoCount > 0),
                new JProperty("month", monthNumber),
                new JProperty("name", _firstDayOfMonth.ToString("MMMM")),
                new JProperty("weeks",
                new JArray(weeks.Select(w => w.toJson()))));
        }
    }
}
