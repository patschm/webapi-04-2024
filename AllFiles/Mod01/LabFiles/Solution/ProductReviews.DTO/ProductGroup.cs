using ProductReviews.DAL.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviews.DTO
{
    public class ProductGroupDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        
       public static ProductGroupDTO Create(ProductGroup pg)
        {
            return new ProductGroupDTO { Id = pg.Id, Image = pg.Image, Name = pg.Name };
        }
    }
}