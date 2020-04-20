using DunkinDonuts.DAL.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DunkinDonuts.DAL
{
    public class DunkinDonutsContext : DbContext
    {
        public DunkinDonutsContext()
        {

        }



        public DunkinDonutsContext(DbContextOptions<DunkinDonutsContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<UserItem> UserItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=LAPTOP-2QC4EM5C\\SQLEXPRESS;Initial Catalog=Shop_DB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
        }

        public static void Seed (ModelBuilder model)
        {
            model.Entity<Item>()
                .HasData((new Item[]
                {
                    new Item()
                    {
                        Id = 1,
                        Name = "Large Iced Coffee",
                        Description = "20oz Iced Coffee",
                        QuantityAvailable = 4,
                        Price = 2.80M
                    },
                    new Item()
                    {
                        Id = 2,
                        Name = "Blueberry Muffin",
                        Description = "Muffin with Blueberries",
                        QuantityAvailable = 4,
                        Price = 1.29M
                    },
                    new Item()
                    {
                        Id = 3,
                        Name = "Breakfast Sandwich",
                        Description = "Sausage, Egg, and Cheese Breakfast Sandwich on a Croissant",
                        QuantityAvailable = 5,
                        Price = 3.95M
                    },
                    new Item()
                    {
                        Id = 4,
                        Name = "Glazed Stick Donut",
                        Description = "",
                        QuantityAvailable = 10,
                        Price = .99M
                    },
                    new Item()
                    {
                        Id = 5,
                        Name = "25ct Box of Munchkins",
                        Description = "Box of 25 Assorted Donuts Holes",
                        QuantityAvailable = 5,
                        Price = 7.95M
                    },
                }));
        }

    }
}