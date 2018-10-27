using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class Recommendation
    {
        public Guid Id { get; set; }
        public string RecommendationLink { get; set; }
        public string RecommendationTitle { get; set; }
        public string ImageLink { get; set; }
        public string ImageTitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Position { get; set; }
        public string Email { get; set; }
        public bool NotificationIsSent { get; set; }
        public bool IsBanner { get; set; }
    }
}
