using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyHomeProject.Models
{
    public class MyHomeProjectContext : DbContext
    {
        public MyHomeProjectContext (DbContextOptions<MyHomeProjectContext> options)
            : base(options)
        {

        }

        public DbSet<Ingridient> Ingridients { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Dish_Ingrident> Dish_Ingridents { get; set; }

        public DbSet<User> Users { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish_Ingrident>().HasKey(c => new { c.DishId, c.IngridientId });

            modelBuilder.Entity<Dish_Ingrident>()
                .HasOne(c => c.Dish)
                .WithMany(di => di.Dish_Ingridients)
                .HasForeignKey(c => c.DishId);

            modelBuilder.Entity<Dish_Ingrident>()
                .HasOne(bc => bc.Ingridient)
                .WithMany(di => di.Dish_Ingridients)
                .HasForeignKey(bc => bc.IngridientId);


        }

    }
}
