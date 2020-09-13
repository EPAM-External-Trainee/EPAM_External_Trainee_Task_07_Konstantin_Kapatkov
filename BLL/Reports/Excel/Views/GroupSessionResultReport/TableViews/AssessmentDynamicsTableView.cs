using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRawViews;
using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews
{
    /// <summary>Class describing the view of the assessment dynamics table</summary>
    public class AssessmentDynamicsTableView : IAssessmentDynamicsTableView
    {
        /// <summary>Default constructor</summary>
        public AssessmentDynamicsTableView()
        {
        }

        /// <summary>Creating an instance of <see cref="AssessmentDynamicsTableView"/> via table row views and academic years</summary>
        /// <param name="tableRowViews">Table row views</param>
        /// <param name="academicYears">Academic years</param>
        public AssessmentDynamicsTableView(IEnumerable<AssessmentDynamicsTableRowView> tableRowViews, IEnumerable<string> academicYears)
        {
            AcademicYears = academicYears;
            TableRowViews = tableRowViews;
        }

        /// <inheritdoc cref="IAssessmentDynamicsTableView.Headers"/>
        public string[] Headers { get; } = { "Subject", "Assessment" };

        /// <inheritdoc cref="IAssessmentDynamicsTableView.AcademicYears"/>
        public IEnumerable<string> AcademicYears { get; set; }

        /// <inheritdoc cref="IAssessmentDynamicsTableView.TableRowViews"/>
        public IEnumerable<AssessmentDynamicsTableRowView> TableRowViews { get; set; }
    }
}