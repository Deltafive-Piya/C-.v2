#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CouponClipper.Models;

public class User                       
{
    [Key]                           //PK
    public int UserId { get; set; } //PK

    [Required]
    [MinLength(3)]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)] 
    public string Password { get; set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public List<Coupon> Coupons {get;set;} = new List<Coupon>(); //List Instance of Coupon @Model.Coupons.XxxXxx

    public List<CouponHasUsers> IsUAs {get;set;} = new List<CouponHasUsers>(); //establish m-m relation many user many coupons

    [NotMapped]                                             //? is cpass notmapped?
    [Compare("Password")]
    [DataType(DataType.Password)] 
    public string ConfirmPassword {get; set;}
}


public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null) return new ValidationResult("Email is required");
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));

        if(_context.Users.Any(e => e.Email == value.ToString())) // IF- Any existing DB.Emails match input...
        {   return new ValidationResult("Email must be unique!");
        } else return ValidationResult.Success;
    }
}