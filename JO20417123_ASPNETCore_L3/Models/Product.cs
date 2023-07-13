using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JO20417123_ASPNETCore_L3.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        //[ValidateNever]
        //public Category Category { get; set; }

        public int SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        [ValidateNever]
        public SubCategory SubCategory { get; set; }
    }
}
