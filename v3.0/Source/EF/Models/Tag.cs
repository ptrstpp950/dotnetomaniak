using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class Tag
    {
        public Tag()
        {
            StoryTag = new HashSet<StoryTag>();
            UserTag = new HashSet<UserTag>();
        }

        public Guid Id { get; set; }
        public string UniqueName { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<StoryTag> StoryTag { get; set; }
        public ICollection<UserTag> UserTag { get; set; }
    }
}
