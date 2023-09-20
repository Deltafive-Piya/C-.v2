#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models;            //Is the namsepace correct?

public class Wedding                       //Is modelName correct?
{

    [Key]                               //PK
    public int WeddingId { get; set; } //PK

    [Required]
    [MinLength(2)]
    public string WedderOne { get; set; }

    [Required]
    [MinLength(2)]
    public string WedderTwo { get; set; }
    
    [Required (ErrorMessage = "must enter Marriage Date")]
    [DateCheck (ErrorMessage = "must be in future")]
    public DateTime MarriageDate { get; set; }
    
    [Required]
    public string Address { get; set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<WeddingHasGuests> AllGuests {get;set;} = new List<WeddingHasGuests>(); //establish m-m realation many guest many weddings
    
    public Guest? Organizer {get;set;}      //establish what one guest made this wedding, organizer may !exist later
    public int GuestId {get;set;}           //REMEMBER these work together...
}

public class DateCheck : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is DateTime MarriageDate && MarriageDate > DateTime.Now)
        {
            return true;
        }
        return false; // if not valid Date or future MarriageDate 
    }
}