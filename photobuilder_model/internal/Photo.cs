using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        
        //the md5 hash of the current version of the photo
        public string hashCurrent { get; private set; }

        //the md5 hash of the photo used in the previous build, extracted from the DiaryIndex
        public string hashPrev { get; private set; }

        //true if the images created from this photo are maked in the index file as having already been uploaded to the server in a previous build
        public bool uploaded { get; private set; }

        //the date that this photo is for
        public DateTime date { get; private set; }

        private Photo(string path, DateTime date)
        {
            this.path = path;
            this.date = date;
            hashPrev = null;
            uploaded = false;
        }

        public static Photo fromFileInfo(FileInfo fi, DiaryIndex prevIndex)
        {
            Photo result = null;

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
                                    out DateTime dt))
                {
                    result = new Photo(fi.FullName, dt)
                    {
                        hashCurrent = getMD5Hash(fi.FullName)
                    };

                    if (prevIndex != null)
                    {
                        DiaryIndex.DayInfo dayInfo = prevIndex.getDayInfo(result.date);
                        if (dayInfo != null)
                        {
                            result.hashPrev = dayInfo.hash;
                            result.uploaded = dayInfo.uploaded;
                        }
                    }

                }
            }

            return result;
        }

        public static string getMD5Hash(string filename)
        {
            byte[] data = File.ReadAllBytes(filename);
            byte[] hash = MD5.Create().ComputeHash(data);

            return Convert.ToBase64String(hash);
        }
    }
}
