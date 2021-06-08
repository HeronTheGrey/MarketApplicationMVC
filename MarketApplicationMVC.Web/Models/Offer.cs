using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApplicationMVC.Web.Models
{
    public class Offer
    {
        public Offer()
        {

        }

        public Offer(int id, string name, decimal price, int amount)
        {
            Id = id;
            Name = name;
            Price = price;
            Amount = amount;
        }

        [DisplayName("Identificator")]
        public int Id { get; set; }
        [DisplayName("Item name")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
