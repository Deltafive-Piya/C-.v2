//*- MyContext tells MySQL what tables to make
#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace HobbyHub.Models;
public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) {} //REMEMBER WILL NOT CHANGE
    public DbSet<User> Users {get;set;}                          //* Users Table; will use _context.Users for DQL
    public DbSet<Hobby> Hobbies {get;set;}                       //* Hobbies Table; will use _context.Hobbies for DQL
    public DbSet<HobbyHasUsers> HobbyHasUsers {get;set;}         //* HobbyHasUsers Table; will use _context.HobbyHasUsers for DQL
}