using OnionApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Domain.Entities
{
    public class Brand:EntityBase
    {
        public Brand() { }  
        public Brand(string name)
        {
            this.Name = name;
        }
        public required string Name { get; set; }

    }
}
