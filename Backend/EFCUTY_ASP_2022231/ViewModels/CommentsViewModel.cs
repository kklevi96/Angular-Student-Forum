using EFCUTY_ASP_2022231.Models;

namespace EFCUTY_ASP_2022231.ViewModels
{
    public class CommentsViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
        public virtual Post Post { get; set; }

        public CommentsViewModel(Post post)
        {
            this.Post = post;
        }
    }
}
