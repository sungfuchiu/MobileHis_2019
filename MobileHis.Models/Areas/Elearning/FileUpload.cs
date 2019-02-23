using MobileHis.Data;
using MobileHis.Models.Areas.Elearning.ViewModels;
//using Security.DAL.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;

namespace MobileHis.Models.Areas.Elearning
{
    public class FileUpload : IDisposable
    {
        public string fileLocation { get; set; }
        public string fileExtension { get; set; }



        public DataSet UploadQuestion(HttpPostedFileBase file)
        {
            var guid = fileName();
            var real_path = save_path(file.FileName);

            file.SaveAs(real_path);
            return GetExcelDataSet(fileLocation);//renderQuestion(paperId, userID);
        }

        //private void renderQuestion(int paperId, int userID)
        //{
        //    var ds = GetExcelDataSet(fileLocation);

        //    var table = ds.Tables[0];
        //    var Questions = new List<QuestionCreate>();


        //    //  var user = HttpContext.Current.User as CustomPrincipal;
        //    foreach (DataRow r in table.Rows)
        //    {
        //        var Question = r["Question"].ToString().Trim();
        //        var type = r["type"].ToString().Trim() == "選擇" ? "select" : "qanda";
        //        var A1 = r["A"].ToString().Trim();
        //        var A2 = r["B"].ToString().Trim();
        //        var A3 = r["C"].ToString().Trim();
        //        var A4 = r["D"].ToString().Trim();
        //        var Correct = r["Correct_Answer"].ToString().Trim();
        //        var Now = DateTime.Now;
        //        List<TestAnswer> answers = new List<TestAnswer>();
        //        var test_Questions = db.TestQuestion.Where(o => o.PaperID == paperId).ToList();
        //        var Question_Count = test_Questions.Count() + table.Rows.Count;
        //        var score = 100 / Question_Count;
        //        foreach (var q in test_Questions)
        //        {
        //            q.Score = score;
        //        }
        //        if (!string.IsNullOrWhiteSpace(Question) && !string.IsNullOrWhiteSpace(Correct))
        //        {
        //            var Q = db.TestQuestion.Add(new TestQuestion
        //            {
        //                Question = Question,
        //                Created = Now,
        //                Creator = userID,//user.ID,
        //                IsDeleted = false,
        //                IsEnabled = true,
        //                QuestionType = type,
        //                PaperID = paperId,
        //                Remark = string.Empty,
        //                Score = score
        //            });

        //            if (type.Trim() == "select")
        //            {
        //                if (!string.IsNullOrWhiteSpace(A1))
        //                {
        //                    var IsCorrect = Correct.Split(',').ToList().Any(o => o == "A");
        //                    answers.Add(new TestAnswer { QuestionID = Q.ID, Answer = A1, Sort = 1, IsCorrect = IsCorrect });
        //                }

        //                if (!string.IsNullOrWhiteSpace(A2))
        //                {
        //                    var IsCorrect = Correct.Split(',').ToList().Any(o => o == "B");
        //                    answers.Add(new TestAnswer { QuestionID = Q.ID, Answer = A2, Sort = 2, IsCorrect = IsCorrect });
        //                }
        //                if (!string.IsNullOrWhiteSpace(A3))
        //                {
        //                    var IsCorrect = Correct.Split(',').ToList().Any(o => o == "C");
        //                    answers.Add(new TestAnswer { QuestionID = Q.ID, Answer = A3, Sort = 3, IsCorrect = IsCorrect });
        //                }
        //                if (!string.IsNullOrWhiteSpace(A2))
        //                {
        //                    var IsCorrect = Correct.Split(',').ToList().Any(o => o == "D");
        //                    answers.Add(new TestAnswer { QuestionID = Q.ID, Answer = A4, Sort = 4, IsCorrect = IsCorrect });
        //                }
        //            }
        //            else if (type == "qanda")
        //            {
        //                answers.Add(new TestAnswer { QuestionID = Q.ID, Answer = Correct, Sort = 1, IsCorrect = true });
        //            }

        //            Q.TestAnswer = answers;

        //        }

        //    }

        //    db.SaveChanges();
        //}

        public string save_path(string filename)
        {
            var guid = fileName();
            fileExtension = Path.GetExtension(filename);
            var FilePath = "/FilePool/Course/TempFiles";
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(FilePath)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(FilePath));
            }
            fileLocation = HttpContext.Current.Server.MapPath(Path.Combine(FilePath, guid + fileExtension));

            return fileLocation;
        }

        public DataSet GetExcelDataSet(string fileLocation)
        {
            string excelConnectionString = string.Empty;
            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            if (fileExtension == ".xls")
            {
                excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            //connection String for xlsx file format.
            else if (fileExtension == ".xlsx")
            {
                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }

            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
            excelConnection.Open();
            DataTable dt = new DataTable();
            dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            String[] excelSheets = new String[dt.Rows.Count];
            int t = 0;
            //excel data saves in temp file here.
            foreach (DataRow row in dt.Rows)
            {
                excelSheets[t] = row["TABLE_NAME"].ToString();
                t++;
            }

            DataSet ds = new DataSet();
            string query = string.Format("Select * from [{0}]", excelSheets[0]);
            OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
            {
                dataAdapter.Fill(ds);
            }
            return ds;
        }
        #region member
        public DataSet UploadMember(HttpPostedFileBase file)//List<Members> UploadMember(HttpPostedFileBase file)
        {
            var guid = fileName();
            var real_path = save_path(file.FileName);

            file.SaveAs(real_path);
            return GetExcelDataSet(fileLocation);//renderMembers();
        }
        //private List<Members> renderMembers()
        //{
        //    var ds = GetExcelDataSet(fileLocation);

        //    var table = ds.Tables[0];
        //    var members = new List<Members>();
        //    foreach (DataRow r in table.Rows)
        //    {
        //        var type = r["MemberType"].ToString().Trim();
        //        var u = r["Member"].ToString().Trim();
        //        if (type == "User")
        //        {

        //            var name = u.Split('/')[0].ToString().Trim();
        //            var email = u.Split('/')[1].ToString().Trim();
        //            var user = (from a in db.Account
        //                        join d in db.Dept on a.Dept_id equals d.ID
        //                        where a.Name == name && a.Email == email
        //                        select new Members { Dept = d.DepName, Member = a.ID.ToString(), Name = a.Name }).FirstOrDefault();
        //            if (user != null)
        //            {
        //                members.Add(new Members() { Member = user.Member, Dept = user.Dept, Name = user.Name, MemberType = type });
        //            }
        //        }
        //        else if (type == "Dept")
        //        {
        //            var dept = db.Dept.Where(o => o.DepName == u).FirstOrDefault();
        //            members.Add(new Members() { Member = dept.ID.ToString(), Dept = "", Name = dept.DepName, MemberType = type });
        //        }
        //        else if (type == "Role")
        //        {
        //            var role = db.Role.Where(o => o.name == u).FirstOrDefault();
        //            members.Add(new Members() { Member = role.ID.ToString(), Dept = "", Name = role.name, MemberType = type });
        //        }
        //    }
        //    return members;
        //}
        #endregion
        private string fileName()
        {
            var g = Guid.NewGuid().ToByteArray();
            var guid = string.Empty;
            var ra = Enumerable.Range(1, g.Length).OrderBy(n => n * n * (new Random()).Next()).Take(6);
            for (int i = 0; i < ra.Count(); i++)
            {

                guid += g[i].ToString("x");
            }
            return guid;
        }

        public void Dispose()
        {
            File.Delete(fileLocation);
        }
    }
}