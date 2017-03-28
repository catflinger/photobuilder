using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Photobuilder.Model
{
    class DiaryYear
    {
        public int yearNumber { get; private set; }
        public List<DiaryMonth> months = new List<DiaryMonth>();
        public int photoCount { get; private set; }

        public DiaryYear(AppSettings settings, int year)
        {
            this.yearNumber = year;

            for (int n = 1;  n <= 12; n++)
            {
                months.Add(new DiaryMonth(settings, new DateTime(year, n, 1)));
            } 
        }

        public int addPhotos(IEnumerable<Photo> photos)
        {
            //add the photos into the year list
            foreach (DiaryMonth month in months)
            {
                photoCount += month.addPhotos(photos);
            }
            return photoCount;
        }

        public void makeImages()
        {
            foreach (DiaryMonth month in months)
            {
                month.makeImages();
            }
        }


        public JObject toJson()
        {
            return new JObject(
                new JProperty("year", yearNumber),
                new JProperty("caption", yearNumber.ToString()),
                new JProperty("hasContent", photoCount > 0),

                new JProperty("months",
                    new JArray(months.Where(m => m.photoCount > 0).Select(m => m.toJson()))));
        }
    }
}
