using System.ComponentModel.DataAnnotations;

namespace SimpleCMS.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}