#pragma warning disable CS8618 //ready
using System.ComponentModel.DataAnnotations;

namespace WeddingPLanner.Models; //Is the namsepace correct?

public class Wedding                       //Is modelName correct?
{

    [Key]                           //PK
    public int WeddingId { get; set; } //PK

    [Required]
    [MinLength(2)]
    public string WedderOne { get; set; }

    [Required]
    [MinLength(2)]
    public string WedderTwo { get; set; }
    
    [Required]
    public DateTime Age { get; set; }
    public string Address { get; set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<WeddingHasGuests> AllGuests {get;set;} = new List<WeddingHasGuests>();
}

