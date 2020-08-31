using BLL.Reports.Interfaces;
using DAL.DAO.Models;
using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;

namespace BLL.Reports.Abstract
{
    public class Report : IReport
    {
        protected Report(string connectionString)
        {
            DaoFactory = DaoFactory.GetInstance(connectionString);
            Sessions = DaoFactory.GetDaoSession().ReadAll();
            SessionResults = DaoFactory.GetDaoSessionResult().ReadAll();
            SessionSchedules = DaoFactory.GetDaoSessionSchedule().ReadAll();
            Groups = DaoFactory.GetDaoGroup().ReadAll();
            KnowledgeAssessmentForms = DaoFactory.GetDaoKnowledgeAssessmentForm().ReadAll();
            Students = DaoFactory.GetDaoStudent().ReadAll();
            Subjects = DaoFactory.GetDaoSubject().ReadAll();
            Examiners = DaoFactory.GetDaoExaminer().ReadAll();
            GroupSpecialties = DaoFactory.GetDaoGroupSpecialty().ReadAll();
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