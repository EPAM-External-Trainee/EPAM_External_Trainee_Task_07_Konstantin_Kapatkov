using BLL.Reports.Abstract;
using BLL.Reports.Excel.Views.SessionResultReport;
using BLL.Reports.Interfaces.SessionResultReport;
using BLL.Reports.Views.SessionResultReport.TableView;
using DAL.ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Models.SessionResultReportData
{
    /// <summary>Class describing specialty assessmets table functionality</summary>
    public class SpecialtyAssessmetsTable : Report, ISpecialtyAssessmetsTable
    {
        /// <summary>Creating an instance of <see cref="SpecialtyAssessmetsTable"/> via connection string</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public SpecialtyAssessmetsTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>Getting assessments</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="specialtyId">Specialty id</param>
        /// <returns><see cref="IEnumerable{double}"/> assessments</returns>
        private IEnumerable<double> GetAssessments(int sessionId, int specialtyId)
        {
            return from g in Groups
                   join st in Students on g.Id equals st.GroupId
                   join sr in SessionResults on st.Id equals sr.StudentId
                   join ss in SessionSchedules on st.GroupId equals ss.GroupId
                   join gs in GroupSpecialties on g.GroupSpecialtyId equals gs.Id
                   where ss.SubjectId == sr.SubjectId && ss.KnowledgeAssessmentFormId == 1 && sr.SessionId == sessionId && gs.Id == specialtyId
                   select double.Parse(sr.Assessment);
        }

        /// <summary>Getting group specialities</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns><see cref="IEnumerable{GroupSpecialty}"/> group specialities</returns>
        private IEnumerable<GroupSpecialty> GetGroupSpecialities(int sessionId)
        {
            return from g in Groups
                   join st in Students on g.Id equals st.Id
                   join sr in SessionResults on st.Id equals sr.StudentId
                   join gs in GroupSpecialties on g.GroupSpecialtyId equals gs.Id
                   join ss in SessionSchedules on sessionId equals ss.SessionId
                   where ss.GroupId == g.Id
                   select gs;
        }

        /// <summary>Getting group specialty table raws data</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns><see cref="IEnumerable{SpecialtyAssessmetsTableRowView}"/> group specialty table raws data</returns>
        private IEnumerable<SpecialtyAssessmetsTableRowView> GetGroupSpecialtyTableRawsData(int sessionId)
        {
            IEnumerable<GroupSpecialty> groupSpecialities = GetGroupSpecialities(sessionId).Distinct();
            List<SpecialtyAssessmetsTableRowView> result = new List<SpecialtyAssessmetsTableRowView>();
            List<double> assessments = new List<double>();

            foreach (var specialty in groupSpecialities)
            {
                assessments.AddRange(GetAssessments(sessionId, specialty.Id));
                result.Add(new SpecialtyAssessmetsTableRowView(specialty.Name, Math.Round(assessments.Average(), 2)));
                assessments.Clear();
            }

            return result;
        }

        /// <inheritdoc cref="ISpecialtyAssessmetsTable.GetSpecialtyAssessmetsTableData(int)"/>
        public SpecialtyAssessmetsTableView GetSpecialtyAssessmetsTableData(int sessionId) => new SpecialtyAssessmetsTableView(GetGroupSpecialtyTableRawsData(sessionId));

        /// <inheritdoc cref="ISpecialtyAssessmetsTable.GetSpecialtyAssessmetsTableData(int, Func{SpecialtyAssessmetsTableRowView, object}, bool)"/>
        public SpecialtyAssessmetsTableView GetSpecialtyAssessmetsTableData(int sessionId, Func<SpecialtyAssessmetsTableRowView, object> predicate, bool isDescOrder) => isDescOrder ? new SpecialtyAssessmetsTableView(GetGroupSpecialtyTableRawsData(sessionId).OrderBy(predicate)) : new SpecialtyAssessmetsTableView(GetGroupSpecialtyTableRawsData(sessionId).OrderByDescending(predicate));
    }
}