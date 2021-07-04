using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketApplicationMVC.Domain.Model
{
    public class Offer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public int Price { get; set; } // rozwiązać problem z przecinkiem
        public bool IsActive { get; set; }
        public int OfferCategoryId { get; set; }
        public virtual OfferCategory OfferCategory { get; set; }
        public string UserId { get; set; }
    }
}
