using BLL.Reports.Interfaces.GroupSessionResultReport;

namespace BLL.Reports.Structs.ExcelTableRawViews.GroupSessionResultReport
{
    public struct GroupSessionResultTableRawView : IGroupSessionResultTableRawView
    {
        public GroupSessionResultTableRawView(string groupName, double maxAssessment, double minAssessment, double avgAssessment)
        {
            GroupName = groupName;
            MaxAssessment = maxAssessment;
            MinAssessment = minAssessment;
            AvgAssessment = avgAssessment;
        }

        public string GroupName { get; set; }

        public double MaxAssessment { get; set; }

        public double MinAssessment { get; set; }

        public double AvgAssessment { get; set; }

        public override bool Equals(object obj) => obj is GroupSessionResultTableRawView view && GroupName == view.GroupName && MaxAssessment == view.MaxAssessment && MinAssessment == view.MinAssessment && AvgAssessment == view.AvgAssessment;

        public override int GetHashCode()
        {
            int hashCode = -1239856536;
            hashCode = (hashCode * -1521134295) + GroupName.GetHashCode();
            hashCode = (hashCode * -1521134295) + MaxAssessment.GetHashCode();
            hashCode = (hashCode * -1521134295) + MinAssessment.GetHashCode();
            hashCode = (hashCode * -1521134295) + AvgAssessment.GetHashCode();
            return hashCode;
        }
    }
}