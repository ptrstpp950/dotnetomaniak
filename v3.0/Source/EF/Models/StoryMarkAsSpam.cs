using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class StoryMarkAsSpam
    {
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public string IPAddress { get; set; }
        public DateTime Timestamp { get; set; }

        public Story Story { get; set; }
        public User User { get; set; }
    }
}
