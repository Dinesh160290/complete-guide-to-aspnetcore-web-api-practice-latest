using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books_latest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_latest.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book()
                        {
                            Title = "1st Book Title",
                            Description = "This is my first book",
                            isRead = true,
                            DateRead = DateTime.Now,
                            Rate = 4,
                            Genre = "Crime",
                            CoverUrl = "https://crimebook.com/1stbook.pdf",
                            DateAdded = DateTime.Now
                        },
                        new Book()
                        {
                            Title = "2nd Book Title",
                            Description = "This is my second book",
                            isRead = false,
                            Genre = "History",
                            CoverUrl = "https://crimebook.com/2ndbook.pdf",
                            DateAdded = DateTime.Now
                        }
                    );

                    context.SaveChanges();

                }

            }
        }
    }
}
