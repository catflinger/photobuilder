using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photobuilder.Model;

namespace Photobuilder
{
    class BuildSettings : IDiaryBuilderSettings
    {
        private AppSettings appSettings;

        public BuildSettings(AppSettings appSettings) {
            this.appSettings = appSettings;
        }

        public string indexFile => String.Format("{0}/diary.json", appSettings.distFolder);

        public string sourceFolder => appSettings.sourceFolder;

        public string distFolder => appSettings.distFolder;

        public int thumbWidth => appSettings.thumbWidth;

        public int thumbHeight => appSettings.thumbHeight;

        public int largeHeight => appSettings.largeHeight;

        public long thumbQuality => appSettings.thumbQuality;

        public long largeQuality => appSettings.largeQuality;

        public bool incrementalProcessing => appSettings.incrementalProcessing;

        public DayOfWeek FirstDayOfWeek => appSettings.FirstDayOfWeek;

        public string blankColor => appSettings.BlankColor;

        public string placeholderColor => appSettings.PlaceholderColor;

        public string ftpHost => appSettings.FtpHost;

        public string ftpPath => appSettings.FtpPath;

        public string ftpUsername => appSettings.FtpUser;

        public string ftpPassword => appSettings.FtpPassword;
    }
}
