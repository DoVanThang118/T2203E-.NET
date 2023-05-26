using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace T2203E_demo.Entities
{
    [Table("Category")]
    public class Category
    { 
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [StringLength(255)]
        [Required]
        public string Thumbnail { get; set; }
    }
}
