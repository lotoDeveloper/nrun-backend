using System.ComponentModel.DataAnnotations;

namespace Nrun.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}