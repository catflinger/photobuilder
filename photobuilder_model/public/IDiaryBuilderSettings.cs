using System;
using System.Collections.Generic;
using System.Text;

namespace Photobuilder.Model
{
    public interface IDiaryBuilderSettings
    {
        string indexFile { get; }

        string sourceFolder { get; }

        string distFolder { get; }

        int thumbWidth { get; }

        int thumbHeight { get; }

        int largeHeight { get; }

        long thumbQuality { get; }

        long largeQuality { get; }

        bool incrementalProcessing { get; }

        DayOfWeek FirstDayOfWeek { get; }

        string blankColor { get; }

        string placeholderColor { get; }

        string ftpHost { get; }

        string ftpPath { get; }

        string ftpUsername { get; }

        string ftpPassword { get; }
    }
}
