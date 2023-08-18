using System.ComponentModel.DataAnnotations;

namespace StudyHelper.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}