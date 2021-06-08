using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Domain.Model
{
    public class OfferCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
