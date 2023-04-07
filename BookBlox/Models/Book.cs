using System.ComponentModel.DataAnnotations;

namespace BookBlox.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long Price { get; set; }
        [Display(Name="Add Date")]
        public DateTime AddDate { get; set; } = DateTime.Now;
    }
}
