using Admin.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Admin.App.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Vendor")]
        public Guid VendorId { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(200, ErrorMessage = "{0} field must have between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(1000, ErrorMessage = "{0} field must have between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }

        public IFormFile ImageUpload { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public decimal Value { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegisterDate { get; set; }

        [DisplayName("Active?")]
        public bool Active { get; set; }


        public VendorViewModel Vendor { get; set; }
        public IEnumerable<VendorViewModel> Vendors { get; set; }
    }
}
