//*- MyContext tells MySQL what tables to make
#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace CouponClipper.Models;
public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) {} //! REMEMBER WILL NOT CHANGE
    public DbSet<User> Users {get;set;}                         //* Users Table; will use _context.Users for DQL
    public DbSet<Coupon> Coupons {get;set;}                     //* Coupon Table; will use _context.Coupons for DQL
    public DbSet<CouponHasUsers> CouponHasUsers {get;set;}      //* CouponHasUsers Table; will use _context.CouponHasUsers for DQL
}