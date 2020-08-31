using BLL.Reports.Interfaces.SessionResultReport;

namespace BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport
{
    public struct GroupSpecialtyTableRawView : IGroupSpecialtyTableRawView
    {
        public string SpecialityName { get; set; }

        public string AverageAssessment { get; set; }
    }
}