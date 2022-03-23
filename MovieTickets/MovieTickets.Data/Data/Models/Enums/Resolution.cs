using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.Models.Enums
{
    public enum Resolution
    {

        [Display(Name = "2D")]
        TwoD = 1,
        [Display(Name = "3D")]
        ThreeD = 2,
        [Display(Name = "4DX")]
        FourDX = 3,
    }
}
