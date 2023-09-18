#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Crudelicious.Models;                              //
public class Dish                                           //
{
    [Key]                           //PK Already [Required] by convention
    public int DishId {get;set;}    //PK  

    [Required]
    public string Name {get;set;}       
    [Required]                
    public string Chef {get;set;}
    [Required]
    [Range(1,5, ErrorMessage ="FistToFive- 1(inedible) - 5(sublime) please...")] 
    public int Tastiness {get;set;}
    [Required]
    [Range(1,int.MaxValue, ErrorMessage ="No calorie-free meals here...")]                       
    public int Calories {get;set;}
    [Required]
    public string Description {get;set;}                          

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

}