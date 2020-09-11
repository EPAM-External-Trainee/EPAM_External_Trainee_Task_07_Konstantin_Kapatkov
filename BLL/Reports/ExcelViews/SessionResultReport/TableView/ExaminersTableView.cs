using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.ExcelViews.SessionResultReport.TableView
{
    public class ExaminersTableView
    {
        public ExaminersTableView()
        {
        }

        public ExaminersTableView(IEnumerable<ExaminersTableRawView> tableRawViews) => TableRawViews = tableRawViews;

        public string[] Headers { get; } = new string[] { "Surname", "Name", "Patronymic", "Average assessment" };

        public IEnumerable<ExaminersTableRawView> TableRawViews { get; set; }
    }
}