using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public float Quantity { get; set; }
        public DateTime Valuedate { get; set; }
        public int ProductId { get; set; }
    }
}
