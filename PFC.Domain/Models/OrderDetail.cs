using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFC.Domain.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int  OrderId { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public ProductSize SelectedSize { get; set; }

        public decimal UnitCost { get ; set; }
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public List<AddOns> AddOns { get; set; } = new List<AddOns>();

        public decimal AddOnPrice => (AddOns?.Count ?? 0) * 10m;

        public decimal TotalLinePrice => (UnitPrice + AddOnPrice) * Quantity;

        public decimal TotalCost => UnitCost * Quantity;

        public decimal LineProfit => TotalLinePrice - TotalCost;
    }
}
