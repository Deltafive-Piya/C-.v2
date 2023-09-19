#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace LoginAndRegistration.Models;
public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) {} //REMEMBER WILL NOT CHANGE
    public DbSet<User> Users {get;set;}                                         //Users Table; will use _context.Users for DQL
}