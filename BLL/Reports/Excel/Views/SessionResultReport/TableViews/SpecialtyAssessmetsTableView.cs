using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews;
using BLL.Reports.Excel.Views.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Views.SessionResultReport.TableView
{
    /// <summary>Class describing the view of the specialty assessmets table</summary>
    public class SpecialtyAssessmetsTableView : ISpecialtyAssessmetsTableView
    {
        /// <summary>Default constructor</summary>
        public SpecialtyAssessmetsTableView()
        {
        }

        /// <summary>Creating an isntance of <see cref="SpecialtyAssessmetsTableView"/> via table raw views</summary>
        /// <param name="tableRawViews"></param>
        public SpecialtyAssessmetsTableView(IEnumerable<SpecialtyAssessmetsTableRowView> tableRawViews) => TableRawViews = tableRawViews;

        /// <inheritdoc cref="ISpecialtyAssessmetsTableView.Headers"/>
        public string[] Headers { get; } = { "Specialty", "Average assessment" };

        /// <inheritdoc cref="ISpecialtyAssessmetsTableView.TableRawViews"/>
        public IEnumerable<SpecialtyAssessmetsTableRowView> TableRawViews { get; set; }
    }
}