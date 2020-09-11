using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRawViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews
{
    public interface IAssessmentDynamicsTableView
    {
        string[] Headers { get; }

        IEnumerable<string> AcademicYears { get; set; }

        IEnumerable<AssessmentDynamicsTableRowView> TableRowViews { get; set; }
    }
}