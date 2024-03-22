using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Admin.App.ViewModels
{
    public class VendorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(100, ErrorMessage = "{0} field must have between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} must be numeric")]
        [StringLength(14, ErrorMessage = "{0} field must have between {2} and {1} characters", MinimumLength = 11)]
        
        public string Document { get; set; }

        [DisplayName("Type")]
        public int VendorType { get; set; }
        public string VendorTypeDescription
        {
            get
            {
                if (VendorType == 1) return "Person";
                if (VendorType == 2) return "Entity";
                return "Invalid";
            }
        }
        public AddressViewModel Address { get; set; }

        [DisplayName("Active?")]
        public bool Active { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
        public ReturnViewModel Result { get; set; }

    }
}
