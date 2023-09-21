#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CouponClipper.Models;                              //
public class Coupon
{
    public int CouponId { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [MinLength(10, ErrorMessage = "Title must be at least 10 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    public int PostedByUserId { get; set; }
    public User PostedByUser { get; set; }

    public List<Usage> Usages { get; set; } = new List<Usage>();
}
// Finish this