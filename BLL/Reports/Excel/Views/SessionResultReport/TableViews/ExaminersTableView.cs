using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews;
using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.ExcelViews.SessionResultReport.TableView
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