using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photobuilder.Model
{
    public class DiaryBuilder
    {
        public void makeDiary(IDiaryBuilderSettings settings, DiaryBuildStatus buildStatus)
        {
            buildStatus.reset();

            DiaryIndex oldIndex = new DiaryIndex(settings);
            PhotoSource source = new PhotoSource(settings, oldIndex);
            Diary diary = new Diary(settings, buildStatus);

            //remove any existing output
            if (!settings.incrementalProcessing)
            {
                diary.cleanOutputFolders();
            }

            //load the source photos off disk
            source.loadPhotos();

            //get a list of all the years that the source images span
            IEnumerable<int> yearList = source.getYearList();

            //populate the diary with months, weeks, days et for the years in scope
            diary.buildIndex(yearList);

            //match up the photos to the days in the diary
            diary.addPhotos(source.photos);

            //make web images from the source photos for the output and index them
            diary.makeImages(source.photos);

            //create and save the index file
            DiaryIndex.saveIndex(settings, diary);
        }
    }
}
