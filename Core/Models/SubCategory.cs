

//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Text.Json.Serialization;

//namespace Dmart_web.Core.Models
//{
//    public class SubCategory
//    {
//        [Key]
//        public int SubCategoryId { get; set; }

//        [Required]
//        public string Name { get; set; }

//        [ForeignKey("Category")]
//        public int CategoryId { get; set; }

//        [JsonIgnore]
//        public Category Category { get; set; }

//        //  One SubCategory → Many Products
//        public ICollection<Product> Products { get; set; }
//    }
//}


using System.ComponentModel.DataAnnotations;

namespace Dmart_web.Core.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
