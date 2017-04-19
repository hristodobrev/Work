using System;
using System.Collections.Generic;
using System.Dynamic;

class ExportingDataToExcel
{
    public class SampleObject : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = binder.Name;
            return true;
        }
    }

    static void Main()
    {
        var entities = new List<dynamic>
        {
            new
            {
                ColumnA = 1,
                ColumnB = "Foo"
            },
            new
            {
                ColumnA = 2,
                ColumnB = "Bar"
            }
        };

        // DisplayInExcel(entities);

        dynamic obj = new SampleObject();
        Console.WriteLine(obj.Babeh21tfgw);
    }

    static void DisplayInExcel(IEnumerable<dynamic> entities)
    {
        var excelApp = new Microsoft.Office.Interop.Excel.Application();
        excelApp.Visible = true;

        excelApp.Workbooks.Add();

        dynamic workSheet = excelApp.ActiveSheet;

        workSheet.Cells[1, "A"] = "Header A";
        workSheet.Cells[1, "B"] = "Header B";

        var row = 1;
        foreach (var entity in entities)
        {
            row++;
            workSheet.Cells[row, "A"] = entity.ColumnA;
            workSheet.Cells[row, "B"] = entity.ColumnB;
        }

        workSheet.Columns[1].AutoFit();
        workSheet.Columns[2].AutoFit();
    }
}