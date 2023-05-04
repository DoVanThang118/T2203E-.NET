using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace T2203E_demo.Entities
{
    [Table("Products")]
    public class Product
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
