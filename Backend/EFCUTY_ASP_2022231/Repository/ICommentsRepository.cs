using EFCUTY_ASP_2022231.Models;

namespace EFCUTY_ASP_2022231.Repository
{
    public interface ICommentsRepository
    {
        void Create(Comment comment);
        void Delete(Comment comment);
        IEnumerable<Comment> GetAll();
        Comment GetOne(string id);
        void Update(Comment comment);
    }
}