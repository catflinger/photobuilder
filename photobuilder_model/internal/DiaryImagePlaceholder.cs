using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photobuilder.Model
{
    class DiaryImagePlaceholder : DiaryImageBase
    {
        public DiaryImagePlaceholder(IDiaryBuilderSettings settings, DiaryBuildStatus status)
            : base(settings, status, "placeholder.jpg")
        {
        }

        public override int makeImages()
        {
            Bitmap bmp;

            //create a transparent thumbnail
            bmp = makePlaceholder(settings.thumbWidth, settings.thumbHeight);
            saveImage(bmp, pathThumb, settings.thumbQuality);

            //create a transparent large image
            double aspectRatio = 1.5;
            bmp = makePlaceholder((int)(settings.largeHeight * aspectRatio), settings.largeHeight);
            saveImage(bmp, pathLarge, settings.largeQuality);

            return 1;
        }

        private Bitmap makePlaceholder(int width, int height)
        {
            Rectangle size = new Rectangle(0, 0, width, height);

            Bitmap bmp = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);

            using (Graphics graph = Graphics.FromImage(bmp))
            {
                graph.FillRectangle(Brushes.White, size);
            }

            return bmp;
        }
    }
}
