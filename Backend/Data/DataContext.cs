using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutWebAPi.Models;

namespace LayoutWebAPi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Warehouse> warehouses { get; set; }
        public DbSet<Properties> properties { get; set; }
        public DbSet<Module> modules { get; set; }
        public DbSet<LayoutObject> layout_objects { get; set; }
        public DbSet<Layer> layers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Module's Warehouse FK
            modelBuilder.Entity<Module>()
                .HasOne(m => m.warehouse)
                .WithMany(w => w.modules)
                .HasForeignKey(m => m.warehouse_id);


            //LayoutObject's Module FK
            modelBuilder.Entity<LayoutObject>()
                .HasOne(lo => lo.module)
                .WithMany(m => m.layout_objects)
                .HasForeignKey(lo => lo.module_id);


            //Layer's LayoutObject FK
            modelBuilder.Entity<Layer>()
                .HasOne(l => l.layout_object)
                .WithMany(lo => lo.layers)
                .HasForeignKey(l => l.layout_object_id);

            //Properties' LayoutObject FK
            modelBuilder.Entity<LayoutObject>()
                .HasOne(lo => lo.properties)
                .WithOne(p => p.layout_object)
                .HasForeignKey<Properties>(lo => lo.layout_object_id);
        }
    }
}
