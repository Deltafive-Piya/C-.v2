#pragma warning disable CS8618 //maybe exam ready
using System.ComponentModel.DataAnnotations;
// using Microsoft.AspNetCore.Mvc;

namespace WeddingPlanner.Models; //Is the namsepace correct?

public class Login
{

    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string LogEmail { get; set; } //Change Email to Log Email

    [Required]                              //
    [MinLength(8)]      
    [DataType(DataType.Password)]           //
    public string LogPassword { get; set; } //Ditto//
}
