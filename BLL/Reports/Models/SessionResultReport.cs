using BLL.Reports.Abstract;
using BLL.Reports.Interfaces.SessionResultReport;
using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using BLL.Reports.Structs.ReportData;
using DAL.ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Models
{
    public class SessionResultReport : Report, ISessionResultReport
    {
        public SessionResultReport(string connectionString) : base(connectionString)
        {
        }

        private IEnumerable<string> GetGroupSpecialities(int sessionId)
        {
            return from g in Groups
                   join st in Students on g.Id equals st.Id
                   join sr in SessionResults on st.Id equals sr.StudentId
                   join gs in GroupSpecialties on g.GroupSpecialtyId equals gs.Id
                   join ss in SessionSchedules on sessionId equals ss.SessionId
                   where ss.GroupId == g.Id
                   select gs.Name;
        }

        private IEnumerable<Examiner> GetSessionExaminers(int sessionId)
        {
            return from ss in SessionSchedules
                   join ex in Examiners on ss.ExaminerId equals ex.Id
                   where ss.SessionId == sessionId
                   select ex;
        }

        private IEnumerable<double> GetExaminerAssessmnets(int examinerId)
        {
            return from g in Groups
                   join st in Students on g.Id equals st.Id
                   join sr in SessionResults on st.Id equals sr.StudentId
                   join ss in SessionSchedules on g.Id equals ss.GroupId
                   join ex in Examiners on ss.ExaminerId equals ex.Id
                   where ss.KnowledgeAssessmentFormId == 1 && ex.Id == examinerId && ss.SubjectId == sr.SubjectId
                   select double.Parse(sr.Assessment);
        }

        private IEnumerable<GroupTableRawView> GetGroupTableRawView(int sessionId, int groupId)
        {
            return from st in Students
                   join sr in SessionResults on st.Id equals sr.StudentId
                   join s in Subjects on sr.SubjectId equals s.Id
                   join ss in SessionSchedules on st.GroupId equals ss.GroupId
                   join kaf in KnowledgeAssessmentForms on ss.KnowledgeAssessmentFormId equals kaf.Id
                   join g in Groups on st.GroupId equals g.Id
                   where ss.SubjectId == sr.SubjectId && ss.SessionId == sessionId && st.GroupId == groupId
                   select new GroupTableRawView(st.Name, st.Surname, st.Patronymic, s.Name, kaf.Form, ss.Date.ToShortDateString(), sr.Assessment);
        }

        private IEnumerable<GroupTableRawView> GetGroupTableRowsData(int sessionId, int groupId)
        {
            List<GroupTableRawView> result = new List<GroupTableRawView>();
            result.AddRange(GetGroupTableRawView(sessionId, groupId));
            return result;
        }

        private IEnumerable<double> GetAssessments(int sessionId, string specialtyName)
        {
            return from g in Groups
                   join st in Students on g.Id equals st.GroupId
                   join sr in SessionResults on st.Id equals sr.StudentId
                   join ss in SessionSchedules on st.GroupId equals ss.GroupId
                   join gs in GroupSpecialties on g.GroupSpecialtyId equals gs.Id
                   where ss.SubjectId == sr.SubjectId && ss.KnowledgeAssessmentFormId == 1 && sr.SessionId == sessionId && gs.Name == specialtyName
                   select double.Parse(sr.Assessment);
        }

        private IEnumerable<GroupSpecialtyTableRawView> GetGroupSpecialtyTableRawsData(int sessionId)
        {
            IEnumerable<string> groupSpecialities = GetGroupSpecialities(sessionId).Distinct();
            List<GroupSpecialtyTableRawView> result = new List<GroupSpecialtyTableRawView>();
            List<double> assessments = new List<double>();

            foreach (var specialty in groupSpecialities)
            {
                assessments.AddRange(GetAssessments(sessionId, specialty));
                result.Add(new GroupSpecialtyTableRawView(specialty, Math.Round(assessments.Average(), 2)));
                assessments.Clear();
            }

            return result;
        }

        private IEnumerable<ExaminersTableRawView> GetExaminersTableRawsData(int sessionId)
        {
            IEnumerable<Examiner> sessionExaminers = GetSessionExaminers(sessionId).Distinct();
            List<ExaminersTableRawView> result = new List<ExaminersTableRawView>();
            List<double> examinerAssessmnets = new List<double>();

            foreach (var examiner in sessionExaminers)
            {
                examinerAssessmnets.AddRange(GetExaminerAssessmnets(examiner.Id));
                result.Add(new ExaminersTableRawView(examiner.Surname, examiner.Name, examiner.Patronymic, Math.Round(examinerAssessmnets.Average(), 2)));
                examinerAssessmnets.Clear();
            }

            return result;
        }

        private string GetSessionInfo(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId).Name;

        private Dictionary<string, IEnumerable<GroupTableRawView>> GetGroupTableDictionary(int sessionId)
        {
            Dictionary<string, IEnumerable<GroupTableRawView>> groupTableDictionary = new Dictionary<string, IEnumerable<GroupTableRawView>>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                groupTableDictionary.Add(Groups.FirstOrDefault(g => g.Id == groupId)?.Name, GetGroupTableRowsData(sessionId, groupId).ToList());
            }
            return groupTableDictionary;
        }

        private Dictionary<string, IEnumerable<GroupTableRawView>> GetGroupTableDictionary(int sessionId, Func<GroupTableRawView, object> predicate, bool isDescOrder = false)
        {
            Dictionary<string, IEnumerable<GroupTableRawView>> groupTableDictionary = new Dictionary<string, IEnumerable<GroupTableRawView>>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                if (isDescOrder)
                {
                    groupTableDictionary.Add(Groups.FirstOrDefault(g => g.Id == groupId)?.Name, GetGroupTableRowsData(sessionId, groupId).OrderByDescending(predicate).ToList());
                }
                else
                {
                    groupTableDictionary.Add(Groups.FirstOrDefault(g => g.Id == groupId)?.Name, GetGroupTableRowsData(sessionId, groupId).OrderBy(predicate).ToList());
                }
            }
            return groupTableDictionary;
        }

        public SessionResultReportData GetReportData(int sessionId)
        {
            Dictionary<string, List<GroupTableRawView>> groupTableDictionary = new Dictionary<string, List<GroupTableRawView>>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                groupTableDictionary.Add(Groups.FirstOrDefault(g => g.Id == groupId)?.Name, GetGroupTableRowsData(sessionId, groupId).ToList());
            }
            return new SessionResultReportData(GetGroupTableDictionary(sessionId), GetSessionInfo(sessionId), GetGroupSpecialtyTableRawsData(sessionId), GetExaminersTableRawsData(sessionId));
        }

        public SessionResultReportData GetReportData(int sessionId, Func<ExaminersTableRawView, object> predicate, bool isDescOrder = false)
        {
            return isDescOrder ? new SessionResultReportData(GetGroupTableDictionary(sessionId), GetSessionInfo(sessionId), GetGroupSpecialtyTableRawsData(sessionId), GetExaminersTableRawsData(sessionId).OrderByDescending(predicate))
                : new SessionResultReportData(GetGroupTableDictionary(sessionId), GetSessionInfo(sessionId), GetGroupSpecialtyTableRawsData(sessionId), GetExaminersTableRawsData(sessionId).OrderBy(predicate));
        }

        public SessionResultReportData GetReportData(int sessionId, Func<GroupSpecialtyTableRawView, object> predicate, bool isDescOrder = false)
        {
            return isDescOrder ? new SessionResultReportData(GetGroupTableDictionary(sessionId), GetSessionInfo(sessionId), GetGroupSpecialtyTableRawsData(sessionId).OrderByDescending(predicate), GetExaminersTableRawsData(sessionId))
                : new SessionResultReportData(GetGroupTableDictionary(sessionId), GetSessionInfo(sessionId), GetGroupSpecialtyTableRawsData(sessionId).OrderBy(predicate), GetExaminersTableRawsData(sessionId));
        }

        public SessionResultReportData GetReportData(int sessionId, Func<GroupTableRawView, object> predicate, bool isDescOrder = false)
        {
            return new SessionResultReportData(GetGroupTableDictionary(sessionId, predicate, isDescOrder), GetSessionInfo(sessionId), GetGroupSpecialtyTableRawsData(sessionId), GetExaminersTableRawsData(sessionId));
        }
    }
}