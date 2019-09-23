using OfficeOpenXml;
using System.IO;
using System.Reflection;

namespace ATV_Allowance.Helpers
{
    public class ExcelHelper
    {
        private readonly string EXT = @".xlsx";
        private ExcelPackage package;

        public ExcelPackage GetPackage(string template)
        {
            string realPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Templates/", template + EXT);

            FileInfo fileInfo = new FileInfo(realPath);
            package = new ExcelPackage(fileInfo);

            return package;
        }

        public void Save(string path, string name)
        {
            package.SaveAs(new FileInfo($"{path}{name}{EXT}"));
        }
    }
}
