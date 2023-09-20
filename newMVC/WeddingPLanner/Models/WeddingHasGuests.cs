#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models;

public class WeddingHasGuests
{
    [Key]    
    public int GuestWeddingId { get; set; } 

    public int GuestId { get; set; }    //Guest table
    public int WeddingId { get; set; }  //Wedding Table

    public Guest? Guest { get; set; }    
    public Wedding? Wedding { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}