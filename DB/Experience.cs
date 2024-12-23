using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Experience
    {
        public int Id { get; set; }//PK
        public int ProfileId { get; set; }//FK
        public Profile Profile { get; set; } = null!;//Reference Navigation
        public string Title { get; set; }
        public string Description { get; set; }
        public string Enterprise { get; set; }
        public ICollection<Technology> Technologies { get; set; } = [];
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
