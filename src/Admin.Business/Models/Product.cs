﻿using System.ComponentModel.DataAnnotations;

namespace Admin.Business.Models
{
    public class Product : Entity
    {
        public Guid VendorId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Value { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool Active { get; set; }


        public Vendor Vendor { get; set; }
    }
}
