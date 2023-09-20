#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class Guest                       
{

    [Key]                           //PK
    public int GuestId { get; set; } //PK

    [Required]
    [MinLength(2)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)] 
    public string Password { get; set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public List<Wedding> Weddings {get;set;} = new List<Wedding>();

    public List<WeddingHasGuests> Rsvps {get;set;} = new List<WeddingHasGuests>(); //establish m-m relation many guest many weddings

    [NotMapped]                                             //? is cpass notmapped?
    [Compare("Password")]
    [DataType(DataType.Password)] 
    public string ConfirmPassword { get; set; }
}


public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("Email is required");
        }
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));

        if(_context.Guests.Any(e => e.Email == value.ToString())) //Guests matches what the Workbench table should be called
        {
            return new ValidationResult("Email must be unique!");
        } else {
            return ValidationResult.Success;
        }
    }
}