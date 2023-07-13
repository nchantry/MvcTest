using System.ComponentModel.DataAnnotations;

namespace JO20417123_ASPNETCore_L3.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
