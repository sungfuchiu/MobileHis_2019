using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS;
using NPOI.Util; 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MobileHis.Models.Areas.Elearning
{
    public class TestedExcel
    {
        public MemoryStream Excel(Dictionary<int, string> user, Dictionary<int, string> correct)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            var sheet = workbook.CreateSheet("UserAnswer");
            var sheet1 = workbook.CreateSheet("CorrectAnswer");
            var headerRow = sheet.CreateRow(0);
            var headerRow1 = sheet1.CreateRow(0);
            int rowIndex = 1;
            foreach (var d in user)
            {
                var dataRow = sheet.CreateRow(rowIndex);
                dataRow.CreateCell(0).SetCellValue(d.Key.ToString());
                dataRow.CreateCell(1).SetCellValue(d.Value);
                rowIndex++;
            }
            int Index = 1;
            foreach (var c in correct)
            {
                var dataRow = sheet1.CreateRow(Index);
                dataRow.CreateCell(0).SetCellValue(c.Key.ToString());
                dataRow.CreateCell(1).SetCellValue(c.Value);
                Index++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            sheet = null;
            headerRow = null;
            workbook = null;
            return ms;
        }
    }
}