using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class Achievement
    {
        public Achievement()
        {
            UserAchievement = new HashSet<UserAchievement>();
        }

        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }

        public ICollection<UserAchievement> UserAchievement { get; set; }
    }
}
