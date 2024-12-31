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
    public class Project
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }//FK

        [JsonIgnore]
        public Profile Profile { get; set; } = null!;//Reference Navigation
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Technology> Technologies { get; set; } = [];

        //public string Status { get; set; }
    }
}
