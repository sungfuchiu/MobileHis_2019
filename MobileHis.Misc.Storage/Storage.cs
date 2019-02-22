using System;
using System.IO;
using System.Configuration;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using MobileHis.Models.MobileHisModel;
using OfficeOpenXml;
using System.Linq;
using System.Reflection;

namespace MobileHis.Misc
{
    public class StorageScope
    {
        public static string Drug = "drugs";
        public static string Official = "Official";
        public static string backgroundImg = "backgroundImg";

        public static string HospitalEnvironment = "HospitalEnvironment";

        public static string ProfilePic = "ProfilePic";
        public static string Patient = "Patient";

        public static string UserUpload = System.IO.Path.Combine("System", "UserUpload");
        public static string DrugUpload = System.IO.Path.Combine("System", "DrugUpload");
        public static string PatientUpload = System.IO.Path.Combine("System", "PatientUpload");
        public static string GuardianUpload = System.IO.Path.Combine("System", "Guardian", "Edit");

        public static string EleaningTestPaper = System.IO.Path.Combine("E-leaning", "TestPaper");
        public static string EleaningAttachments = System.IO.Path.Combine("E-leaning", "Course", "Attachments");
        public static string CourseTempFiles = System.IO.Path.Combine("E-leaning", "Course", "TempFiles");
        public static string CourseExam = System.IO.Path.Combine("E-leaning", "Course", "Exam");

        public static string OpdRecordAttachment = System.IO.Path.Combine("Opd", "OpdRecordAttachment");


        public static string GetScope(string path)
        {
            if (path.Contains(UserUpload)) return UserUpload;
            if (path.Contains(DrugUpload)) return DrugUpload;
            if (path.Contains(GuardianUpload)) return GuardianUpload;
            if (path.Contains(EleaningTestPaper)) return EleaningTestPaper;
            if (path.Contains(Official)) return Official;

            if (path.Contains(backgroundImg)) return backgroundImg;
            if (path.Contains(ProfilePic)) return ProfilePic;
            if (path.Contains(EleaningAttachments)) return EleaningAttachments;
            if (path.Contains(HospitalEnvironment)) return HospitalEnvironment;
            return "";
        }
    }
    public struct StorageCloneObject
    {
        public string setting { get; set; }
        public string fileName { get; set; }
        public List<int> ids { get; set; }
    }
    public class Storage
    {
        private string Root { get; set; }
        public string Scope { get; protected set; }

        private string ImageNotFound = System.AppDomain.CurrentDomain.BaseDirectory + "/Image/no_image_found.jpg";
        private string DoctoeImageNotFound = System.AppDomain.CurrentDomain.BaseDirectory + "/Image/default_doctor.png";

