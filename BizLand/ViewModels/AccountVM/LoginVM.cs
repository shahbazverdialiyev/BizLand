using System.ComponentModel.DataAnnotations;

namespace BizLand.ViewModels.AccountVM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "bosh qala bilmez")]
        public string Username { get; set; }
        [Required(ErrorMessage = "bosh qala bilmez"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
