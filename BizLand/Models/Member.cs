using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BizLand.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bosh qala bilmez")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Bosh qala bilmez")]
        public string Surname { get; set; } = null!;
        public string Position { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        [NotMapped]
        public IFormFile formImage { get; set; }
    }
}
