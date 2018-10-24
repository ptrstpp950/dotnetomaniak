using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class StoryTag
    {
        public Guid StoryId { get; set; }
        public Guid TagId { get; set; }

        public Story Story { get; set; }
        public Tag Tag { get; set; }
    }
}
