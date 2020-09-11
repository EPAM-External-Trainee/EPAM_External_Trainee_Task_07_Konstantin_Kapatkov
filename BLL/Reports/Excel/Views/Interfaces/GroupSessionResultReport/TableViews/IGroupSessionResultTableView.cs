using BLL.Reports.Structs.ExcelTableRawViews.GroupSessionResultReport;
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