using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Admin.App.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(200, ErrorMessage = "{0} field must have between {2} and {1} characters", MinimumLength = 2)]
        public string Street { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(50, ErrorMessage = "{0} field must have between {2} and {1} characters", MinimumLength = 1)]
        public string Number { get; set; }

        [DisplayName("Additional Info")]
        public string AdditionalInfo { get; set; }

        [DisplayName("Postal Code")]
        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(8, ErrorMessage = "{0} field must have {1} characters", MinimumLength = 8)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(100, ErrorMessage = "{0} field must have between {2} and {1} characters", MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(50, ErrorMessage = "{0} field must have between {2} and {1} characters", MinimumLength = 2)]
        public string State { get; set; }

        [HiddenInput]
        public Guid VendorId { get; set; }
    }
}
