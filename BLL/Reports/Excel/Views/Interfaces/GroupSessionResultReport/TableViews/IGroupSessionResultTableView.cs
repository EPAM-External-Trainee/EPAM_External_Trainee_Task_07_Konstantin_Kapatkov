using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRawViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews
{
    public interface IGroupSessionResultTableView
    {
        string[] Headers { get; }

        IEnumerable<GroupSessionResultTableRawView> TableRowViews { get; set; }

        string SessionName { get; set; }

        string AcademicYear { get; set; }
    }
}