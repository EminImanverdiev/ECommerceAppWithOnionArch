﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new Category() { 
                Id=1,
                Name="Elektrik",
                Priorty=1,
                ParentId=0,
                IsDeleted=false,
                CreatedDate=DateTime.Now,
            };
            Category category2 = new Category()
            {
                Id = 2,
                Name = "Moda",
                Priorty = 2,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            Category parent1 = new Category()
            {
                Id = 3  ,
                Name = "Bilgisayar",
                Priorty = 1,
                ParentId = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            Category parent2 = new Category()
            {
                Id = 4,
                Name = "Kadin",
                Priorty = 1,
                ParentId = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            builder.HasData(category1,category2,parent1,parent2);


        }
    }
}
