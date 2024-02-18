using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace InfraestructureLayer.Areas.Data
{
    public class User : IdentityUser
    {
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "ADM Code")]
        public bool ADM { get; set; }

        [Required]
        [Display(Name = "Período")]
        public string Period { get; set; }

        [Required]
        [Display(Name = "Score")]
        public int Score { get; set; } = 0;
    }
}
