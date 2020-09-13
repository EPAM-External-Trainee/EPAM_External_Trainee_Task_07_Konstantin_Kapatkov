using BLL.Reports.Interfaces;
using DAL.DAO.Models;
using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;

namespace BLL.Reports.Abstract
{
    public abstract class Report : IReport
    {
        /// <summary>Constructor for initializing data</summary>
        /// <param name="connectionString">SQL Server connection string</param>
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

        /// <inheritdoc cref="IReport.DaoFactory"/>
        public DaoFactory DaoFactory { get; set; }

        /// <inheritdoc cref="IReport.Sessions"/>
        public IEnumerable<Session> Sessions { get; set; }

        /// <inheritdoc cref="IReport.SessionResults"/>
        public IEnumerable<SessionResult> SessionResults { get; set; }

        /// <inheritdoc cref="IReport.SessionSchedules"/>
        public IEnumerable<SessionSchedule> SessionSchedules { get; set; }

        /// <inheritdoc cref="IReport.Groups"/>
        public IEnumerable<Group> Groups { get; set; }

        /// <inheritdoc cref="IReport.KnowledgeAssessmentForms"/>
        public IEnumerable<KnowledgeAssessmentForm> KnowledgeAssessmentForms { get; set; }

        /// <inheritdoc cref="IReport.Students"/>
        public IEnumerable<Student> Students { get; set; }

        /// <inheritdoc cref="IReport.Subjects"/>
        public IEnumerable<Subject> Subjects { get; set; }

        /// <inheritdoc cref="IReport.Examiners"/>
        public IEnumerable<Examiner> Examiners { get; set; }

        /// <inheritdoc cref="IReport.GroupSpecialties"/>
        public IEnumerable<GroupSpecialty> GroupSpecialties { get; set; }
    }
}