using EFCUTY_ASP_2022231.Models;

namespace EFCUTY_ASP_2022231.Repository
{
    public interface ISubjectsRepository
    {
        void Create(Subject subject);
        void Delete(Subject subject);
        IEnumerable<Subject> GetAll();
        Subject GetOne(string id);
        void Update(Subject subject);
    }
}