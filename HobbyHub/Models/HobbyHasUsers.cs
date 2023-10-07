#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace HobbyHub.Models;

public class HobbyHasUsers
{
    [Key]    
    public int UserHobbyId { get; set; } 

    public int UserId { get; set; }    //User table
    public int HobbyId { get; set; }  //Hobby Table

    public User? User { get; set; }    
    public Hobby? Hobby { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}