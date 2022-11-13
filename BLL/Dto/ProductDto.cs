using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto
{   
    public class ProductDto
    {
        public int Id { get; set; }
        public String Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public float Qnty { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
