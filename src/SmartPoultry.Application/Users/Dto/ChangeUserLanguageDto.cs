using System.ComponentModel.DataAnnotations;

namespace SmartPoultry.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}