using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRawViews;
using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews
{
    public class GroupSessionResultTableView : IGroupSessionResultTableView
    {
        public GroupSessionResultTableView(IEnumerable<GroupSessionResultTableRawView> tableRowViews, string sessionName, string academicYear)
        {
            TableRowViews = tableRowViews;
            SessionName = sessionName;
            AcademicYear = academicYear;
        }

        public string[] Headers { get; } = { "Group name", "Max assessment", "Min assessment", "Average assessment" };

        public IEnumerable<GroupSessionResultTableRawView> TableRowViews { get; set; }

        public string SessionName { get; set; }

        public string AcademicYear { get; set; }
    }
}