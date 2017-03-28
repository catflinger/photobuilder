using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// Models a photograph to be included in the diary.
/// This class represent an original source image, in contrast to the 
/// DiaryPhoto class which models the resulting set of images and indexes in the output.
/// </summary>
namespace Photobuilder.Model
{
    class Photo
    {
        //path to the source photo in the file system
        public string path { get; private set; }
        
        //the date that this photo is for
        public DateTime date { get; private set; }

        private Photo(string path, DateTime date)
        {
            this.path = path;
            this.date = date;
        }

        public static Photo fromFileInfo(FileInfo fi)
        {
            Photo result = null;
            DateTime dt;

            //file name is "171230some-other-stuff.jpg" etc for a .jpg file on the 30th december 2017
            Match match = Regex.Match(fi.Name, @"^(?<year>\d{2})(?<month>\d{2})(?<day>\d{2}).*\.(jpg|png|gif)$", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                //try and make a date out of the first six characters of the filename
                if (DateTime.TryParseExact(
                                    String.Format("20{0}/{1}/{2}",
                                        match.Groups["year"].ToString(),
                                        match.Groups["month"].ToString(),
                                        match.Groups["day"].ToString()),
                                    @"yyyy/MM/dd",
                                    CultureInfo.CreateSpecificCulture("en-GB"),
                                    DateTimeStyles.None,
                                    out dt))
                {
                    result = new Photo(fi.FullName, dt);
                }
            }

            return result;
        }
    }
}
