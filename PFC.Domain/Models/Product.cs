using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFC.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public Category Category { get; set; }

        public List<ProductSizeOption> SizeOptions { get; set; } = [];

        public bool IsArchived { get; set; } = false;

    }
}
