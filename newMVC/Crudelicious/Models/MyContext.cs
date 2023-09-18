#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace Crudelicious.Models;

public class MyContext : DbContext{
    public MyContext(DbContextOptions options) : base(options) {}

    //Tables for our DB
    public DbSet<Dish> Dishes {get;set;}
}