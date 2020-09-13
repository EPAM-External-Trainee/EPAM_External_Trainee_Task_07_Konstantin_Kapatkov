using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Interfaces
{
    /// <summary>Interfaces describes factory to create Dao instances</summary>
    public interface IDaoFactory
    {
        /// <summary>Getting Dao <see cref="Gender"/> object</summary>
        /// <returns><see cref="IDao{Gender}"/> object</returns>
        IDao<Gender> GetDaoGender();

        /// <summary>Getting Dao <see cref="Group"/> object</summary>
        /// <returns><see cref="IDao{Group}"/> object</returns>
        IDao<Group> GetDaoGroup();

        /// <summary>Getting Dao <see cref="GroupSpecialty"/> object</summary>
        /// <returns><see cref="IDao{GroupSpecialty}"/> object</returns>
        IDao<GroupSpecialty> GetDaoGroupSpecialty();

        /// <summary>Getting Dao <see cref="KnowledgeAssessmentForm"/> object</summary>
        /// <returns><see cref="IDao{KnowledgeAssessmentForm}"/> object</returns>
        IDao<KnowledgeAssessmentForm> GetDaoKnowledgeAssessmentForm();

        /// <summary>Getting Dao <see cref="Subject"/> object</summary>
        /// <returns><see cref="IDao{Subject}"/> object</returns>
        IDao<Subject> GetDaoSubject();

        /// <summary>Getting Dao <see cref="Student"/> object</summary>
        /// <returns><see cref="IDao{Student}"/> object</returns>
        IDao<Student> GetDaoStudent();

        /// <summary>Getting Dao <see cref="Session"/> object</summary>
        /// <returns><see cref="IDao{Session}"/> object</returns>
        IDao<Session> GetDaoSession();

        /// <summary>Getting Dao <see cref="SessionSchedule"/> object</summary>
        /// <returns><see cref="IDao{SessionSchedule}"/> object</returns>
        IDao<SessionSchedule> GetDaoSessionSchedule();

        /// <summary>Getting Dao <see cref="SessionResult"/> object</summary>
        /// <returns><see cref="IDao{SessionResult}"/> object</returns>
        IDao<SessionResult> GetDaoSessionResult();

        /// <summary>Getting Dao <see cref="Examiner"/> object</summary>
        /// <returns><see cref="IDao{Examiner}"/> object</returns>
        IDao<Examiner> GetDaoExaminer();
    }
}