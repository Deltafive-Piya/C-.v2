#pragma warning disable CS8618 //maybe exam ready
using System.ComponentModel.DataAnnotations;

namespace LoginAndRegistration.Models; //Is the namsepace correct?

public class Login                       //Is modelName correct?
{

    [Required]
    [EmailAddress] 
    public string LogEmail { get; set; } //Change Email to Log Email

    [Required]                                       //
    [MinLength(8)]     
    [DataType(DataType.Password)]                               //
    public string LogPassword { get; set; } //Ditto//
}