using EFCUTY_ASP_2022231.Data;
using EFCUTY_ASP_2022231.Models;

namespace EFCUTY_ASP_2022231.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        ApplicationDbContext context;

        public CommentsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Comment comment)
        {
            this.context.Comments.Add(comment);
            this.context.SaveChanges();
        }

        public IEnumerable<Comment> GetAll()
        {
            return this.context.Comments;
        }

        public Comment GetOne(string id)
        {
            return this.context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(Comment comment)
        {
            this.context.Comments.Remove(comment);
            this.context.SaveChanges();
        }

        public void Update(Comment comment)
        {
            Comment old = this.GetOne(comment.Id);
            old.Content = comment.Content;
            old.LastEdited = DateTime.Now;
            old.EditCount = comment.EditCount++;
            this.context.SaveChanges();
        }
    }
}
