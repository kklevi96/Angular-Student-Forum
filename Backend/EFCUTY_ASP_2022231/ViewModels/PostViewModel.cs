using System.ComponentModel.DataAnnotations;

namespace EFCUTY_ASP_2022231.ViewModels
{
    public class PostViewModel
    {
        [Required]
        [MinLength(10)]
        public string Content { get; set; }
        public string SubjectCode { get; set; }
    }
}
