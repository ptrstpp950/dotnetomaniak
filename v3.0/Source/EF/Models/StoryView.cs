using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class StoryView
    {
        public long Id { get; set; }
        public Guid StoryId { get; set; }
        public DateTime Timestamp { get; set; }
        public string IPAddress { get; set; }

        public Story Story { get; set; }
    }
}