        protected List<string> imageExtensions = new List<string>() { ".png", ".jpg", ".jpeg", ".bmp" };
        protected List<string> fileExtensions = new List<string>() { ".xlsx", ".exe" };
        protected List<string> attactmentExtensions = new List<string>() { ".png", ".jpg", ".jpeg", ".bmp", ".doc", ".docx", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf", ".txt" };
        protected List<string> videoExtensions = new List<string>() { ".mp4" };

        string GetDataType(string ext)
        {
            ext = ext.ToLower();
            switch (ext)
            {
                #region image
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                #endregion
                case ".mp4":
                    return "video/mp4";
                case ".doc":
                case ".docx":
                    return "application/msword";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".pptx":
                    return "application/x-mspowerpoint";
                case ".xls":
                case ".xlsx":
                    return "application/excel";
                case ".pdf":
                    return "application/pdf";
                case ".txt":
                    return "text/plain";
                default:
                    return "text/plain";

            };
        }
        string GetImgFormat(Image img)
        {
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                return ".jpg";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                return ".bmp";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                return ".png";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                return ".gif";
            return ".jpg";
        }
        /// <summary>
        /// 建立一個 Storage 實體
        /// </summary>
        /// <param name="scope">1: scope/sub_scope (eleaning/question),2: scope (drug)</param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static Storage GetStorage(string scope, string setting = "DefaultStorage")
        {
            return new Storage(scope, setting);
        }

        public Storage(string scope, string setting)
        {
            Root = ConfigurationManager.AppSettings[setting];
            if (String.IsNullOrWhiteSpace(Root))
            {
                throw new SystemException(String.Format("Can not find setting: \"{0}\" in Web.Config", setting));
            }
            Scope = scope;
        }


        public bool CheckExtensions(string extension)
        {
            extension = extension.ToLower();
            if (Scope == StorageScope.EleaningAttachments) return attactmentExtensions.Contains(extension);
            if (Scope == StorageScope.backgroundImg || Scope == StorageScope.Official || Scope == StorageScope.ProfilePic || Scope == StorageScope.Patient || Scope == StorageScope.HospitalEnvironment) return imageExtensions.Contains(extension);
            if (Scope == StorageScope.CourseTempFiles || Scope == StorageScope.EleaningTestPaper) return (fileExtensions.Contains(extension) || imageExtensions.Contains(extension));
            if (Scope == StorageScope.PatientUpload || Scope == StorageScope.UserUpload || Scope == StorageScope.DrugUpload) return (extension == ".xlsx");
            if (Scope == StorageScope.GuardianUpload) return imageExtensions.Contains(extension) || videoExtensions.Contains(extension);

            return false;
        }
        private string GetNewFileName(string fileName, string extension)
        {
            if (FileExist(fileName))
            {
                var name = fileName.Replace(extension, "");
                fileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
            }
            return fileName;
        }
        private string GetNewFileName(string fileName, string extension, params string[] id)
        {
            if (FileExist(fileName, id))
            {
                var name = fileName.Replace(extension, "");
                fileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
            }
            return fileName;
        }
        private string GetNewFileName(string fileName, string extension, params int[] id)
        {
            var listId = new List<string>();
            if (id == null)
                return System.IO.Path.Combine(Root, Scope);

            for (int i = 0; i < id.Length; i++)
            {
                listId.Add(id[i].ToString());
            }
            return GetNewFileName(fileName, extension, listId.ToArray());
        }
        private Tuple<byte[], string> GetImage()
        {
            if (Scope == StorageScope.ProfilePic) return GetImage(DoctoeImageNotFound);
            return GetImage(ImageNotFound);
        }
        private Tuple<byte[], string> GetImage(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    var extension = System.IO.Path.GetExtension(path);
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    return new Tuple<byte[], string>(imageBytes, GetDataType(extension));
                }

            }
        }
        private Metadata ReadMetatada(Guid id)
        {
            return System.Web.Helpers.Json.Decode<Metadata>(File.ReadAllText(GetMetadataPath(id)));
        }

        private void WriteMetadata(Guid id, string filename, string mimetype)
        {
            var buf = System.Web.Helpers.Json.Encode(new Metadata()
            {
                Name = filename,
                Mimetype = mimetype
            });
            File.WriteAllText(GetMetadataPath(id), buf);
        }



        private string GetMetadataPath(Guid id)
        {
            return String.Format("{0}.{1}", this.Path(id), "metadata");
        }
        #region path
        public string Path(Guid id)
        {
            string name = id.ToString("N");
            string[] route = new string[]{
                Scope,
                name.Substring(0, 2),
                name.Substring(2, 2),
                name.Substring(4, 2),
                name.Substring(6, 2)
            };

            string path = Root;
            foreach (var node in route)
            {
                path = System.IO.Path.Combine(path, node);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }

            return System.IO.Path.Combine(path, name.Substring(8));
        }

        //public string Path(string id) { return Path(GuidUtility.Create(GuidUtility.UrlNamespace, id)); }

