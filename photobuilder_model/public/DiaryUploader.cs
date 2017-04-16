using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Photobuilder.Model
{
    public class DiaryUploader
    {
        public void markAllAsUploaded(IDiaryBuilderSettings settings)
        {
            DiaryIndex diary = new DiaryIndex(settings);

            diary.markAllAsUploaded();
            diary.save();
        }

        public void markAllAsNotUploaded(IDiaryBuilderSettings settings)
        {
            DiaryIndex diary = new DiaryIndex(settings);

            diary.markAllAsNotUploaded();
            diary.save();
        }

        public void uploadDiary(IDiaryBuilderSettings settings, DiaryBuildStatus status)
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
                Thread.Sleep(1000);

                status.uploading(day.thumb);
                Thread.Sleep(400);

                //mark the file as uploaded
                diary.markAsUploaded(day.date);
                status.uploadedImage();
            }

            diary.save();

            status.finished();
        }
    }
}
