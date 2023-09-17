#pragma warning disable CS8618
namespace SessionWorkshop.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Required]
    public string Name {get;set;}

    public bool ShowName => !string.IsNullOrEmpty(Name);
}
