using System.ComponentModel.DataAnnotations;

namespace MySpaProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}