using System.ComponentModel.DataAnnotations;

namespace Desarrolladores_UDC.DTOs
{
    public class SocialLinksUpdateDto
    {
        [Url]
        public string? Github { get; set; }
        [Url]
        public string? Linkedin { get; set; }
        [Url]
        public string? Web { get; set; }
    }
}
