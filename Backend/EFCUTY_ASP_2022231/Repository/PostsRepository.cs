using EFCUTY_ASP_2022231.Data;
using EFCUTY_ASP_2022231.Models;

namespace EFCUTY_ASP_2022231.Repository
{
    public class PostsRepository : IPostsRepository
    {
        ApplicationDbContext context;

        public PostsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Post post)
        {
            this.context.Posts.Add(post);
            this.context.SaveChanges();
        }

        public IEnumerable<Post> GetAll()
        {
            return this.context.Posts;
        }

        public Post GetOne(string id)
        {
            return this.context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(Post post)
        {
            this.context.Posts.Remove(post);
            this.context.SaveChanges();
        }

        public void Update(Post post)
        {
            Post old = this.GetOne(post.Id);
            old.Content = post.Content;
            old.LastEdited = DateTime.Now;
            old.EditCount = post.EditCount++;
            this.context.SaveChanges();
        }
    }
}
