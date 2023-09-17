#pragma warning disable CS8618
namespace DateValidator.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Required]
    public string Name {get;set;}
    [Required]
    [DataType(DataType.Date)]  // DatePicker UI
    [FutureDate]
    public DateTime Birthday {get;set;}
}

public class FutureDateAttribute : ValidationAttribute
{
    // Logic for our method
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if((DateTime)value > DateTime.Now)
        {
            return new ValidationResult("Nice try future boi");
        } else {
            return ValidationResult.Success;
        }
    }
}