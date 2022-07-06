using System.ComponentModel.DataAnnotations;

namespace EnterpriseIMS.Models.ViewModels
{
    public class ResetPasswordVM
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }

        public bool IsSuccess { get; set; }
    }
}
