#pragma warning disable CS8618 //ready...
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.Models; //Is the namsepace correct?

public class Dish                     //Is modelName correct?
{

    [Key]                           //PK
    public int DishId { get; set; } //PK

    [Required]
    [MinLength(2)]
    public string DishName { get; set; }
    [Required]
    [Range(1, Int32.MaxValue, ErrorMessage = "Must have calories")]
    public int Calories { get; set; }
    [Required]
    [Range(1, 5)]
    public string Tastiness { get; set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public int ChefId {get;set;}
    //hook
    public Chef? Cook {get;set;}
}
