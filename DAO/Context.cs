
using System;
using Microsoft.EntityFrameWorkCore;

namespace DAO;

public class Context : DbContext
{
    public DbSet<Address> address { get; set; }
    public DbSet<Client> clients { get; set; }
    public DbSet<Owner> owners { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Purchase> purchases { get; set; }
    public DbSet<Stocks> stocks { get; set; }
    public DbSet<Store> stores { get; set; }
    public DbSet<WishList> wishLists { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(a => a.id);
            entity.Property(a => a.city).IsRequired();
            entity.Property(a => a.state).IsRequired();
            entity.Property(a =>a.country).IsRequired();
            entity.Property(a =>a.postal_code).IsRequired();
            entity.Property(a=>a.street).IsRequired();

            

        })
        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(a=> a.name).IsRequired();
            entity.Property(a=> a.email).IsRequired();
            entity.Property(a=> a.state).IsRequired();
            entity.Property(a=> a.country).IsRequired();
            entity.Property(a=> a.podtal_code).IsRequired();
            entity.Property(a=> a.street).IsRequired();

            entity.HasOne(a=> a.address);
            
           
        })
        modelBuilder.Entity<Owner>(entity =>
        {
            entity.Property(a=> a.name).IsRequired();
            entity.Property(a=> a.email).IsRequired();
            entity.Property(a=> a.state).IsRequired();
            entity.Property(a=> a.country).IsRequired();
            entity.Property(a=> a.podtal_code).IsRequired();
            entity.Property(a=> a.street).IsRequired();

            entity.HasOne(a=> a.address);
           
        })
        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(a =>a.id);
            entity.Property(a=>a.number_confirmation).IsRequired();
            entity.Property(a=> a.number_nf).IsRequired();
            entity.Property(a=> a.payment_type).IsRequired();
            entity.Property(a=> a.purchase_status).IsRequired();
            entity.Property(a=> a.data_purchase).IsRequired();

            entity.HasOne(a=>a.client);
            entity.HasOne(a=>a.product);
            entity.HasOne(a=>a.store);
        })
        modelBuilder.Entity<Stocks>(entity =>
        {
            entity.HasKey(a => a.id);
            entity.Property(a=>a.quantity).IsRequired();
            entity.HasOne(a=> a.store);
            entity.HasOne(a=> a.product);
        })
        modelBuilder.Entity<WishList>(entity =>
        {
            entity.HasOne(a=>a.client);
            entity.HasOne(a=>a.product);
        }
        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(a => a.id);
            entity.Property(a=>a.name).IsRequired();
            entity.Property(a=>a.CNPJ).IsRequired();
            entity.HasOne(a=>a.owner);
        }
      
    }




    //https://docs.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
    //https://docs.microsoft.com/pt-br/ef/ef6/modeling/code-first/data-annotations
}
