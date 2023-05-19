using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BizLand.Models
{
    public class AppUser:IdentityUser
    {
        [Required (ErrorMessage ="bosh qala bilmez"),MaxLength(16,ErrorMessage ="maksimum uzunluq 16 ola biler")]
        public string Name { get; set; }
        [Required(ErrorMessage = "bosh qala bilmez"), MaxLength(16, ErrorMessage = "maksimum uzunluq 16 ola biler")]
        public string Surname { get; set; }
    }
}
