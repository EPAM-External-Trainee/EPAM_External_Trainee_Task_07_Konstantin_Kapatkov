using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews
{
    public interface IGroupTableView
    {
        string[] Headers { get; }

        IEnumerable<GroupTableRawView> TableRawViews { get; set; }

        string GroupName { get; set; }

        string SessionName { get; set; }
    }
}