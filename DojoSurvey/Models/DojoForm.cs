using System.ComponentModel.DataAnnotations;// B.I.Supplier for "required" and "ErrorMessage" fxn

using DojoSurvey.Models;
public class DojoForm
{
    // Name
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    // Location
    [Required(ErrorMessage = "Location is required.")]
    public string Location { get; set; }

    // FavoriteLanguage
    [Required(ErrorMessage = "Everyone has a preference!")]
    public string FavoriteLanguage { get; set; }

    // Comment
    public string Comment { get; set; }
}