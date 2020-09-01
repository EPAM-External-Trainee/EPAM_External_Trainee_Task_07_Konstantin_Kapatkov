using BLL.Reports.Interfaces.SessionResultReport;
using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Structs.ReportData
{
    public struct SessionResultReportData : ISessionResultReportData
    {
        public SessionResultReportData(Dictionary<string, List<GroupTableRawView>> groupTableRawViews, string sessionInfo, IEnumerable<GroupSpecialtyTableRawView> groupSpecialtyTableRawViews, IEnumerable<ExaminersTableRawView> examinersTableRawViews)
        {
            GroupTableRawViews = groupTableRawViews;
            SessionInfo = sessionInfo;
            GroupSpecialtyTableRawViews = groupSpecialtyTableRawViews;
            ExaminersTableRawViews = examinersTableRawViews;
        }

        public Dictionary<string, List<GroupTableRawView>> GroupTableRawViews { get; set; }

        public IEnumerable<GroupSpecialtyTableRawView> GroupSpecialtyTableRawViews { get; set; }

        public IEnumerable<ExaminersTableRawView> ExaminersTableRawViews { get; set; }

        public string SessionInfo { get; set; }

        public override bool Equals(object obj) => obj is SessionResultReportData data && GroupTableRawViews.SequenceEqual(data.GroupTableRawViews)
            && SessionInfo == data.SessionInfo && GroupSpecialtyTableRawViews.SequenceEqual(data.GroupSpecialtyTableRawViews)
            && ExaminersTableRawViews.SequenceEqual(data.ExaminersTableRawViews);

        public override int GetHashCode()
        {
            int hashCode = -1930975380;
            hashCode = hashCode * -1521134295 + GroupTableRawViews.GetHashCode();
            hashCode = hashCode * -1521134295 + SessionInfo.GetHashCode();
            hashCode = hashCode * -1521134295 + GroupSpecialtyTableRawViews.GetHashCode();
            hashCode = hashCode * -1521134295 + ExaminersTableRawViews.GetHashCode();
            return hashCode;
        }
    }
}