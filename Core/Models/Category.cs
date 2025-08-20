using System.ComponentModel.DataAnnotations;

namespace Dmart_web.Core.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        // One Category → Many SubCategories
        public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    }
}
