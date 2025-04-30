using System;
using Microsoft.EntityFrameworkCore;
using ReStore.API.Entities;

namespace ReStore.API.Data;

public class StoreContext(DbContextOptions options) : DbContext(options)
{
   public required DbSet<Product> Products { get; set; }
   public DbSet<Basket> Baskets { get; set; }
  
}
