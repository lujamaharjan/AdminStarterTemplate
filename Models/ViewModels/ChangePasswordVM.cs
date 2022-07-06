using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EnterpriseIMS.Models.ViewModels
{
    public class ChangePasswordVM
{
        [Required, DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Password Not Matched")]
        public string ConfirmPassword { get; set; }
    }
}
