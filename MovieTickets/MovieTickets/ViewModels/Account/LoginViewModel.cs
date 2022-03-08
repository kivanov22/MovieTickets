using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Web.ViewModels.Account
{
    using static Data.DataConstants;
    public class LoginViewModel
    {
        [Display(Name =DisplayEmail)]
        [Required(ErrorMessage =EmailError)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
