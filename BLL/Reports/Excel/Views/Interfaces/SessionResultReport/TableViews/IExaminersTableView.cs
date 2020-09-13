using BLL.Reports.Excel.Views.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews
{
    /// <summary>Interface describing the view of the examiners table</summary>
    public interface IExaminersTableView
    {
        /// <summary>Table headers</summary>
        string[] Headers { get; }

        /// <summary><see cref="ExaminersTableRowView"/> objects as table row views</summary>
        IEnumerable<ExaminersTableRowView> TableRowViews { get; set; }
    }
}