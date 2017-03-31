using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Photobuilder.Model
{
    /// <summary>
    /// A set of images large, small, thumb etc suitable for display in a browser
    /// </summary>
    abstract class DiaryImageBase
    {
        protected IDiaryBuilderSettings settings { get; private set; }
        protected DiaryBuildStatus status { get; private set; }
        protected string filename { get; private set; }

        //full path and name for output files
        protected string pathLarge { get { return String.Format("{0}/large/{1}", settings.distFolder, filename); } }
        protected string pathThumb { get { return String.Format("{0}/thumb/{1}", settings.distFolder, filename); } }

        public DiaryImageBase(IDiaryBuilderSettings settings, DiaryBuildStatus status, string filename)
        {
            this.settings = settings;
            this.status = status;
            this.filename = filename;
        }

        public abstract int makeImages();

        public virtual JObject toJson()
        {
            return new JObject(
                new JProperty("large", String.Format("large/{0}", filename)),
                new JProperty("thumb", String.Format("thumb/{0}", filename)),
                new JProperty("caption", ""));
        }

        protected void saveImage(Image image, String path, long quality = 100L)
        {
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            EncoderParameters prams = new EncoderParameters(1);
            prams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            image.Save(path, jpgEncoder, prams);
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }

}
