namespace Euro.CP.Main.Utils
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using Core;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;

    public class ScreenShots
    {

        private static MemoryStream stream;

        public static string TakeScreenShot(string filePath)
        {
            Screenshot ss = ((ITakesScreenshot)DriverHandler.Driver).GetScreenshot();

            string format = filePath.ToLower().Contains(".png") || filePath.ToLower().Contains(".gif") ?
                filePath : string.Format(@"{0}\{1}.png", filePath, DateTime.Now.ToString("s").Replace(':', '_'));

            ss.SaveAsFile(format, ScreenshotImageFormat.Png);
            string originalFile = RemoveDuplicatedImage(filePath, format);
            var returnPath = originalFile == string.Empty ? System.IO.Path.GetFullPath(format) : originalFile;

            return returnPath;
        }

        public static string TakeGrayscaleScreenShot(string filePath)
        {
            var ss = ((ITakesScreenshot)DriverHandler.Driver).GetScreenshot();
            var greyBitmap = MakeGrayscale(new Bitmap(new MemoryStream(ss.AsByteArray)));
            var greySS = new Screenshot(Convert.ToBase64String(ToByteArray(greyBitmap, ImageFormat.Png)));
            string format = filePath.ToLower().Contains(".png") || filePath.ToLower().Contains(".gif") ?
                filePath : string.Format(@"{0}\{1}.png", filePath, DateTime.Now.ToString("s").Replace(':', '_'));
            greySS.SaveAsFile(format, ScreenshotImageFormat.Png);

            greyBitmap.Dispose();

            string originalFile = RemoveDuplicatedImage(filePath, format);
            var returnPath = originalFile == string.Empty ? System.IO.Path.GetFullPath(format) : originalFile;
            Console.WriteLine("Screenshot: {0}", new Uri(returnPath));
            return returnPath;
        }

        private static Bitmap MakeGrayscale(Image original)
        {
            // create a blank bitmap the same size as original
            var newBitmap = new Bitmap(original.Width, original.Height);

            // get a graphics object from the new image
            var g = Graphics.FromImage(newBitmap);

            // create the grayscale ColorMatrix
            var colorMatrix = new ColorMatrix(
              new float[][]
                {
                    new float[] {.3f, .3f, .3f, 0, 0 },
                    new float[] {.59f, .59f, .59f, 0, 0 },
                    new float[] {.11f, .11f, .11f, 0, 0 },
                    new float[] {0, 0, 0, 1, 0 },
                    new float[] {0, 0, 0, 0, 1 }
                });

            // create some image attributes
            var attributes = new ImageAttributes();

            // set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            // draw the original image on the new image
            // using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
              0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            // dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }


        private static byte[] ToByteArray(Image image, ImageFormat format)
        {
            byte[] byteArray;
            stream = new MemoryStream();

            image.Save(stream, format);
            stream.Close();
            byteArray = stream.ToArray();
            return byteArray;
        }

        /// <summary>
        /// remove duplicated image when takescreenshot function is called. 
        /// </summary>
        /// <param name="filePath">folder path of the image</param>
        /// <param name="newImageFilePath">new image filepath</param>
        /// <returns></returns>
        private static string RemoveDuplicatedImage(string filePath, string newImageFilePath)
        {
            string currentfilePath = filePath.EndsWith("png") || filePath.EndsWith("gif")
                ? Directory.GetParent(filePath).FullName
                : filePath;
            FileInfo[] files = new DirectoryInfo(currentfilePath).GetFiles();
            Byte[] newImageByte = File.ReadAllBytes(newImageFilePath);

            foreach (FileInfo file in files)
            {
                if (file.Extension.EndsWith("png") && file.Name != Path.GetFileName(newImageFilePath))
                {
                    IStructuralEquatable eqa1 = newImageByte;
                    if (eqa1.Equals(File.ReadAllBytes(file.FullName), StructuralComparisons.StructuralEqualityComparer))
                    {
                        File.Delete(newImageFilePath);
                        return file.FullName;
                    }
                }
            }

            return string.Empty;
        }
    }
}
