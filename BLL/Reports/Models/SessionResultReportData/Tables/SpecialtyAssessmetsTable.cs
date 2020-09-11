using BLL.Reports.Abstract;
using BLL.Reports.ExcelViews.SessionResultReport.TableView;
using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using DAL.ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Models.SessionResultReportData
{
    public class SpecialtyAssessmetsTable : Report
    {
        public SpecialtyAssessmetsTable(string connectionString) : base(connectionString)
        {
        }

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

        private IEnumerable<SpecialtyAssessmetsTableRawView> GetGroupSpecialtyTableRawsData(int sessionId)
        {
            IEnumerable<GroupSpecialty> groupSpecialities = GetGroupSpecialities(sessionId).Distinct();
            List<SpecialtyAssessmetsTableRawView> result = new List<SpecialtyAssessmetsTableRawView>();
            List<double> assessments = new List<double>();

            foreach (var specialty in groupSpecialities)
            {
                assessments.AddRange(GetAssessments(sessionId, specialty.Id));
                result.Add(new SpecialtyAssessmetsTableRawView(specialty.Name, Math.Round(assessments.Average(), 2)));
                assessments.Clear();
            }

            return result;
        }

        public SpecialtyAssessmetsTableView GetSpecialtyAssessmetsTableData(int sessionId) => new SpecialtyAssessmetsTableView(GetGroupSpecialtyTableRawsData(sessionId));

        public SpecialtyAssessmetsTableView GetSpecialtyAssessmetsTableData(int sessionId, Func<SpecialtyAssessmetsTableRawView, object> predicate, bool isDescOrder) => isDescOrder ? new SpecialtyAssessmetsTableView(GetGroupSpecialtyTableRawsData(sessionId).OrderBy(predicate)) : new SpecialtyAssessmetsTableView(GetGroupSpecialtyTableRawsData(sessionId).OrderByDescending(predicate));

    }
}