#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace ChefsAndDishes.Models;
public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) {} //REMEMBER WILL NOT CHANGE
    public DbSet<Chef> Chefs {get;set;}                                         //Users Table; will use _context.Users for DQL
    public DbSet<Dish> Dishes {get;set;}                                         //Users Table; will use _context.Users for DQL
}