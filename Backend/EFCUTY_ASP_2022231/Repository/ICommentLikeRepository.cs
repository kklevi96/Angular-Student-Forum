using EFCUTY_ASP_2022231.Models;

namespace EFCUTY_ASP_2022231.Repository
{
    public interface ICommentLikeRepository
    {
        void Add(string siteUserId, string commentId);
        IEnumerable<CommentLike> GetAll();
        bool IsLikedBy(string siteUserId, string commentId);
        void Remove(string siteUserId, string commentId);
    }
}