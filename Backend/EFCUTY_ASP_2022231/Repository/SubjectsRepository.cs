using EFCUTY_ASP_2022231.Data;
using EFCUTY_ASP_2022231.Models;

namespace EFCUTY_ASP_2022231.Repository
{
    public class SubjectsRepository : ISubjectsRepository
    {
        ApplicationDbContext context;

        public SubjectsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Subject subject)
        {
            this.context.Subjects.Add(subject);
            this.context.SaveChanges();

        }

        public IEnumerable<Subject> GetAll()
        {
            return this.context.Subjects;
        }

        public Subject GetOne(string id)
        {
            return this.context.Subjects.FirstOrDefault(s => s.SubjectCode == id);
        }

        public void Delete(Subject subject)
        {
            this.context.Subjects.Remove(subject);
            this.context.SaveChanges();
        }

        public void Update(Subject subject)
        {
            Subject old = this.GetOne(subject.SubjectCode);
            old.CreditValue = subject.CreditValue;
            old.Semester = subject.Semester;
            old.ExamSubject = subject.ExamSubject;
            old.Name = subject.Name;
            this.context.SaveChanges();
        }
    }
}
