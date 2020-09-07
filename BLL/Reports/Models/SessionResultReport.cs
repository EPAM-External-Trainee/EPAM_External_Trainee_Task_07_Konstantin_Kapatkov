using BLL.Reports.Abstract;
using BLL.Reports.Interfaces.SessionResultReport;
using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using BLL.Reports.Structs.ReportData;
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

        private IEnumerable<GroupTableRawView> GetGroupTableRowsData(int sessionId, int groupId)
        {
            List<GroupTableRawView> result = new List<GroupTableRawView>();
            result.AddRange(from st in Students
                            join sr in SessionResults on st.Id equals sr.StudentId
                            join s in Subjects on sr.SubjectId equals s.Id
                            join ss in SessionSchedules on st.GroupId equals ss.GroupId
                            join kaf in KnowledgeAssessmentForms on ss.KnowledgeAssessmentFormId equals kaf.Id
                            join g in Groups on st.GroupId equals g.Id
                            where ss.SubjectId == sr.SubjectId && ss.SessionId == sessionId && st.GroupId == groupId
                            select new GroupTableRawView(st.Name, st.Surname, st.Patronymic, s.Name, kaf.Form, ss.Date.ToShortDateString(), sr.Assessment));
            return result;
        }

        private IEnumerable<GroupSpecialtyTableRawView> GetGroupSpecialtyTableRawsData(int sessionId)
        {
            var sessionSpecialities = from g in Groups
                                      join st in Students on g.Id equals st.Id
                                      join sr in SessionResults on st.Id equals sr.StudentId
                                      join gs in GroupSpecialties on g.GroupSpecialtyId equals gs.Id
                                      select gs.Name;

            List<GroupSpecialtyTableRawView> result = new List<GroupSpecialtyTableRawView>();
            List<double> assessments = new List<double>();
            foreach (var specialty in sessionSpecialities.Distinct())
            {
                assessments.AddRange(from g in Groups
                                     join st in Students on g.Id equals st.GroupId
                                     join sr in SessionResults on st.Id equals sr.StudentId
                                     join ss in SessionSchedules on st.GroupId equals ss.GroupId
                                     join gs in GroupSpecialties on g.GroupSpecialtyId equals gs.Id
                                     where ss.SubjectId == sr.SubjectId && ss.KnowledgeAssessmentFormId == 1 && sr.SessionId == sessionId && gs.Name == specialty
                                     select double.Parse(sr.Assessment));
                result.Add(new GroupSpecialtyTableRawView(specialty, Math.Round(assessments.Average(), 2)));
                assessments.Clear();
            }

            return result;
        }

        private IEnumerable<ExaminersTableRawView> GetExaminersTableRawsData(int sessionId)
        {
            var sessionExaminers = from ss in SessionSchedules
                                   join ex in Examiners on ss.ExaminerId equals ex.Id
                                   where ss.SessionId == sessionId
                                   select ex;


            List<ExaminersTableRawView> result = new List<ExaminersTableRawView>();
            List<double> examinerAssessmnets = new List<double>();
            foreach (var examiner in sessionExaminers.Distinct())
            {
                examinerAssessmnets.AddRange(from g in Groups
                                             join st in Students on g.Id equals st.Id
                                             join sr in SessionResults on st.Id equals sr.StudentId
                                             join ss in SessionSchedules on g.Id equals ss.GroupId
                                             join ex in Examiners on ss.ExaminerId equals ex.Id
                                             where ss.KnowledgeAssessmentFormId == 1 && ex.Name == examiner.Name && ss.SubjectId == sr.SubjectId
                                             select double.Parse(sr.Assessment));

                result.Add(new ExaminersTableRawView(examiner.Surname, examiner.Name, examiner.Patronymic, Math.Round(examinerAssessmnets.Average(), 2)));
                examinerAssessmnets.Clear();
            }

            return result;
        }

        private string GetSessionInfo(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId).Name;

        public SessionResultReportData GetReportData(int sessionId)
        {
            Dictionary<string, List<GroupTableRawView>> groupTableDictionary = new Dictionary<string, List<GroupTableRawView>>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                groupTableDictionary.Add(Groups.FirstOrDefault(g => g.Id == groupId)?.Name, GetGroupTableRowsData(sessionId, groupId).ToList());
            }
            return new SessionResultReportData(groupTableDictionary, GetSessionInfo(sessionId), GetGroupSpecialtyTableRawsData(sessionId), GetExaminersTableRawsData(sessionId));
        }

        public SessionResultReportData GetReportData(int sessionId, Func<ExaminersTableRawView, object> predicate, bool isDescOrder = false)
        {
            Dictionary<string, List<GroupTableRawView>> groupTableDictionary = new Dictionary<string, List<GroupTableRawView>>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                groupTableDictionary.Add(Groups.FirstOrDefault(g => g.Id == groupId)?.Name, GetGroupTableRowsData(sessionId, groupId).ToList());
            }

            return isDescOrder ? new SessionResultReportData(groupTableDictionary, GetSessionInfo(sessionId), GetGroupSpecialtyTableRawsData(sessionId), GetExaminersTableRawsData(sessionId).OrderByDescending(predicate))
                : new SessionResultReportData(groupTableDictionary, GetSessionInfo(sessionId), GetGroupSpecialtyTableRawsData(sessionId), GetExaminersTableRawsData(sessionId).OrderBy(predicate));
        }

        public SessionResultReportData GetReportData(int sessionId, Func<GroupSpecialtyTableRawView, object> predicate, bool isDescOrder = false)
        {
            Dictionary<string, List<GroupTableRawView>> groupTableDictionary = new Dictionary<string, List<GroupTableRawView>>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                groupTableDictionary.Add(Groups.FirstOrDefault(g => g.Id == groupId)?.Name, GetGroupTableRowsData(sessionId, groupId).ToList());
            }

            return isDescOrder ? new SessionResultReportData(groupTableDictionary, GetSessionInfo(sessionId), GetGroupSpecialtyTableRawsData(sessionId).OrderByDescending(predicate), GetExaminersTableRawsData(sessionId))
                : new SessionResultReportData(groupTableDictionary, GetSessionInfo(sessionId), GetGroupSpecialtyTableRawsData(sessionId).OrderBy(predicate), GetExaminersTableRawsData(sessionId));
        }

        public SessionResultReportData GetReportData(int sessionId, Func<GroupTableRawView, object> predicate, bool isDescOrder = false)
        {
            Dictionary<string, List<GroupTableRawView>> groupTableDictionary = new Dictionary<string, List<GroupTableRawView>>();
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

            return new SessionResultReportData(groupTableDictionary, GetSessionInfo(sessionId), GetGroupSpecialtyTableRawsData(sessionId), GetExaminersTableRawsData(sessionId));
        }
    }
}