using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EnterpriseIMS.Models.ViewModels
{
    public class LoginVM
    {
        [Required, Display(Name = "Email"), DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
