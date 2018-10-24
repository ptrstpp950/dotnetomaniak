using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class UserAchievement
    {
        public DateTime DateAchieved { get; set; }
        public Guid AchievementId { get; set; }
        public Guid UserId { get; set; }
        public bool Displayed { get; set; }

        public Achievement Achievement { get; set; }
        public User User { get; set; }
    }
}
