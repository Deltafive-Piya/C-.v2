#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Models;
public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) {} //REMEMBER WILL NOT CHANGE
    public DbSet<Guest> Guests {get;set;}                         //Users Table; will use _context.Users for DQL
    public DbSet<Wedding> Weddings {get;set;}                        //Users Table; will use _context.Users for DQL
    public DbSet<WeddingHasGuests> WeddingHasGuests {get;set;}                        //Users Table; will use _context.Users for DQL
}