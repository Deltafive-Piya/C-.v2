#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace CouponClipper.Models;            //Is the namsepace correct?

public class Coupon                       //Is modelName correct?
{

    [Key]                               //PK
    public int CouponId { get; set; } //PK

    [Required]
    [MinLength(2)]
    public string CouponCode { get; set; }

    [Required]
    [MinLength(2)]
    public string CouponUsedAt { get; set; }
    
    [Required]
    [MinLength(10)]
    public string CouponDescription { get; set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<CouponHasUsers> AllUsers {get;set;} = new List<CouponHasUsers>(); //establish m-m realation many user many coupons
    
    public User? Organizer {get;set;}      //Hook- establish what one user made this coupon, organizer may !exist later
    public int UserId {get;set;}           //REMEMBER these work together...
}