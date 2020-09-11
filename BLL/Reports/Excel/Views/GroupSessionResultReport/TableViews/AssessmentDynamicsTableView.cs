using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews;
using BLL.Reports.Structs.ExcelTableRawViews.DynamicChangesInAverageMark;
using System.Collections.Generic;

namespace BLL.Reports.ExcelViews.ExcelTableView.GroupSessionResultReport
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