using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Interfaces
{
    public interface IDaoFactory
    {
        IDao<Gender> GetDaoGender();

        IDao<Group> GetDaoGroup();

        IDao<GroupSpecialty> GetDaoGroupSpecialty();

        IDao<KnowledgeAssessmentForm> GetDaoKnowledgeAssessmentForm();

        IDao<Subject> GetDaoSubject();

        IDao<Student> GetDaoStudent();

        IDao<Session> GetDaoSession();

        IDao<SessionSchedule> GetDaoSessionSchedule();

        IDao<SessionResult> GetDaoSessionResult();

        IDao<Examiner> GetDaoExaminer();
    }
}