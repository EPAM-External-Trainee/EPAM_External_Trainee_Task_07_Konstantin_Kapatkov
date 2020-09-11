using BLL.Reports.Structs.ExcelTableRawViews.GroupSessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Structs.ExcelTableView.GroupSessionResultReport
{
    public class GroupSessionResultTableView
    {
        public readonly string[] Headers = new string[] { "Group name", "Max assessment", "Min assessment", "Average assessment" };

        public GroupSessionResultTableView(IEnumerable<GroupSessionResultTableRawView> tableRowViews, string sessionName, string academicYear)
        {
            TableRowViews = tableRowViews;
            SessionName = sessionName;
            AcademicYear = academicYear;
        }

        public IEnumerable<GroupSessionResultTableRawView> TableRowViews { get; set; }

        public string SessionName { get; set; }

        public string AcademicYear { get; set; }
    }
}