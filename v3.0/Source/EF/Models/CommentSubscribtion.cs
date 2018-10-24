using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class CommentSubscribtion
    {
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }

        public Story Story { get; set; }
        public User User { get; set; }
    }
}
