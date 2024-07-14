using OnionApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.Features.Products.Exceptions
{
    public class ProductTitleMustBeSameException:BaseExceptions
    {
        public ProductTitleMustBeSameException():base("Mehsul basliqi onsuz var!")
        {
            
        }
    }
}
