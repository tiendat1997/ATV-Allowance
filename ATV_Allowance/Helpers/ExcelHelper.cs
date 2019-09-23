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

        public ExcelPackage GetPackage(string template)
        {
            string realPath = $"{TEMPLATE_PATH}{template}.xlsx";
            FileInfo fileInfo = new FileInfo(realPath);
            package = new ExcelPackage(fileInfo);
          
            return package;
        }

        public void Save(string path, string name)
        {
            package.SaveAs(new FileInfo($"{path}{name}.xlsx"));
        }
    }
}
