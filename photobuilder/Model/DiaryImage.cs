﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photobuilder.Model
{

    class DiaryImage : DiaryImageBase
    {
        private Photo _photo;

        public DiaryImage(AppSettings settings, Photo photo) 
            : base(settings, photo.date.ToString("yyyyMMdd") + ".jpg") {
            _photo = photo;
        }

        public override void makeImages()
        {
            //load the source image
            Bitmap source = (Bitmap)Image.FromFile(_photo.path);

            //rotate or flip the image to match the embedded exif data
            fixExifRotation(source);

            //make the thumbnail
            //Image thumb = source.GetThumbnailImage(_settings.thumbWidth, _settings.thumbHeight, new Image.GetThumbnailImageAbort(callback), IntPtr.Zero);
            Image thumb = makeThumbnailImage(source);
            saveImage(thumb, pathThumb, settings.thumbQuality);

            //make the large image
            Bitmap large = resizeImage(source, settings.largeHeight);
            saveImage(large, pathLarge, settings.largeQuality);
        }

        protected Bitmap makeThumbnailImage(Image source)
        {
            Bitmap thumb = new Bitmap(settings.thumbWidth, settings.thumbHeight);
            RectangleF cropRect;

            //calculate the aspect ratio of the source and thumbnail images
            float thumbAspectRatio = (float)settings.thumbWidth / settings.thumbHeight;
            float aspectRatio = (float)source.Width / source.Height;

            //compare the aspect ratios
            if (aspectRatio > thumbAspectRatio)
            {
                //the source is wider then the destination, crop it on the right to give it the same aspect ratio
                cropRect = new RectangleF(0, 0, source.Height * thumbAspectRatio, source.Height);
            }
            else
            {
                //the source is taller then the destination, crop it on the bottom
                cropRect = new RectangleF(0, 0, source.Width, source.Width / thumbAspectRatio);
            }

            //draw the crop rect scaled into the thumbnail
            using (Graphics g = Graphics.FromImage(thumb))
            {
                g.DrawImage(source, new Rectangle(0, 0, thumb.Width, thumb.Height), cropRect, GraphicsUnit.Pixel);
            }

            return thumb;
        }

        protected Bitmap resizeImage(Image source, int height)
        {
            double scale = (double)height / source.Height;
            Size size = new Size((int)Math.Round(source.Width * scale), (int)Math.Round(source.Height * scale));

            var destRect = new Rectangle(new Point(0, 0), size);
            var destImage = new Bitmap(size.Width, size.Height);

            destImage.SetResolution(source.HorizontalResolution, source.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(source, destRect, 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void fixExifRotation(Image img)
        {
            foreach (var prop in img.PropertyItems)
            {
                if (prop.Id == 0x0112) //value of EXIF
                {
                    int orientationValue = img.GetPropertyItem(prop.Id).Value[0];
                    RotateFlipType rotateFlipType = GetOrientationToFlipType(orientationValue);
                    img.RotateFlip(rotateFlipType);
                    break;
                }
            }
        }
        private static RotateFlipType GetOrientationToFlipType(int orientationValue)
        {
            RotateFlipType rotateFlipType = RotateFlipType.RotateNoneFlipNone;

            switch (orientationValue)
            {
                case 1:
                    rotateFlipType = RotateFlipType.RotateNoneFlipNone;
                    break;
                case 2:
                    rotateFlipType = RotateFlipType.RotateNoneFlipX;
                    break;
                case 3:
                    rotateFlipType = RotateFlipType.Rotate180FlipNone;
                    break;
                case 4:
                    rotateFlipType = RotateFlipType.Rotate180FlipX;
                    break;
                case 5:
                    rotateFlipType = RotateFlipType.Rotate90FlipX;
                    break;
                case 6:
                    rotateFlipType = RotateFlipType.Rotate90FlipNone;
                    break;
                case 7:
                    rotateFlipType = RotateFlipType.Rotate270FlipX;
                    break;
                case 8:
                    rotateFlipType = RotateFlipType.Rotate270FlipNone;
                    break;
                default:
                    rotateFlipType = RotateFlipType.RotateNoneFlipNone;
                    break;
            }

            return rotateFlipType;
        }
    }
}
