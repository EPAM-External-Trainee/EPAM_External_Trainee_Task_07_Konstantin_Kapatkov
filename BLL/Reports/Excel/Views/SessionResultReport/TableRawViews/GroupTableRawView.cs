using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableRawViews;

namespace BLL.Reports.Excel.Views.SessionResultReport
{
    public struct GroupTableRawView : IGroupTableRawView
    {
        public GroupTableRawView(string name, string surname, string patronymic, string subject, string form, string date, string assessment)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Subject = subject;
            Form = form;
            Date = date;
            Assessment = assessment;
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Subject { get; set; }

        public string Form { get; set; }

        public string Date { get; set; }

        public string Assessment { get; set; }

        public override bool Equals(object obj) => obj is GroupTableRawView view && Surname == view.Surname && Name == view.Name && Patronymic == view.Patronymic && Subject == view.Subject && Form == view.Form && Date == view.Date && Assessment == view.Assessment;

        public override int GetHashCode()
        {
            int hashCode = 908230445;
            hashCode = hashCode * -1521134295 + Name.GetHashCode();
            hashCode = hashCode * -1521134295 + Surname.GetHashCode();
            hashCode = hashCode * -1521134295 + Patronymic.GetHashCode();
            hashCode = hashCode * -1521134295 + Subject.GetHashCode();
            hashCode = hashCode * -1521134295 + Form.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + Assessment.GetHashCode();
            return hashCode;
        }
    }
}