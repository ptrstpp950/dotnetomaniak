﻿using System;
using System.Collections.Generic;
using Kigg.DomainObjects;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class UserScore
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public UserAction ActionType { get; set; }
        public decimal Score { get; set; }

        public User User { get; set; }
    }
}
