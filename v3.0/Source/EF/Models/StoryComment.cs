using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class StoryComment
    {
        public Guid Id { get; set; }
        public string HtmlBody { get; set; }
        public string TextBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public string IPAddress { get; set; }
        public bool IsOffended { get; set; }

        public Story Story { get; set; }
        public User User { get; set; }
    }
}
