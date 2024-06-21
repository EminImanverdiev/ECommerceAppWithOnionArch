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
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
