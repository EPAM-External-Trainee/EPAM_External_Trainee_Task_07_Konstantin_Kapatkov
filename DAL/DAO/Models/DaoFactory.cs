using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Models
{
    /// <summary>Class describes factory to create Dao instances</summary>
    /// <remarks>Applied singleton pattern</remarks>
    public class DaoFactory : IDaoFactory
    {
        /// <summary>Class instance</summary>
        private static DaoFactory _instance;

        /// <summary>SQL Server connection string</summary>
        private static string _connectionString;

        /// <summary>Default constructor</summary>
        /// <remarks>Private</remarks>
        private DaoFactory()
        {
        }

        /// <summary>Getting instance of class</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        /// <returns>Instance of <see cref="DaoFactory"/></returns>
        public static DaoFactory GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new DaoFactory();
                _connectionString = connectionString;
            }
            return _instance;
        }

        /// <inheritdoc cref="IDaoFactory.GetDaoGender"/>
        public IDao<Gender> GetDaoGender() => new DaoGender(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetDaoExaminer"/>
        public IDao<Examiner> GetDaoExaminer() => new DaoExaminer(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetDaoGroup"/>
        public IDao<Group> GetDaoGroup() => new DaoGroup(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetDaoGroupSpecialty"/>
        public IDao<GroupSpecialty> GetDaoGroupSpecialty() => new DaoGroupSpecialty(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetDaoKnowledgeAssessmentForm"/>
        public IDao<KnowledgeAssessmentForm> GetDaoKnowledgeAssessmentForm() => new DaoKnowledgeAssessmentForm(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetDaoSession"/>
        public IDao<Session> GetDaoSession() => new DaoSession(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetDaoSessionResult"/>
        public IDao<SessionResult> GetDaoSessionResult() => new DaoSessionResult(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetDaoSessionSchedule"/>
        public IDao<SessionSchedule> GetDaoSessionSchedule() => new DaoSessionSchedule(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetDaoStudent"/>
        public IDao<Student> GetDaoStudent() => new DaoStudent(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetDaoSubject"/>
        public IDao<Subject> GetDaoSubject() => new DaoSubject(_connectionString);
    }
}