using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;

namespace Photobuilder.Model
{
    public class DiaryUploader
    {
        private IDiaryBuilderSettings settings;

        public DiaryUploader(IDiaryBuilderSettings settings)
        {
            this.settings = settings;
        }

        public void markAllAsUploaded()
        {
            DiaryIndex diary = new DiaryIndex(settings);

            diary.markAllAsUploaded();
            diary.save();
        }

        public void markAllAsNotUploaded()
        {
            DiaryIndex diary = new DiaryIndex(settings);

            diary.markAllAsNotUploaded();
            diary.save();
        }

        public void uploadDiary(DiaryBuildStatus status)
        {
            status.reset();
            status.initialising();
            
            DiaryIndex diary = new DiaryIndex(settings);

            //scan the diary for images
            foreach (DiaryIndex.DayInfo day in diary.getDayInfo())
            {
                status.foundImage();
                if (!day.uploaded)
                {
                    //two images per day, one large and one thumbnail
                    status.foundImageToUpload();
                    status.foundImageToUpload();
                }
            }

            //upload the images
            //scan the diary for images
            foreach (DiaryIndex.DayInfo day in diary.getDayInfo().Where(d => d.hasContent && !d.uploaded))
            {
                //first check if there is a cancel pending
                if (status.cancel)
                {
                    break;
                }

                //do the uploads
                status.uploading(day.large);
                if (uploadFile(day.large))
                {
                    status.uploadedImage();
                }

                status.uploading(day.thumb);
                if (uploadFile(day.thumb))
                {
                    status.uploadedImage();
                }

                //mark the file as uploaded
                diary.markAsUploaded(day.date);
            }

            diary.save();

            status.finished();
        }

        public bool uploadFile(string subpath)
        {
            bool success = false;

            try
            {
                //string host = "www.drurys.org";
                //string destPath = "drurysor/photodiary.drurys.org/wwwroot/assets/dist";
                //string username = "drurysor";
                //string password = "********";

                string srcPath = String.Format("{0}/{1}", settings.distFolder, subpath);
                string uri = String.Format("fttp://{0}/{1}/{2}", settings.ftpHost, settings.ftpPath, subpath);

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);

                request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.BypassCache);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(settings.ftpUsername, settings.ftpPassword);
                
                byte[] fileContents = File.ReadAllBytes(srcPath);
                request.ContentLength = fileContents.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                success = response.StatusCode == FtpStatusCode.ClosingData;
                response.Close();
            }
            catch (WebException e)
            {
                success = false;
            }

            return success;
        }
    }
}
