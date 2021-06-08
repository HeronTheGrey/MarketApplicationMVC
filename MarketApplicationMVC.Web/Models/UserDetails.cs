using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Web.Models
{
    public class UserDetails
    {

        public UserDetails()
        {

        }

        public UserDetails(string name, string userType, string country, string city, string street, string zipCode, int buildingNumber, int flatNumber)
        {
            Name = name;
            UserType = userType;
            Country = country;
            City = city;
            Street = street;
            ZipCode = zipCode;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;
        }

        public string Name { get; set; }
        [DisplayName("Type of user")]
        public string UserType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int BuildingNumber { get; set; }
        public int FlatNumber { get; set; }

    }
}
