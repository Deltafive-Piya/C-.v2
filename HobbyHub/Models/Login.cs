#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace HobbyHub.Models;

public class Login
{
    [Required]                              //* (Required) Email (with UserDefined Attribute) for Logging in
    public string LogUName { get; set; } 

    [Required]                              //* (Required) Password for Logging in
    [MinLength(8)]      
    [DataType(DataType.Password)]           //* We dont want any lawsuits
    public string LogPassword { get; set; } 
}
