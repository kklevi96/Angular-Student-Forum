using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EFCUTY_ASP_2022231.Models
{
    public class Subject
    {
        [Key]
        [DisplayName("Tantárgykód")]
        public string SubjectCode { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Név")]

        public string Name { get; set; }

        [Required]
        [Range(0, 30)]
        [DisplayName("Kreditérték")]

        public int CreditValue { get; set; }

        [Required]
        [DisplayName("Vizsgás tárgy?")]

        public bool ExamSubject { get; set; }

        [Required]
        [Range(0, 7)]
        [DisplayName("Ajánlott félév")]

        public int Semester { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual List<Post>? Posts { get; set; }
    }
}
