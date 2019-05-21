using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;

using BarcodeLib;

namespace Common
{
    public class ImageHelper
    {        
        /// <summary>
        /// Images to byte array.
        /// </summary>
        /// <returns></returns>
        public static byte[] ImageToByte(System.Drawing.Image image)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
            return xByte;
        }
       
        /// <summary>
        /// Bytes the array to image.
        /// </summary>
        /// <returns></returns>
        public static Image ByteToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static Image GetCode128(string strSource/*, int width*/, int height, bool includeLabel = true, Font font = null, int alphaBackcolor = 255)
        {
            Barcode bc = new Barcode();
            bc.IncludeLabel = includeLabel;//顯示文字標籤
            bc.LabelFont = font==null?new Font("Verdana", 6f):font;
            //bc.Width = width;//寬度
            bc.Height = height;//高度
            bc.BackColor = Color.FromArgb(alphaBackcolor, 255, 255, 255);
           
            Image img = bc.Encode(TYPE.CODE39, strSource);
            return img;
        }

        //public static Image GetCode128ByDrug(string strSource)
        //{
        //    Barcode bc = new Barcode();
        //    bc.IncludeLabel = true;//顯示文字標籤
        //    bc.LabelFont = new Font("Verdana", 6f);
        //    //bc.Width = width;//寬度
        //    bc.Height = 59;//高度
        //    bc.BackColor = Color.FromArgb(255, 255, 255, 255);
        //
        //    Image img = bc.Encode(TYPE.CODE39, strSource);
        //    return img;
        //}

        public static byte[] reSize(byte[] source, int width, int height)
        {
            var image = ByteToImage(source);
            var ratioX = (double)width / image.Width;
            var ratioY = (double)height / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(newImage, typeof(byte[]));
           
        }
    }
}