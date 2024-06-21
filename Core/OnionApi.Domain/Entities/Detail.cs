using OnionApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Domain.Entities
{
    public class Detail:EntityBase
    {
        public Detail() { }
        public Detail(string title,string description,int categoryId) 
        { 
            this.Title = title;
            this.Description = description;
            this.CategoryId = categoryId;
        }
        public  int Id { get; set; }
        public  string Title { get; set; }
        public  string Description { get; set; }
        public  int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
