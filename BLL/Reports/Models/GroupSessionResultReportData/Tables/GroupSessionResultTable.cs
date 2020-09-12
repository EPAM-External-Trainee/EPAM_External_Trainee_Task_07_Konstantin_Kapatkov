using BLL.Reports.Abstract;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRawViews;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews;
using BLL.Reports.Interfaces.GroupSessionResultReport;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Models
{
    public class GroupSessionResultTable : Report, IGroupSessionResultTable
    {
        public GroupSessionResultTable(string connectionString) : base(connectionString)
        {
        }

        private IEnumerable<double> GetGroupMarks(int sessionId, int groupId)
        {
            return from sr in SessionResults
                   join st in Students on sr.StudentId equals st.Id
                   join g in Groups on st.GroupId equals g.Id
                   join ss in SessionSchedules on st.GroupId equals ss.GroupId
                   where g.Id == groupId && ss.KnowledgeAssessmentFormId == 1 && ss.SubjectId == sr.SubjectId && ss.SessionId == sessionId
                   select double.Parse(sr.Assessment);
        }

        private IEnumerable<GroupSessionResultTableRawView> GetRowData(int sessionId)
        {
            List<GroupSessionResultTableRawView> result = new List<GroupSessionResultTableRawView>();
            Dictionary<string, List<double>> tmp = new Dictionary<string, List<double>>();

            foreach (var group in Groups)
            {
                List<double> groupMarks = new List<double>();
                groupMarks.AddRange(GetGroupMarks(sessionId, group.Id));
                tmp.Add(group.Name, groupMarks);
            }

            result.AddRange(tmp.Select(t => new GroupSessionResultTableRawView(t.Key, t.Value.Max(), t.Value.Min(), Math.Round(t.Value.Average(), 1))));
            return result;
        }

        private string GetSessionName(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId)?.Name;

        private string GetSessionAcademicYear(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId)?.AcademicYear;

        public IEnumerable<GroupSessionResultTableView> GetGroupSessionResultTables() => Sessions.Select(session => new GroupSessionResultTableView(GetRowData(session.Id), GetSessionName(session.Id), GetSessionAcademicYear(session.Id)));

        public IEnumerable<GroupSessionResultTableView> GetGroupSessionResultTables(Func<GroupSessionResultTableRawView, object> predicate, bool isDescOrder = false)
        {
            List<GroupSessionResultTableView> result = new List<GroupSessionResultTableView>();
            foreach (var session in Sessions)
            {
                if (isDescOrder)
                {
                    result.Add(new GroupSessionResultTableView(GetRowData(session.Id).OrderByDescending(predicate), GetSessionName(session.Id), GetSessionAcademicYear(session.Id)));
                }
                else
                {
                    result.Add(new GroupSessionResultTableView(GetRowData(session.Id).OrderBy(predicate), GetSessionName(session.Id), GetSessionAcademicYear(session.Id)));
                }
            }

            return result;
        }
    }
}