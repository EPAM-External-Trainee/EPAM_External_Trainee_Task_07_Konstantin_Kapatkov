using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews;
using System.Collections.Generic;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRawViews;

namespace BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews
{
    public class AssessmentDynamicsTableView : IAssessmentDynamicsTableView
    {
        public AssessmentDynamicsTableView()
        {
        }

        public AssessmentDynamicsTableView(IEnumerable<AssessmentDynamicsTableRowView> tableRowViews, IEnumerable<string> academicYears)
        {
            AcademicYears = academicYears;
            TableRowViews = tableRowViews;
        }

        public string[] Headers { get; } = { "Subject", "Assessment" };

        public IEnumerable<string> AcademicYears { get; set; }

        public IEnumerable<AssessmentDynamicsTableRowView> TableRowViews { get; set; }
    }
}