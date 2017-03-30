using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;


namespace Photobuilder.Model

{
    class DiaryWeek
    {
        private AppSettings _settings;
        private BuildStatus _bs;

        private DateTime _baseDay;  //the day used to identify the week
        private DateTime _firstDay; //the first day of the calendar week contining the base day

        public List<DiaryDay> days = new List<DiaryDay>();

        //indicates that the week contains at least one a user-submitted photo
        public int photoCount { get; private set; }

        public DiaryWeek(AppSettings settings, BuildStatus status, DateTime day)
        {
            _baseDay = day;
            _firstDay = day;
            _settings = settings;
            _bs = status;

            photoCount = 0;

            //step backwards to find the first day of the calendar week 
            //thatcontains the first day of the month
            while (_firstDay.DayOfWeek != settings.FirstDayOfWeek)
            {
                _firstDay = _firstDay.AddDays(-1);
            }

            //add 7 day objects into the week
            for (int i = 0; i < 7; i++)
            {
                //the day of the week to add to the list
                DateTime d = _firstDay.AddDays(i);
                
                //the day is active if it is inside the same month as the base day
                //an inactive day represents a placeholder on the calendar
                bool active = d.Month == _baseDay.Month;

                days.Add(new DiaryDay(_settings, _bs, d, active));
            }
        }

        public DateTime firstDayOfNextWeek {
            get { return _firstDay.AddDays(7); }
        }

        public int addPhotos(IEnumerable<Photo> photos)
        {
            //add the photos into the year list
            foreach (DiaryDay day in days)
            {
                photoCount += day.addPhotos(photos);
            }

            return photoCount;
        }

        public void makeImages()
        {
            foreach (DiaryDay day in days)
            {
                day.makeImages();
            }
        }

        public JObject toJson()
        {
            return new JObject(
                new JProperty("hasContent", photoCount > 0),
                new JProperty("days",
                    new JArray(days.Select(d => d.toJson()))));
        }
    }

}

