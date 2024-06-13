using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Fname is Required")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Lname is Required")]
        public string Lname { get; set; }

       

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "InValid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Compare("Password", ErrorMessage = "Confirm Password DoesNot Match Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        public string? PhoneNumber { get; set; }


    }
}