        //public string Path(int id) { return Path(id.ToString()); }
        public string Path()
        {
            string path = System.IO.Path.Combine(Root, Scope);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
        public string Path(params int[] id)
        {
            var listId = new List<string>();
            if (id == null)
                return System.IO.Path.Combine(Root, Scope);

            for (int i = 0; i < id.Length; i++)
            {
                listId.Add(id[i].ToString());
            }
            return Path(listId.ToArray());
        }
        public string Path(params string[] id)
        {
            var path = System.IO.Path.Combine(Root, Scope);
            if (id != null)
            {
                for (int i = 0; i < id.Length; i++)
                {
                    path = System.IO.Path.Combine(path, id[i]);
                }
            }
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
        #endregion
        #region FileExist
        public bool FileExist(Guid id)
        {
            return File.Exists(Path(id));
        }

        //public bool FileExist(string id) { return FileExist(GuidUtility.Create(GuidUtility.UrlNamespace, id)); }

        //public bool FileExist(int id) { return FileExist(id.ToString()); }
        public bool FileExist(string fileName)
        {
            return File.Exists(System.IO.Path.Combine(Path(), fileName ?? ""));
        }
        public bool FileExist(string fileName, params int[] id)
        {
            return File.Exists(System.IO.Path.Combine(Path(id), fileName));
        }
        public bool FileExist(string fileName, params string[] id)
        {
            return File.Exists(System.IO.Path.Combine(Path(id), fileName));
        }
        //public bool FileExist(string fullPath)
        //{
        //    return FileExist(fullPath);
        //}
        #endregion
        #region write
        public void Write(Guid id, System.Web.HttpPostedFileBase f)
        {
            Write(id, f.InputStream, f.FileName, f.ContentType);
        }

        //public void Write(string id, System.Web.HttpPostedFileBase f) { Write(GuidUtility.Create(GuidUtility.UrlNamespace, id), f); }
        //public void Write(int id, System.Web.HttpPostedFileBase f) { Write(id.ToString(), f); }
        /// <summary>
        /// upload image file to server only, won't change db
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="f"></param>
        public string Write(string fileName, System.Web.HttpPostedFileBase f)
        {
            string extension = System.IO.Path.GetExtension(fileName);
            if (CheckExtensions(extension))
            {
                fileName = GetNewFileName(fileName, extension);
                string path = System.IO.Path.Combine(Path(), fileName);
                f.SaveAs(path);
                return fileName;
            }
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="imgStr"></param>
        /// <returns></returns>
        public string Write(string fileName, string imgStr)
        {
            var imageData = Convert.FromBase64String(imgStr);
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                using (Image image = Image.FromStream(ms))
                {
                    string extension = GetImgFormat(image);
                    fileName += extension;
                    if (CheckExtensions(extension))
                    {
                        if (!FileExist(fileName))
                        {
                            string path = System.IO.Path.Combine(Path(), fileName);
                            image.Save(path);
                            return fileName;
                        }
                    }

                }
            }
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="imgStr"></param>
        /// <returns></returns>
        public string Write(string fileName, string imgStr, params string[] id)
        {
            var imageData = Convert.FromBase64String(imgStr);
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                using (Image image = Image.FromStream(ms))
                {
                    string extension = GetImgFormat(image);
                    fileName += extension;
                    if (CheckExtensions(extension))
                    {
                        fileName = GetNewFileName(fileName, extension, id);
                        string path = System.IO.Path.Combine(Path(id), fileName);
                        image.Save(path);
                        return fileName;
                    }

                }
            }
            return "";
        }
        public string Write(string fileName, byte[] imgByte)
        {
            using (MemoryStream ms = new MemoryStream(imgByte))
            {
                using (Image image = Image.FromStream(ms))
                {
                    string extension = GetImgFormat(image);
                    fileName += extension;
                    if (CheckExtensions(extension))
                    {
                        fileName = GetNewFileName(fileName, extension);
                        string path = System.IO.Path.Combine(Path(), fileName);
                        image.Save(path);
                        return fileName;

                    }

                }
            }
            return "";
        }
        public string Write(string fileName, byte[] imgByte, params string[] id)
        {
            using (MemoryStream ms = new MemoryStream(imgByte))
            {
                using (Image image = Image.FromStream(ms))
                {
                    string extension = GetImgFormat(image);
                    fileName += extension;
                    if (CheckExtensions(extension))
                    {
                        fileName = GetNewFileName(fileName, extension, id);

                        string path = System.IO.Path.Combine(Path(id), fileName);
                        image.Save(path);
                        return fileName;
                    }

                }
            }
            return "";
        }
        /// <summary>
        /// upload file to server only, won't change db
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="f"></param>
        public string Write(string fileName, System.Web.HttpPostedFileBase f, params int[] id)
        {
            string extension = System.IO.Path.GetExtension(fileName);
            if (CheckExtensions(extension) || (Scope == StorageScope.OpdRecordAttachment))
            {
                fileName = GetNewFileName(fileName, extension, id);
                string path = System.IO.Path.Combine(Path(id), fileName);
                f.SaveAs(path);
                return fileName;
            }
            return "";
        }
        /// <summary>
        /// upload file to server only, won't change db
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="f"></param>
        public string Write(string fileName, System.Web.HttpPostedFileBase f, params string[] id)
        {
            string extension = System.IO.Path.GetExtension(fileName);
            if (CheckExtensions(extension) || (Scope == StorageScope.OpdRecordAttachment))
            {
                fileName = GetNewFileName(fileName, extension, id);
                string path = System.IO.Path.Combine(Path(id), fileName);
                f.SaveAs(path);
                return fileName;
            }
            return "";
        }
        public void Write(Guid id, Stream stream, string filename, string mimetype = null)
        {
            if (mimetype == null) mimetype = System.Web.MimeMapping.GetMimeMapping(filename);
            using (var s = File.Create(Path(id)))
            {
                stream.CopyTo(s);

            }
            WriteMetadata(id, filename, mimetype);
        }
        /// <summary>
        /// email log in root/emaillog.txt
        /// </summary>
        /// <param name="from">from email</param>
        /// <param name="status">0:success; 1: contact email not set; 2: Exception</param>
        public void EmailLog(string from, string status)
        {
            string path = System.IO.Path.Combine(Root, "emaillog.txt");
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("{0}, From: {1}, Status: {2} ", DateTime.Now.ToString("YYYYMMdd_HH:mm"), from, status);
            }

        }
        public void DebugLog(string msg)
        {
            string path = System.IO.Path.Combine(Root, "debuglog.txt");
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("{0}, {1} ", DateTime.Now.ToString("yyyyMMdd_HH:mm"), msg);
            }
        }
        //public void Write(string id, Stream stream, string filename, string mimetype = null) { Write(GuidUtility.Create(GuidUtility.UrlNamespace, id), stream, filename, mimetype); }
        //public void Write(int id, Stream stream, string filename, string mimetype = null) { Write(id.ToString(), stream, filename, mimetype); }
        #endregion
        #region clone
        public void CloneImage(StorageCloneObject org, string setting, params int[] id)
        {
            var s = GetStorage(org.setting);
            if (s.FileExist(org.fileName, org.ids.ToArray()))
            {

                var orgPath = System.IO.Path.Combine(s.Path(org.ids.ToArray()), org.fileName);
                var newPath = System.IO.Path.Combine(s.Path(id), org.fileName);
                System.IO.File.Copy(orgPath, newPath, true);
            }
        }
        #endregion
        #region open
        public Tuple<string, string, Stream> Open(Guid id)
        {
            var metadata = ReadMetatada(id);
            if (FileExist(id))
                return new Tuple<string, string, Stream>(metadata.Name, metadata.Mimetype, File.Open(Path(id), FileMode.Open));
            else
                return null;
        }
        /// <summary>
        /// get image return image byte[]
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns>image byte, image data type (image/type)</returns>
        public Tuple<byte[], string> OpenImage(string fileName)
        {
            if (FileExist(fileName))
            {
                var path = System.IO.Path.Combine(Path(), fileName);
                return GetImage(path);
            }
            return GetImage();
        }
        /// <summary>
        /// get image return image byte[]
        /// </summary>
        /// <param name="category">folder name</param>
        /// <param name="fileName">file name</param>
        /// <returns>image byte, image data type (image/type)</returns>
        public Tuple<byte[], string> OpenImage(string fileName, params  int[] id)
        {
            if (FileExist(fileName, id))
            {
                var path = System.IO.Path.Combine(Path(id), fileName);
                var ext = System.IO.Path.GetExtension(fileName);
                if (imageExtensions.Contains(ext))
                {
                    return GetImage(path);
                }
                else
                {
                    byte[] fileContent = null;

                    using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        using (System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs))
                        {
                            long byteLength = new System.IO.FileInfo(path).Length;
                            fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        }
                    }
                    return new Tuple<byte[], string>(fileContent, GetDataType(ext));
                }
            }
            return GetImage();
        }
        /// <summary>
        /// get image return image byte[]
        /// </summary>
        /// <param name="category">folder name</param>
        /// <param name="fileName">file name</param>
        /// <returns>image byte, image data type (image/type)</returns>
        public Tuple<byte[], string> OpenImage(string fileName, params  string[] id)
        {
            if (FileExist(fileName, id))
            {
                var path = System.IO.Path.Combine(Path(id), fileName);
                var ext = System.IO.Path.GetExtension(fileName);
                if (imageExtensions.Contains(ext))
                {
                    return GetImage(path);
                }
                else
                {
                    byte[] fileContent = null;

                    using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        using (System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs))
                        {
                            long byteLength = new System.IO.FileInfo(path).Length;
                            fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        }
                    }
                    return new Tuple<byte[], string>(fileContent, GetDataType(ext));
                }
            }
            return GetImage();
        }
        public Tuple<byte[], string> OpenFile(string fullPath)
        {
            var path = System.IO.Path.Combine(Root, fullPath);
            if (File.Exists(path))
            {
                var ext = System.IO.Path.GetExtension(fullPath);
                if (imageExtensions.Contains(ext))
                {
                    return GetImage(path);
                }
                else
                {
                    byte[] fileContent = null;

                    using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        using (System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs))
                        {
                            long byteLength = new System.IO.FileInfo(path).Length;
                            fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        }
                    }
                    return new Tuple<byte[], string>(fileContent, GetDataType(ext));
                }
            }
            return GetImage();
        }
        //public Tuple<string, string, Stream> Open(string id) { return Open(GuidUtility.Create(GuidUtility.UrlNamespace, id)); }
        //public Tuple<string, string, Stream> Open(int id) { return Open(id.ToString()); }
        public List<T> OpenExcel<T>(string fileName, string sheet) where T : new()
        {
            IList<T> result = new List<T>();

            var path = System.IO.Path.Combine(Path(), fileName);
            var t = new T();
            var props = t.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);


            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                using (ExcelPackage excel = new ExcelPackage(fileStream))
                {
                    var workSheet = excel.Workbook.Worksheets[sheet];
                    Dictionary<string, int> header = new Dictionary<string, int>();
                    for (int rowIndex = workSheet.Dimension.Start.Row; rowIndex <= workSheet.Dimension.End.Row; rowIndex++)
                    {
                        //Assume the first row is the header. Then use the column match ups by name to determine the index.
                        //This will allow you to have the order of the columns change without any affect.

                        if (rowIndex == 1)
                        {
                            header = ExcelHelper.GetExcelHeader(workSheet, rowIndex);
                        }
                        else
                        {
                            var insert = new T();
                            for (int i = 0; i < props.Length; i++)
                            {
                                var p = props[i];
                                var val = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, p.Name);
                                p.SetValue(insert, val);
                            }
                            result.Add(insert);

                        }
                    }
                }
            }
            return result.ToList();
        }
        #endregion
        #region Delete
        public void Delete(Guid id)
        {
            var fileList = new string[] {
                Path(id),
                GetMetadataPath(id)
            };
            foreach (var p in fileList)
                if (File.Exists(p)) File.Delete(p);
        }
        public void Delete(string fileName)
        {
            var path = System.IO.Path.Combine(Path(), fileName);
            if (File.Exists(path)) File.Delete(path);
        }
        public void Delete(string fileName, params  int[] id)
        {
            var path = System.IO.Path.Combine(Path(id), fileName);
            if (File.Exists(path)) File.Delete(path);
        }
        public void Delete(string fileName, params  string[] id)
        {
            var path = System.IO.Path.Combine(Path(id), fileName);
            if (File.Exists(path)) File.Delete(path);
        }
        //public void Delete(string id) { Delete(GuidUtility.Create(GuidUtility.UrlNamespace, id)); }
        //public void Delete(int id) { Delete(GuidUtility.Create(GuidUtility.UrlNamespace, id.ToString())); }
        #endregion


    }
    #region Excel
    public static class ExcelHelper
    {
        ///<summary>
        /// Gets the excel header and creates a dictionary object based on column name in order to get the index.
        /// Assumes that each column name is unique.
        /// </summary>

        /// <param name="workSheet"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetExcelHeader(ExcelWorksheet workSheet, int rowIndex)
        {
            Dictionary<string, int> header = new Dictionary<string, int>();

            if (workSheet != null)
            {
                for (int columnIndex = workSheet.Dimension.Start.Column; columnIndex <= workSheet.Dimension.End.Column; columnIndex++)
                {
                    if (workSheet.Cells[rowIndex, columnIndex].Value != null)
                    {
                        string columnName = workSheet.Cells[rowIndex, columnIndex].Value.ToString();

                        if (!header.ContainsKey(columnName) && !string.IsNullOrEmpty(columnName))
                        {
                            header.Add(columnName, columnIndex);
                        }
                    }
                }
            }

            return header;
        }

        ///<summary>
        /// Parse worksheet values based on the information given.
        /// </summary>

        /// <param name="workSheet"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string ParseWorksheetValue(ExcelWorksheet workSheet, Dictionary<string, int> header, int rowIndex, string columnName)
        {
            string value = string.Empty;
            int? columnIndex = header.ContainsKey(columnName) ? header[columnName] : (int?)null;

            if (workSheet != null && columnIndex != null && workSheet.Cells[rowIndex, columnIndex.Value].Value != null)
            {
                value = workSheet.Cells[rowIndex, columnIndex.Value].Value.ToString();
            }

            return value;
        }
    }
    #endregion
}