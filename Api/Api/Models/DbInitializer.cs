using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Api.Models;

namespace Api.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            ToDoContext context = applicationBuilder.ApplicationServices.GetRequiredService<ToDoContext>();

            if (!context.CustomerItems.Any())
            {
                context.AddRange(

                    new Customer {
                      Name = "Hanna Montana", Id = 1, IsSubscribedToNewsLetter = false, DateOfBirth = new DateTime(2000, 6, 21)   
                   }
                    ,
                     new Customer
                     {
                         Name = "Hanna Montana",
                         Id = 1,
                         IsSubscribedToNewsLetter = false,
                         DateOfBirth = new DateTime(2000, 6, 21)
                     }
                   
                );
            }
        

            context.SaveChanges();
        }
    }
}
