﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photobuilder.Model
{
    class DiaryImageBlank : DiaryImageBase
    {
        public DiaryImageBlank(IDiaryBuilderSettings settings, DiaryBuildStatus status)
            : base(settings, status, "blank.jpg")
        {
        }

        public override int makeImages()
        {
            Bitmap bmp;

            //create a white thumbnail
            bmp = makeBlank(settings.thumbWidth, settings.thumbHeight);
            saveImage(bmp, pathThumb, settings.thumbQuality);

            //create a white large image
            double aspectRatio = 1.5;
            bmp = makeBlank((int)(settings.largeHeight * aspectRatio), settings.largeHeight);
            saveImage(bmp, pathLarge, settings.largeQuality);

            return 1;
        }

        private Bitmap makeBlank(int width, int height)
        {
            Rectangle size = new Rectangle(0, 0, width, height);

            Bitmap bmp = new Bitmap(size.Width, size.Height);

            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Brush brush = new SolidBrush(ColorTranslator.FromHtml(settings.blankColor));
                graph.FillRectangle(brush, size);
            }
            return bmp;
        }
    }
}
