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
    /// <summary>Class describing examiners table functionality</summary>
    public class ExaminersTable : Report, IExaminersTable
    {
        /// <summary>Creating an instance of <see cref="ExaminersTable"/> via connection string</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public ExaminersTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>Getting session examiners</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns><see cref="IEnumerable{Examiner}"/> examiners</returns>
        private IEnumerable<Examiner> GetSessionExaminers(int sessionId)
        {
            return from ss in SessionSchedules
                   join ex in Examiners on ss.ExaminerId equals ex.Id
                   where ss.SessionId == sessionId && ss.KnowledgeAssessmentFormId == 1
                   select ex;
        }

        /// <summary>Getting examiner assessmnets</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="examinerId">Examiner id</param>
        /// <returns><see cref="IEnumerable{double}"/> examiner assessmnets</returns>
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

        /// <summary>Getting examiners table raws data</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns><see cref="IEnumerable{ExaminersTableRowView}"/> examiners table raws data</returns>
        private IEnumerable<ExaminersTableRowView> GetExaminersTableRawsData(int sessionId)
        {
            IEnumerable<Examiner> sessionExaminers = GetSessionExaminers(sessionId).Distinct();
            List<ExaminersTableRowView> result = new List<ExaminersTableRowView>();
            List<double> examinerAssessmnets = new List<double>();

            foreach (var examiner in sessionExaminers)
            {
                examinerAssessmnets.AddRange(GetExaminerAssessmnets(sessionId, examiner.Id));
                result.Add(new ExaminersTableRowView(examiner.Surname, examiner.Name, examiner.Patronymic, Math.Round(examinerAssessmnets.Average(), 2)));
                examinerAssessmnets.Clear();
            }

            return result;
        }

        /// <inheritdoc cref="IExaminersTable.GetExaminersTableData(int)"/>
        public ExaminersTableView GetExaminersTableData(int sessionId) => new ExaminersTableView(GetExaminersTableRawsData(sessionId));

        /// <inheritdoc cref="IExaminersTable.GetExaminersTableData(int, Func{ExaminersTableRowView, object}, bool)"/>
        public ExaminersTableView GetExaminersTableData(int sessionId, Func<ExaminersTableRowView, object> predicate, bool isDescOrder) => isDescOrder ? new ExaminersTableView(GetExaminersTableRawsData(sessionId).OrderByDescending(predicate)) : new ExaminersTableView(GetExaminersTableRawsData(sessionId).OrderBy(predicate));
    }
}