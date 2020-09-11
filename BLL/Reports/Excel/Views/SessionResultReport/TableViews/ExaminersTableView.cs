using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews;
using BLL.Reports.Excel.Views.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Views.SessionResultReport.TableView
{
    public class ExaminersTableView : IExaminersTableView
    {
        public ExaminersTableView()
        {
        }

        public ExaminersTableView(IEnumerable<ExaminersTableRawView> tableRawViews) => TableRawViews = tableRawViews;

        public string[] Headers { get; } = { "Surname", "Name", "Patronymic", "Average assessment" };

        public IEnumerable<ExaminersTableRawView> TableRawViews { get; set; }
    }
}