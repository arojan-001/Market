using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

       
    }
}
