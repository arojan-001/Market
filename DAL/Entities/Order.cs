using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public float Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Valuedate { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
