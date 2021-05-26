using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Domain.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
        public int UserRef { get; set; }
        public virtual User User { get; set; }
    }
}
