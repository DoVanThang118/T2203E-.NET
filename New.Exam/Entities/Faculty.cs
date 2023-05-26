using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace New.Exam.Entities
{
    [Table("Faculties")]
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
