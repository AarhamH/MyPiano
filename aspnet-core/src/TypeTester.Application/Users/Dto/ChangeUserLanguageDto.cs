using System.ComponentModel.DataAnnotations;

namespace TypeTester.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}