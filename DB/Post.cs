using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DB
{
    public class Post
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }

        [JsonIgnore]
        public Profile Profile { get; set; } = null!;
        public string Content { get; set; }
        public ICollection<Tag> Tags { get; set; } = [];
        public int Likes { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Comment> Comments { get; set; } = [];

        //public PostCategory Category { get; set; }
        //public PostVisibility Visibility { get; set; }
    }
}

//public enum PostCategory
//{
//    General,
//    Oportunity,
//    Academic,
//    Logro,
//    Discusión,

//}

//public enum PostVisibility
//{
//    Public,
//    Private,
//}