using System.ComponentModel.DataAnnotations;

namespace SixMan.ChiMa.Application.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [StringLength(32)]
        public string Theme { get; set; }
    }
}
