using BLL.Reports.Interfaces;
using DAL.DAO.Models;
using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;

namespace BLL.Reports.Abstract
{
    public abstract class Report : IReport
    {
        protected Report(string connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;")
        {
            DaoFactory = DaoFactory.GetInstance(connectionString);
            Sessions = DaoFactory.GetDaoSession().TryReadAllAsync().Result;
            SessionResults = DaoFactory.GetDaoSessionResult().TryReadAllAsync().Result;
            SessionSchedules = DaoFactory.GetDaoSessionSchedule().TryReadAllAsync().Result;
            Groups = DaoFactory.GetDaoGroup().TryReadAllAsync().Result;
            KnowledgeAssessmentForms = DaoFactory.GetDaoKnowledgeAssessmentForm().TryReadAllAsync().Result;
            Students = DaoFactory.GetDaoStudent().TryReadAllAsync().Result;
            Subjects = DaoFactory.GetDaoSubject().TryReadAllAsync().Result;
            Examiners = DaoFactory.GetDaoExaminer().TryReadAllAsync().Result;
            GroupSpecialties = DaoFactory.GetDaoGroupSpecialty().TryReadAllAsync().Result;
        }

        public DaoFactory DaoFactory { get; set; }

        public IEnumerable<Session> Sessions { get; set; }

        public IEnumerable<SessionResult> SessionResults { get; set; }

        public IEnumerable<SessionSchedule> SessionSchedules { get; set; }

        public IEnumerable<Group> Groups { get; set; }

        public IEnumerable<KnowledgeAssessmentForm> KnowledgeAssessmentForms { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }

        public IEnumerable<Examiner> Examiners { get; set; }

        public IEnumerable<GroupSpecialty> GroupSpecialties { get; set; }
    }
}