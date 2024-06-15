using EFCUTY_ASP_2022231.Data;
using EFCUTY_ASP_2022231.Models;

namespace EFCUTY_ASP_2022231.Repository
{
    public class CommentLikeRepository : ICommentLikeRepository
    {
        ApplicationDbContext context;

        public CommentLikeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(string siteUserId, string commentId)
        {
            this.context.CommentLikes.Add(new CommentLike() { SiteUserId = siteUserId, CommentId = commentId });
            this.context.SaveChanges();
        }

        public void Remove(string siteUserId, string commentId)
        {
            var removable = this.context.CommentLikes.FirstOrDefault(l => l.SiteUserId == siteUserId && l.CommentId == commentId);

            if (removable != null)
            {
                this.context.CommentLikes.Remove(removable);
                this.context.SaveChanges();
            }

        }

        public IEnumerable<CommentLike> GetAll()
        {
            return this.context.CommentLikes;
        }

        public bool IsLikedBy(string siteUserId, string commentId)
        {
            return this.context.CommentLikes.Any(l => l.SiteUserId == siteUserId && l.CommentId == commentId);
        }
    }
}
