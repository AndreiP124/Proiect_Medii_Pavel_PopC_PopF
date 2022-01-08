using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.RestaurantModel;

namespace Restaurant.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext (DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant.RestaurantModel.Menu_items> Menu_items { get; set; }

        public DbSet<Restaurant.RestaurantModel.Reservation> Reservation { get; set; }
    }
}
