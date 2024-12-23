using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Comment
    {
        public int Id {  get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; } = null!;
        public int ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;
        public string Content { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool WasEdited { get; set; }
    }
}
