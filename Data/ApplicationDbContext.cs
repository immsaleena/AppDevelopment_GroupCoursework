using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using coursework.Models;

namespace coursework.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<coursework.Models.Category> Category { get; set; }
        public DbSet<coursework.Models.Customer> Customer { get; set; }
        public DbSet<coursework.Models.Item> Item { get; set; }
        public DbSet<coursework.Models.Sales> Sales { get; set; }
        public DbSet<coursework.Models.SalesDetails> SalesDetails { get; set; }
        public DbSet<coursework.Models.Purchase> Purchase { get; set; }
        public DbSet<coursework.Models.PurchaseDetails> PurchaseDetails { get; set; }
        public DbSet<coursework.Models.Stock> Stock { get; set; }
    }
}
