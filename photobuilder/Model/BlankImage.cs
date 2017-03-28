using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photobuilder.Model
{
    class BlankImage : DiaryImageBase
    {
        public BlankImage(AppSettings settings)
            : base(settings, "blank.jpg")
        {
        }

        public override void makeImages()
        {
            Bitmap bmp;

            //create a white thumbnail
            bmp = makeBlank(settings.thumbWidth, settings.thumbHeight);
            saveImage(bmp, pathThumb, settings.thumbQuality);

            //create a white large image
            double aspectRatio = 1.5;
            bmp = makeBlank((int)(settings.largeHeight * aspectRatio), settings.largeHeight);
            saveImage(bmp, pathLarge, settings.largeQuality);
        }

        private Bitmap makeBlank(int width, int height)
        {
            Rectangle size = new Rectangle(0, 0, width, height);

            Bitmap bmp = new Bitmap(size.Width, size.Height);

            using (Graphics graph = Graphics.FromImage(bmp))
            {
                graph.FillRectangle(Brushes.White, size);
            }
            return bmp;
        }
    }
}
