using BLL.Reports.Abstract;
using BLL.Reports.Enums;
using BLL.Reports.ExcelViews.ExcelTableView.GroupSessionResultReport;
using BLL.Reports.Structs.ExcelTableRawViews.DynamicChangesInAverageMark;
using DAL.ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Models
{
    public class AssessmentDynamicsTable : Report /*IAssessmentDynamicsReport*/
    {
        public AssessmentDynamicsTable(string connectionString) : base(connectionString)
        {
        }

        private IEnumerable<AssessmentDynamicsTableRowView> GetTableRowsData()
        {
            List<AssessmentDynamicsTableRowView> result = new List<AssessmentDynamicsTableRowView>();
            List<string> years = GetYears().OrderBy(y => y).ToList();
            List<Subject> subjects = GetSubjects(years).Distinct().ToList();
            List<double> subjectYearAssessments = new List<double>();
            List<double> subjectAvgAssessments = new List<double>();

            foreach (var subject in subjects)
            {
                foreach (string year in years)
                {
                    subjectYearAssessments.AddRange(GetSubjectYearAssessments(year, subject.Id).OrderBy(a => a));

                    if (subjectYearAssessments.Count != 0)
                    {
                        subjectAvgAssessments.Add(Math.Round(subjectYearAssessments.OrderBy(a => a).Average(), 2));
                    }
                    else
                    {
                        subjectAvgAssessments.Add(-1);
                    }

                    subjectYearAssessments.Clear();
                }

                if(subjectAvgAssessments.Count == years.Count)
                {
                    result.Add(new AssessmentDynamicsTableRowView(subject.Name, new List<double>(subjectAvgAssessments.OrderBy(a => a))));
                }

                subjectAvgAssessments.Clear();
            }

            return result;
        }

        private IEnumerable<string> GetYears() => Sessions.Select(s => s.AcademicYear);

        private IEnumerable<Subject> GetSubjects(string year)
        {
            return from sr in SessionResults
                   join s in Subjects on sr.StudentId equals s.Id
                   join ss in Sessions on sr.SessionId equals ss.Id
                   join sesSched in SessionSchedules on s.Id equals sesSched.SubjectId
                   where ss.AcademicYear == year && sesSched.KnowledgeAssessmentFormId == 1
                   select s;
        }

        private IEnumerable<Subject> GetSubjects(IEnumerable<string> years)
        {
            List<Subject> subjects = new List<Subject>();
            foreach (var year in years)
            {
                subjects.AddRange(GetSubjects(year));
            }
            return subjects;
        }

        private IEnumerable<double> GetSubjectYearAssessments(string year, int subjectId)
        {
            return from sr in SessionResults
                   join s in Subjects on sr.SubjectId equals s.Id
                   join ss in Sessions on sr.SessionId equals ss.Id
                   join sesSched in SessionSchedules on s.Id equals sesSched.SubjectId
                   where ss.AcademicYear == year && s.Id == subjectId && sesSched.KnowledgeAssessmentFormId == 1
                   select double.Parse(sr.Assessment);
        }

        public AssessmentDynamicsTableView GetAssessmentDynamicsTable() => new AssessmentDynamicsTableView(GetTableRowsData(), Sessions.Select(s => s.AcademicYear));

        public AssessmentDynamicsTableView GetAssessmentDynamicsTable(AssessmentDynamicsTableOrderBy orderBy, bool isDesc = false)
        {
            return orderBy switch
            {
                AssessmentDynamicsTableOrderBy.Subject => isDesc ? new ExcelViews.ExcelTableView.GroupSessionResultReport.AssessmentDynamicsTableView(GetTableRowsData().OrderByDescending(d => d.SubjectName), Sessions.Select(s => s.AcademicYear)) : new ExcelViews.ExcelTableView.GroupSessionResultReport.AssessmentDynamicsTableView(GetTableRowsData().OrderBy(d => d.SubjectName), Sessions.Select(s => s.AcademicYear)),
                AssessmentDynamicsTableOrderBy.AverageAssessment => isDesc ? new ExcelViews.ExcelTableView.GroupSessionResultReport.AssessmentDynamicsTableView(GetTableRowsData().OrderByDescending(d => d.AvgAssessments.Last()), Sessions.Select(s => s.AcademicYear)) : new ExcelViews.ExcelTableView.GroupSessionResultReport.AssessmentDynamicsTableView(GetTableRowsData().OrderBy(d => d.AvgAssessments.Last()), Sessions.Select(s => s.AcademicYear)),
                _ => throw new NotImplementedException(),
            };
        }
    }
}