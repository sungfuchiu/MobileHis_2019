using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace MobileHis_2019.Service.Service
{
    public interface IFileService
    {
        bool GetFile(string category, string fileName, out Tuple<byte[], string> fileTuple, string IDs = "");
        byte[] BlankImage();
    }
    public class FileService
    {

        public bool GetFile(string category, string fileName, out Tuple<byte[], string> fileTuple, string IDs = "")
        {
            fileTuple = null;
            if (!string.IsNullOrEmpty(fileName))
            {
                var IDArray = IDs.Split(';').Where(a => a != string.Empty).ToArray();

                var storage = MobileHis.Misc.Storage.GetStorage(category);//Storage.GetDrugAppearanceStorage;// DrugViewModel.AppearanceStorage;
                if (!string.IsNullOrEmpty(fileName) && (storage.FileExist(fileName) || storage.FileExist(fileName, IDArray)))
                {
                    if (IDs.Length == 0)
                        fileTuple = storage.OpenImage(fileName);

                    else
                        fileTuple = storage.OpenImage(fileName, IDArray);

                    if (fileTuple != null)
                        return true;
                }
            }
            return false;
        }
        public byte[] BlankImage()
        {
            var b = new Bitmap(1, 1);
            b.SetPixel(0, 0, Color.White);
            ImageConverter converter = new ImageConverter();
            var img = (byte[])converter.ConvertTo(b, typeof(byte[]));
            return img;
        }
    }
}
