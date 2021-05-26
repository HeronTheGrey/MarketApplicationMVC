using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Domain.Model
{
    public class ContactType
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public virtual ICollection<ContactInformation> ContactInformations { get; set; }
    }
}
