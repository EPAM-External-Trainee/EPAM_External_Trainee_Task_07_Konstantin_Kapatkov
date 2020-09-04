using BLL.Reports.Abstract;
using BLL.Reports.Structs.ExcelTableRawViews.DynamicChangesInAverageMark;
using BLL.Reports.Structs.ReportData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Models
{
    public class DynamicChangesInAverageMarkReport : Report
    {
        public DynamicChangesInAverageMarkReport(string connectionString) : base(connectionString)
        {
        }

        private List<TableRowView> GetTableRowsData()
        {
            List<TableRowView> result = new List<TableRowView>();
            List<string> years = Sessions.Select(s => s.AcademicYear).OrderBy(s => s).ToList();
            years.OrderBy(y => y);

            List<string> subjects = new List<string>();
            foreach (var year in Sessions.Select(s => s.AcademicYear))
            {
                subjects.AddRange(from sr in SessionResults
                                  join s in Subjects on sr.StudentId equals s.Id
                                  join ss in Sessions on sr.SessionId equals ss.Id
                                  join sesSched in SessionSchedules on s.Id equals sesSched.SubjectId
                                  where ss.AcademicYear == year && sesSched.KnowledgeAssessmentFormId == 1
                                  select s.Name);
            }

            List<double> subjectYearAssessments = new List<double>();
            List<double> subjectAvgAssessments = new List<double>();
            foreach (string subject in subjects.Distinct())
            {
                foreach (string year in years)
                {
                    subjectYearAssessments.AddRange(from sr in SessionResults
                                                    join s in Subjects on sr.SubjectId equals s.Id
                                                    join ss in Sessions on sr.SessionId equals ss.Id
                                                    join sesSched in SessionSchedules on s.Id equals sesSched.SubjectId
                                                    where ss.AcademicYear == year && s.Name == subject && sesSched.KnowledgeAssessmentFormId == 1
                                                    select double.Parse(sr.Assessment));

                    if(subjectYearAssessments.Count != 0)
                    {
                        subjectAvgAssessments.Add(Math.Round(subjectYearAssessments.Average(), 2));
                        subjectYearAssessments.Clear();
                    }
                }

                if(subjectAvgAssessments.Count == years.Count)
                {
                    result.Add(new TableRowView(subject, new List<double>(subjectAvgAssessments)));
                }

                subjectAvgAssessments.Clear();
            }

            return result;
        }

        public DynamicChangesInAverageMarkReportData GetReportData() => new DynamicChangesInAverageMarkReportData(GetTableRowsData(), Sessions.Select(s => s.AcademicYear));
    }
}