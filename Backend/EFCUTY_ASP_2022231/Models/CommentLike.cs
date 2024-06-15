using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EFCUTY_ASP_2022231.Models
{
    public class CommentLike
    {
        public CommentLike()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [NotMapped]
        public virtual ApiUser? Liker { get; set; }

        [ForeignKey(nameof(ApiUser))]
        public string SiteUserId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Comment Liked { get; set; }

        [ForeignKey(nameof(Post))]
        public string CommentId { get; set; }


    }
}
