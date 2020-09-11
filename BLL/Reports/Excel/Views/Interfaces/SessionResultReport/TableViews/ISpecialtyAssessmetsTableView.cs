using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews
{
    public interface ISpecialtyAssessmetsTableView
    {
        string[] Headers { get; }

        IEnumerable<SpecialtyAssessmetsTableRawView> TableRawViews { get; set; }
    }
}