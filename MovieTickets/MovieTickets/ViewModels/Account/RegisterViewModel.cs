namespace MovieTickets.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class RegisterViewModel
    {
        [Display(Name = DisplayFullName )]
        [Required(ErrorMessage = FullNameError)]
        public string FullName { get; set; }

        [Display(Name = DisplayEmail)]
        [Required(ErrorMessage = EmailError)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = DisplayConfirmPassword)]
        [Required(ErrorMessage = ConfirmPasswordError)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
