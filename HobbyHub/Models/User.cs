#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;            //* Validations
using System.ComponentModel.DataAnnotations.Schema;
namespace HobbyHub.Models;

public class User                      
{
    [Key]                           //PK
    public int UserId { get; set; } //PK

    [Required]                      //*Fname Required, minimum length 2
    [MinLength(2)]
    public string FName { get; set; }

    [Required]                      //*Lname Required, minimum length 2
    [MinLength(2)]
    public string LName { get; set; }

    [Required]
    [MinLength(3)] //Todo- Check limits
    [MaxLength (15)] //Todo- Check limits
    [UniqueUName]
    public string UName { get; set; }

    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)] 
    public string Password { get; set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public List<Hobby> Hobbies {get;set;} = new List<Hobby>(); //List Instance of Hobby @Model.Hobbies.XxxXxx

    public List<HobbyHasUsers> IsUAs {get;set;} = new List<HobbyHasUsers>(); //establish m-m relation many user many Hobbies

    [NotMapped]                                             
    [Compare("Password")]
    [DataType(DataType.Password)] 
    public string ConfirmPassword {get; set;}
}


public class UniqueUNameAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null) return new ValidationResult("User-Name is required");                             //* If no value, errormessage0
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));

        if(_context.Users.Any(e => e.UName == value.ToString()))                                            //* IF- Any existing DB.UNames match input...
        {   return new ValidationResult("UName must be unique!");                                               //* errormessage1
        } else return ValidationResult.Success;                                                                 //* else returns Successful validation!
    }
}