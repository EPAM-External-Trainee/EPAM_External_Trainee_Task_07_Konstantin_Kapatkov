using BLL.Reports.Abstract;
using BLL.Reports.Enums;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRawViews;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews;
using BLL.Reports.Interfaces.GroupSessionResultReport;
using DAL.ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Models
{
    /// <summary>Class describing assessment dynamics table functionality</summary>
    public class AssessmentDynamicsTable : Report, IAssessmentDynamicsTable
    {
        /// <summary>Creating an instance of <see cref="AssessmentDynamicsTable"/> via connection string</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public AssessmentDynamicsTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>Getting assessment dynamics table row views</summary>
        /// <returns><see cref="IEnumerable{AssessmentDynamicsTableRowView}"/> table row views</returns>
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

                if (subjectAvgAssessments.Count == years.Count)
                {
                    result.Add(new AssessmentDynamicsTableRowView(subject.Name, new List<double>(subjectAvgAssessments.OrderBy(a => a))));
                }

                subjectAvgAssessments.Clear();
            }

            return result;
        }

        /// <summary>Getting academic years</summary>
        /// <returns><see cref="IEnumerable{string}"/> academic years</returns>
        private IEnumerable<string> GetYears() => Sessions.Select(s => s.AcademicYear);

        /// <summary>Getting subjects present in the specified academic year</summary>
        /// <param name="year">Academic year</param>
        /// <returns><see cref="IEnumerable{Subject}"/> subjects</returns>
        private IEnumerable<Subject> GetSubjects(string year)
        {
            return from sr in SessionResults
                   join s in Subjects on sr.StudentId equals s.Id
                   join ss in Sessions on sr.SessionId equals ss.Id
                   join sesSched in SessionSchedules on s.Id equals sesSched.SubjectId
                   where ss.AcademicYear == year && sesSched.KnowledgeAssessmentFormId == 1
                   select s;
        }

        /// <summary>Getting subjects present in the specified academic years</summary>
        /// <param name="years">Academic years</param>
        /// <returns><see cref="IEnumerable{Subject}"/> subjects</returns>
        private IEnumerable<Subject> GetSubjects(IEnumerable<string> years)
        {
            List<Subject> subjects = new List<Subject>();
            foreach (var year in years)
            {
                subjects.AddRange(GetSubjects(year));
            }
            return subjects;
        }

        /// <summary>Getting subject year assessments</summary>
        /// <param name="year">Academic year</param>
        /// <param name="subjectId">Subject id</param>
        /// <returns><see cref="IEnumerable{double}"/> subject year assessments</returns>
        private IEnumerable<double> GetSubjectYearAssessments(string year, int subjectId)
        {
            return from sr in SessionResults
                   join s in Subjects on sr.SubjectId equals s.Id
                   join ss in Sessions on sr.SessionId equals ss.Id
                   join sesSched in SessionSchedules on s.Id equals sesSched.SubjectId
                   where ss.AcademicYear == year && s.Id == subjectId && sesSched.KnowledgeAssessmentFormId == 1
                   select double.Parse(sr.Assessment);
        }

        /// <inheritdoc cref="IAssessmentDynamicsTable.GetAssessmentDynamicsTable"/>
        public AssessmentDynamicsTableView GetAssessmentDynamicsTable() => new AssessmentDynamicsTableView(GetTableRowsData(), Sessions.Select(s => s.AcademicYear));

        /// <inheritdoc cref="IAssessmentDynamicsTable.GetAssessmentDynamicsTable(AssessmentDynamicsTableOrderBy, bool)"/>
        public AssessmentDynamicsTableView GetAssessmentDynamicsTable(AssessmentDynamicsTableOrderBy orderBy, bool isDesc = false)
        {
            return orderBy switch
            {
                AssessmentDynamicsTableOrderBy.Subject => isDesc ? new AssessmentDynamicsTableView(GetTableRowsData().OrderBy(d => d.SubjectName), Sessions.Select(s => s.AcademicYear)) : new AssessmentDynamicsTableView(GetTableRowsData().OrderByDescending(d => d.SubjectName), Sessions.Select(s => s.AcademicYear)),
                AssessmentDynamicsTableOrderBy.AverageAssessment => isDesc ? new AssessmentDynamicsTableView(GetTableRowsData().OrderByDescending(d => d.AvgAssessments.Last()), Sessions.Select(s => s.AcademicYear)) : new AssessmentDynamicsTableView(GetTableRowsData().OrderBy(d => d.AvgAssessments.Last()), Sessions.Select(s => s.AcademicYear)),
                _ => throw new Exception(),
            };
        }
    }
}