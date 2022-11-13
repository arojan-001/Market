using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductCategory
    {
            
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Describtion { get; set; } = string.Empty;
        public string PictureRef { get; set; } = string.Empty;

       // public List<Product> Product { get; set; }
    }
}
