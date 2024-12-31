using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DB
{
    public class SocialLinks
    {
        [Key, ForeignKey("User")]
        public int ProfileId { get; set; }

        [JsonIgnore]
        public Profile Profile { get; set; } = null!;

        [Url]
        public string? Github { get; set; }
        [Url]
        public string? Linkedin { get; set; }
        [Url]
        public string? Web { get; set; }
    }
}
