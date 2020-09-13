using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRawViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews
{
    /// <summary>Interface describing the view of the assessment dynamics table</summary>
    public interface IAssessmentDynamicsTableView
    {
        /// <summary>Table headers</summary>
        string[] Headers { get; }

        /// <summary>Academic years</summary>
        IEnumerable<string> AcademicYears { get; set; }

        /// <summary><see cref="AssessmentDynamicsTableRowView"/> objects as row views</summary>
        IEnumerable<AssessmentDynamicsTableRowView> TableRowViews { get; set; }
    }
}