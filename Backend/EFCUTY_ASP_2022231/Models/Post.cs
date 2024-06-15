using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EFCUTY_ASP_2022231.Models
{
    public class Post
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Timestamp = DateTime.Now;
        }
        [Key]
        public string Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Timestamp { get; set; }

        public DateTime? LastEdited { get; set; }

        public int EditCount { get; set; }

        [NotMapped]
        public virtual ApiUser? Author { get; set; }

        [ForeignKey(nameof(ApiUser))]
        public string SiteUserId { get; set; }

        [NotMapped]
        public virtual Subject? Subject { get; set; }

        [ForeignKey(nameof(Subject))]
        public string SubjectCode { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual List<Comment>? Comments { get; set; }
    }
}
