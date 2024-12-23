using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Profile
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string Title { get; set; }
        public string Description { get; set; }
        public SocialLinks Links { get; set; }
        public ICollection<Experience> Experiences { get; set; } = [];
        public ICollection<Project> Projects { get; set; } = [];
        public ICollection<Technology> Technologies { get; set; } = [];
        public ICollection<Post> Posts { get; set; } = [];
        public ICollection<Comment> Comments { get; set; } = [];
    }
}
