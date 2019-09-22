using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Helpers
{
    public class ExcelHelper
    {
        private readonly string TEMPLATE_PATH = @"E:\";
        private ExcelPackage package;

        public ExcelWorksheet GetWorksheet(string template)
        {
            string realPath = $"{TEMPLATE_PATH}{template}.xlsx";
            FileInfo fileInfo = new FileInfo(realPath);
            package = new ExcelPackage(fileInfo);
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();

            return worksheet;
        }

        public void Save(string path, string name)
        {
            package.SaveAs(new FileInfo($"{path}{name}.xlsx"));
        }
    }
}
