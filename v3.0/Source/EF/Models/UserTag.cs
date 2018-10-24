using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class UserTag
    {
        public Guid UserId { get; set; }
        public Guid TagId { get; set; }

        public Tag Tag { get; set; }
        public User User { get; set; }
    }
}
