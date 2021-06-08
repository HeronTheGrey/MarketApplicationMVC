using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Web.Models
{
    public class User
    {

        public User()
        {

        }

        public User(int id, string name, string userType)
        {
            Id = id;
            Name = name;
            UserType = userType;
            
        }

        [DisplayName("Identificator")]
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Type of user")]
        public string UserType { get; set; }
        
    
    }
}
