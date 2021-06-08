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
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int OfferCategoryId { get; set; }
        public virtual OfferCategory OfferCategory { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
