using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EnterpriseIMS.Models.ViewModels
{
    public class UpdateUserVM
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }


        [Display(Name = "Role")]
        public int RoleId { get; set; }


        [Display(Name = "Warehouse")]
        public int WarehouseId { get; set; }
    }
}
