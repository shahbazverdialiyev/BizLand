using System.ComponentModel.DataAnnotations;

namespace BizLand.ViewModels.AccountVM
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "bosh qala bilmez"), MaxLength(16, ErrorMessage = "maksimum uzunluq 16 ola biler")]
        public string Name { get; set; }
        [Required(ErrorMessage = "bosh qala bilmez"), MaxLength(16, ErrorMessage = "maksimum uzunluq 16 ola biler")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "bosh qala bilmez"), MaxLength(16, ErrorMessage = "maksimum uzunluq 16 ola biler")]
        public string Username { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "bosh qala bilmez"), MaxLength(16, ErrorMessage = "maksimum uzunluq 16 ola biler"),DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "bosh qala bilmez"),DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
