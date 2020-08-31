using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Models
{
    public class DaoFactory : IDaoFactory
    {
        private static DaoFactory _instance;
        private static string _connectionString;

        private DaoFactory()
        {
        }

        public static DaoFactory GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new DaoFactory();
                _connectionString = connectionString;
            }
            return _instance;
        }

        public IDao<Gender> GetDaoGender() => new DaoGender(_connectionString);

        public IDao<Examiner> GetDaoExaminer() => new DaoExaminer(_connectionString);

        public IDao<Group> GetDaoGroup() => new DaoGroup(_connectionString);

        public IDao<GroupSpecialty> GetDaoGroupSpecialty() => new DaoGroupSpecialty(_connectionString);

        public IDao<KnowledgeAssessmentForm> GetDaoKnowledgeAssessmentForm() => new DaoKnowledgeAssessmentForm(_connectionString);

        public IDao<Session> GetDaoSession() => new DaoSession(_connectionString);

        public IDao<SessionResult> GetDaoSessionResult() => new DaoSessionResult(_connectionString);

        public IDao<SessionSchedule> GetDaoSessionSchedule() => new DaoSessionSchedule(_connectionString);

        public IDao<Student> GetDaoStudent() => new DaoStudent(_connectionString);

        public IDao<Subject> GetDaoSubject() => new DaoSubject(_connectionString);
    }
}