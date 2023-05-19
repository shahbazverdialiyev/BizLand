using System.ComponentModel.DataAnnotations;

namespace BizLand.Models
{
    public class FeaturedService
    {
        public int Id { get; set; }
        public string? Icon { get; set; }
        [Required(ErrorMessage = "Bosh qala bilmez")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Bosh qala bilmez")]
        public string Description { get; set; } = null!;
    }
}
