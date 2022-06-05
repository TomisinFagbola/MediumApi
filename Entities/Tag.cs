﻿using System.Collections.Generic;

namespace Medium.Api.Entities
{
    public class Tag
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
    }
}
