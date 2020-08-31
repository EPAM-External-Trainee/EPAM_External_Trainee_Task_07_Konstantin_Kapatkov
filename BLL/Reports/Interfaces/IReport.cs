using DAL.DAO.Models;
using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;

namespace BLL.Reports.Interfaces
{
    public interface IReport
    {
        DaoFactory DaoFactory { get; set; }

        IEnumerable<Session> Sessions { get; set; }

        IEnumerable<SessionResult> SessionResults { get; set; }

        IEnumerable<SessionSchedule> SessionSchedules { get; set; }

        IEnumerable<Group> Groups { get; set; }

        IEnumerable<KnowledgeAssessmentForm> KnowledgeAssessmentForms { get; set; }

        IEnumerable<Student> Students { get; set; }

        IEnumerable<Subject> Subjects { get; set; }

        IEnumerable<Examiner> Examiners { get; set; }

        IEnumerable<GroupSpecialty> GroupSpecialties { get; set; }
    }
}