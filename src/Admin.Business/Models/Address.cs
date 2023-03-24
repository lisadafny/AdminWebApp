using System.ComponentModel.DataAnnotations;

namespace Admin.Business.Models
{
    public class Address : Entity
    {
        public Guid VendorId { get; set; }

        public string Street { get; set; }


        public string Number { get; set; }


        public string AdditionalInfo { get; set; }


        public string PostalCode { get; set; }


        public string City { get; set; }

        public string State { get; set; }

        public Vendor Vendor { get; set; }
    }
}
