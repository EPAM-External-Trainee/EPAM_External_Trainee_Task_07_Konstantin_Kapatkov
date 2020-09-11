using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.ExcelViews.SessionResultReport.TableView
{
    public class SpecialtyAssessmetsTableView
    {
        public SpecialtyAssessmetsTableView()
        {
        }

        public SpecialtyAssessmetsTableView(IEnumerable<GroupSpecialtyTableRawView> tableRawViews) => TableRawViews = tableRawViews;

        public string[] Headers { get; } = new string[] { "Specialty", "Average assessment" };

        public IEnumerable<GroupSpecialtyTableRawView> TableRawViews { get; set; }
    }
}