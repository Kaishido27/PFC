using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFC.Domain.Models
{
    public class ProductSizeOption
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public ProductSize Size { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

    }
}
