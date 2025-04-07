using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML;
using ClosedXML.Excel;

namespace Streamove
{
    public class ExcelTXT : ILog
    {
        private List<string> data = new List<string>();
        string filepath;
        public ExcelTXT(string filepath)
        {
            this.filepath = filepath;
        }
        public void PrintLogger()
        {
            using (var workbook = new XLWorkbook(filepath))
            {
                var worksheet = workbook.Worksheets.Worksheet("Logger");

                foreach (var row in worksheet.RowsUsed())
                {
                    Console.WriteLine(row.Cell(1).Value);
                }
            }
        }

        public void Save(string message)
        {
            this.data.Add(message);
        }

        public void Write()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.AddWorksheet("Logger");

                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cell(i + 1, 1).Value = data[i];
                    worksheet.Cell(i+1, 1).Style.Font.SetBold(true);
                }

                workbook.SaveAs(filepath);
            }
        }
    }
}
