using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews;
using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.ExcelViews.SessionResultReport.TableView
{
    public class GroupTableView : IGroupTableView
    {
        public GroupTableView()
        {
        }

        public GroupTableView(IEnumerable<GroupTableRawView> tableRawViews, string groupName, string sessionName) => (TableRawViews, GroupName, SessionName) = (tableRawViews, groupName, sessionName);

        public string[] Headers { get; } = { "Surname", "Name", "Patronymic", "Subject", "Form", "Date", "Assessment" };

        public IEnumerable<GroupTableRawView> TableRawViews { get; set; }

        public string GroupName { get; set; }

        public string SessionName { get; set; }
    }
}