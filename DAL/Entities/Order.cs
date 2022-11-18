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
        public decimal Price { get; set; }
        public DateTime Valuedate { get; set; }
        public int CustomerId { get; set; } = 0;
        public int EmployeeId { get; set; } = 0;
       // public List<OrderDetails> OrderDetails { get; set; }
    }
}
