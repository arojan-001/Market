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
        public decimal Price { get; set; }
        public DateTime Valuedate { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
    }
}
