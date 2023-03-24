using Admin.Business.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Admin.Business.Models
{
    public class Vendor : Entity
    {
        public string Name { get; set; }

        public string Document { get; set; }
        public VendorType VendorType { get; set; }
        public Address Address { get; set; }

        [DisplayName("Active?")]
        public bool Active { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
