using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public String Name { get; set; } = String.Empty;
        public String Describtion { get; set; } = String.Empty;
        public String PictureRef { get; set; } = String.Empty;
    }
}
