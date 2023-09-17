#pragma warning disable CS8618              //DisableWarning- null values
using System.ComponentModel.DataAnnotations;

namespace DojoSurveyWithValidations;
public class User
{
    // OBJECTIVE 1A) Name, Location, and Favorite Language should all be required.
    [Required]
    // OBJECTIVE 2) Name should be no less than 2 characters.
    [MinLength(2)]
    public string Name {get;set;}
    // OBJECTIVE 1B) Name, Location, and Favorite Language should all be required.
    [Required]
    public string Location {get;set;}
    // OBJECTIVE 1C) Name, Location, and Favorite Language should all be required.
    [Required]
    public string Language {get;set;}
    // OBJECTIVE 3) Comment isn't required, but if included, should be more than 20 characters.
    [MaxLength(20)]
    public string Comment {get;set;}
}
