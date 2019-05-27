using System;
using System.Drawing;
using System.IO;

namespace EasyBase64ToImage
{
    public class ImageToString
    {
        /// <summary>
        /// Converts Image to Base64
        /// </summary>
        /// <param name="image">Image</param>
        /// <returns>Base64 String</returns>
        public static string ImageToBase64(Image image)
        {
            using (var m = new MemoryStream())
            {
                image.Save(m, image.RawFormat);
                byte[] imageBytes = m.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        /// <summary>
        /// Converts Base64-String to Image
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms);
                return image;
            }
        }
    }
}
