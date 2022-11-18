using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal PriceOfUnit { get; set; }
        public float Qnty { get; set; }
        public int ProductCategoryId { get; set; } 
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
