using EVE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusDriver_BusInfo>().HasKey(am => new
            {

                am.BusDriverID,
                am.BusInfoID
            });

            //Lidhja many to many mes BusDriver dhe BusInfo
            modelBuilder.Entity<BusDriver_BusInfo>().HasOne(m => m.BusInfo).WithMany(am => am.BusDrivers_BusInfos).HasForeignKey(m => m.BusInfoID);
            modelBuilder.Entity<BusDriver_BusInfo>().HasOne(m => m.BusDriver).WithMany(am => am.BusDrivers_BusInfos).HasForeignKey(m => m.BusDriverID);


            base.OnModelCreating(modelBuilder);
        }
        
        //Insertimi i tabelave per BusInfos, BusDrivers
        public DbSet<BusDriver> BusDrivers { get; set; }
        public DbSet<BusInfo> BusInfos { get; set; }
        public DbSet<BusDriver_BusInfo> BusDrivers_BusInfos { get; set; }


        //Orders related tables

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderTicket> OrderTickets { get; set; }
        public DbSet<TicketCart> TicketCarts { get; set; }

    }
}
