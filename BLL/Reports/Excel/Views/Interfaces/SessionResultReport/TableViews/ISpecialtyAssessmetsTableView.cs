using BLL.Reports.Excel.Views.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews
{
    /// <summary>Interface describing the view of the specialty assessmets table</summary>
    public interface ISpecialtyAssessmetsTableView
    {
        /// <summary>Table headers</summary>
        string[] Headers { get; }

        /// <summary><see cref="SpecialtyAssessmetsTableRowView"/> objects as table raw views</summary>
        IEnumerable<SpecialtyAssessmetsTableRowView> TableRawViews { get; set; }
    }
}