#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FirstConnection.Models;
public class Dish
{
    [Key]
    public int DishId {get;set;} //PK
    public string DishName {get;set;}
    public string Origin {get;set;}
    public bool HasPeanuts {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

}