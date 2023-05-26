using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace New.Exam.Entities
{
    [Table("Exams")]
    public class Exam
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Exam Date")]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Exam Duration")]
        public TimeSpan Duration { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

        public virtual ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
    }
}
