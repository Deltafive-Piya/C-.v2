#pragma warning disable CS8618 //maybe exam ready...
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.Models; //Is the namsepace correct?

public class Chef                       //Is modelName correct?
{

    [Key]                           //PK
    public int ChefId { get; set; } //PK

    [Required]
    [MinLength(2)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    public string LastName { get; set; }
    
    [Required (ErrorMessage = "must enter age")]
    [AgeCheck (ErrorMessage = "must be over 18")]
    public DateTime Age { get; set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<Dish> AllDishes {get;set;} = new List<Dish>();
}

public class AgeCheck : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is DateTime Age && Age < DateTime.Now)
        {
            int YearsOld = DateTime.Now.Year - Age.Year; //comparing year only, not month and days
            return YearsOld >= 18;
        }
        return false; // if not valid age or future person
    }
}