using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options )
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Movies> MovieItems { get; set; }
        public DbSet<Customer> CustomerItems { get; set; }

        public DbSet<MembershipType> MembershipTypeItems { get; set; }
    }
}
