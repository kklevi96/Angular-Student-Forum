using EFCUTY_ASP_2022231.Models;

namespace EFCUTY_ASP_2022231.Repository
{
    public interface IPostsRepository
    {
        void Create(Post post);
        void Delete(Post post);
        IEnumerable<Post> GetAll();
        Post GetOne(string id);
        void Update(Post post);
    }
}