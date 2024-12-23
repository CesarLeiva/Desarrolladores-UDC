using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Profile> Profiles { get; set; } = [];
        public ICollection<Project> Projects { get; set; } = [];
        public ICollection<Experience> Experiences { get; set; } = [];
    }
}
