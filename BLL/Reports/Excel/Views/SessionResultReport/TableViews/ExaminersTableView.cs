using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews;
using BLL.Reports.Excel.Views.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Views.SessionResultReport.TableView
{
    /// <summary>Class describing the view of the examiners table</summary>
    public class ExaminersTableView : IExaminersTableView
    {
        /// <summary>Default constructor</summary>
        public ExaminersTableView()
        {
        }

        /// <summary>Creating an instance of <see cref="ExaminersTableView"/> via table raw views</summary>
        /// <param name="tableRawViews">Table raw views</param>
        public ExaminersTableView(IEnumerable<ExaminersTableRowView> tableRawViews) => TableRowViews = tableRawViews;

        /// <inheritdoc cref="IExaminersTableView.Headers"/>
        public string[] Headers { get; } = { "Surname", "Name", "Patronymic", "Average assessment" };

        /// <inheritdoc cref="IExaminersTableView.TableRowViews"/>
        public IEnumerable<ExaminersTableRowView> TableRowViews { get; set; }
    }
}