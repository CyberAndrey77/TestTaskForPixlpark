using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTaskForPixlpark.Models
{
    public class DeliveryAddress
    {
        public string ZipCode { get; set ; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

        public DeliveryAddress()
        {
            ZipCode = string.Empty;
            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            Description = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            State = string.Empty;
            FullName = string.Empty;
            Phone = string.Empty;
        }
    }
}