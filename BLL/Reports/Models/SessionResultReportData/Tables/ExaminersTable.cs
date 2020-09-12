using BLL.Reports.Abstract;
using BLL.Reports.Excel.Views.SessionResultReport;
using BLL.Reports.Interfaces.SessionResultReport;
using BLL.Reports.Views.SessionResultReport.TableView;
using DAL.ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Models.SessionResultReportData.Tables
{
    public class ExaminersTable : Report, IExaminersTable
    {
        public ExaminersTable(string connectionString) : base(connectionString)
        {
        }

        private IEnumerable<Examiner> GetSessionExaminers(int sessionId)
        {
            return from ss in SessionSchedules
                   join ex in Examiners on ss.ExaminerId equals ex.Id
                   where ss.SessionId == sessionId && ss.KnowledgeAssessmentFormId == 1
                   select ex;
        }

        private IEnumerable<double> GetExaminerAssessmnets(int sessionId, int examinerId)
        {
            return from g in Groups
                   join st in Students on g.Id equals st.GroupId
                   join sr in SessionResults on st.Id equals sr.StudentId
                   join ss in SessionSchedules on st.GroupId equals ss.GroupId
                   join ex in Examiners on ss.ExaminerId equals ex.Id
                   where ss.KnowledgeAssessmentFormId == 1 && ex.Id == examinerId && ss.SubjectId == sr.SubjectId && ss.SessionId == sessionId
                   select double.Parse(sr.Assessment);
        }

        private IEnumerable<ExaminersTableRawView> GetExaminersTableRawsData(int sessionId)
        {
            IEnumerable<Examiner> sessionExaminers = GetSessionExaminers(sessionId).Distinct();
            List<ExaminersTableRawView> result = new List<ExaminersTableRawView>();
            List<double> examinerAssessmnets = new List<double>();

            foreach (var examiner in sessionExaminers)
            {
                examinerAssessmnets.AddRange(GetExaminerAssessmnets(sessionId, examiner.Id));
                result.Add(new ExaminersTableRawView(examiner.Surname, examiner.Name, examiner.Patronymic, Math.Round(examinerAssessmnets.Average(), 2)));
                examinerAssessmnets.Clear();
            }

            return result;
        }

        public ExaminersTableView GetExaminersTableData(int sessionId) => new ExaminersTableView(GetExaminersTableRawsData(sessionId));

        public ExaminersTableView GetExaminersTableData(int sessionId, Func<ExaminersTableRawView, object> predicate, bool isDescOrder) => isDescOrder ? new ExaminersTableView(GetExaminersTableRawsData(sessionId).OrderByDescending(predicate)) : new ExaminersTableView(GetExaminersTableRawsData(sessionId).OrderBy(predicate));
    }
}