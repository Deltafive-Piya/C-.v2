#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace HobbyHub.Models;            //Project HobbyHub

public class Hobby                      //ModelName Hobby
{

    [Key]
    public int HobbyId { get; set; }

    [Required]
    [MinLength(2)]
    public string HobbyName { get; set; }

    [Required]
    public string HobbyDescription { get; set; }

    public int EnthusiastCount { get; set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<HobbyHasUsers> AllUsers {get;set;} = new List<HobbyHasUsers>(); //Todo establish m-m realation many user many coupons

    //? NOT USING THIS, kept for thought
    //* Hook- establish what one user made this coupon, organizer may !exist later
    public User? Inventor {get;set;}      
    public int UserId {get;set;}
}