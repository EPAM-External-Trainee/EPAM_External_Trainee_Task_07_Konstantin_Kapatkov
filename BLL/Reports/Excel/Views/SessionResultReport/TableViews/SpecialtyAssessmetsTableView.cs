using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews;
using BLL.Reports.Excel.Views.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Views.SessionResultReport.TableView
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