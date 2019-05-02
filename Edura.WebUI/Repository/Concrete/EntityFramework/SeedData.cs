using Edura.WebUI.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .GetRequiredService<EduraContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                var products = new[]
                {
                    new Product(){ ProductName="Photo Camera", Price=153, Image="product1.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="Açıklamalar1", DateAdded=DateTime.Now.AddDays(-10)},
                   
                };

                context.Products.AddRange(products);

                var categories = new[]
                {
                    new Category(){ CategoryName="Electronics"},
                    
                };

                context.Categories.AddRange(categories);

                var productcategories = new[]
                {
                    new ProductCategory(){ Product=products[0],Category=categories[0]},
                   
                };

                context.AddRange(productcategories);


                var images = new[]
                {
                    new Image(){ ImageName="product1.jpg", Product=products[0]},
                    new Image(){ ImageName="product2.jpg", Product=products[0]},
                    new Image(){ ImageName="product3.jpg", Product=products[0]},
                    new Image(){ ImageName="product4.jpg", Product=products[0]},

                };

                context.Images.AddRange(images);

                context.SaveChanges();

            }
        }
    }
}
