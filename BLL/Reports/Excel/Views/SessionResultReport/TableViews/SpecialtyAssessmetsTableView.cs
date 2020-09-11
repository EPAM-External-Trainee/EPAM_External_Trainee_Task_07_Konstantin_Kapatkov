using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews;
using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.ExcelViews.SessionResultReport.TableView
{
    public class SpecialtyAssessmetsTableView : ISpecialtyAssessmetsTableView
    {
        public SpecialtyAssessmetsTableView()
        {
        }

        public SpecialtyAssessmetsTableView(IEnumerable<SpecialtyAssessmetsTableRawView> tableRawViews) => TableRawViews = tableRawViews;

        public string[] Headers { get; } = { "Specialty", "Average assessment" };

        public IEnumerable<SpecialtyAssessmetsTableRawView> TableRawViews { get; set; }
    }
}