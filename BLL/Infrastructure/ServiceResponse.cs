using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success{ get; set; } = true;
        public string Error { get; set; } = string.Empty;
        
    }
}
