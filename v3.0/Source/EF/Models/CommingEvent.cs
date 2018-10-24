using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class CommingEvent
    {
        public Guid Id { get; set; }
        public string EventLink { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventPlace { get; set; }
        public string EventLead { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }
        public bool? IsApproved { get; set; }
    }
}
