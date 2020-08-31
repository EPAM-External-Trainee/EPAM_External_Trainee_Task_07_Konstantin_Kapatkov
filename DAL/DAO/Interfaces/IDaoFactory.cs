using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Interfaces
{
    public interface IDaoFactory
    {
        IDao<Gender> GetGender();

        IDao<Group> GetGroup();

        IDao<GroupSpecialty> GetGroupSpecialty();

        IDao<KnowledgeAssessmentForm> GetKnowledgeAssessmentForm();

        IDao<Subject> GetSubject();

        IDao<Student> GetStudent();

        IDao<Session> GetSession();

        IDao<SessionSchedule> GetSessionSchedule();

        IDao<SessionResult> GetSessionResult();

        IDao<Examiner> GetExaminer();
    }
}