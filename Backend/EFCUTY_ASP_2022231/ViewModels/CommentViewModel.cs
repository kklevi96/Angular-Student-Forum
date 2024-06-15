using System.ComponentModel.DataAnnotations;

namespace EFCUTY_ASP_2022231.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        [MinLength(10)]
        public string Content { get; set; }
        public string PostId { get; set; }
    }
}
