using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Domain.Model
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public string ContactInformationDetail { get; set; }
        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
