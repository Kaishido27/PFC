using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFC.Domain.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public PaymentMethod PaymentMethod { get; set; }

        public decimal TotalAmount => Details.Sum(d => d.TotalLinePrice);

        public decimal TotalCost => Details.Sum(d => d.TotalCost);

        public decimal TotalProfit => Details.Sum(d => d.LineProfit);
        public List <OrderDetail> Details { get; set; } = new List<OrderDetail> ();
    }
}
