#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace CouponClipper.Models;

public class CouponHasUsers
{
    [Key]    
    public int UserCouponId { get; set; } 

    public int UserId { get; set; }    //User table
    public int CouponId { get; set; }  //Coupon Table

    public User? User { get; set; }    
    public Coupon? Coupon { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}