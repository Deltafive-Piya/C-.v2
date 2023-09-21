#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CouponClipper.Models;   
public class Usage
{
    public int UsageId { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int CouponId { get; set; }
    public Coupon Coupon { get; set; }
}

//middleTable