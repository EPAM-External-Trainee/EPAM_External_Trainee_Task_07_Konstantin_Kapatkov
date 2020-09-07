using BLL.Reports.Interfaces.GroupSessionResultReport;
using BLL.Reports.Structs.ExcelTableRawViews.DynamicChangesInAverageMark;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Structs.ReportData
{
    public class AssessmentDynamicsReportData : IAssessmentDynamicsReportData
    {
        public AssessmentDynamicsReportData()
        {
        }

        public AssessmentDynamicsReportData(IEnumerable<AssessmentDynamicsTableRowView> tableRowViews, IEnumerable<string> years)
        {
            TableRowViews = tableRowViews;
            AcademicYears = years;
        }

        public IEnumerable<AssessmentDynamicsTableRowView> TableRowViews { get; set; }

        public IEnumerable<string> AcademicYears { get; set; }

        public override bool Equals(object obj) => obj is AssessmentDynamicsReportData data && TableRowViews.SequenceEqual(data.TableRowViews) && AcademicYears.SequenceEqual(data.AcademicYears);

        public override int GetHashCode()
        {
            int hashCode = -294578147;
            hashCode = hashCode * -1521134295 + TableRowViews.GetHashCode();
            hashCode = hashCode * -1521134295 + AcademicYears.GetHashCode();
            return hashCode;
        }
    }
}