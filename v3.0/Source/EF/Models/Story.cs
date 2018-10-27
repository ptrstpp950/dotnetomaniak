using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class Story
    {
        private string _htmlDescription;

        public Story()
        {
            CommentSubscribtions = new HashSet<CommentSubscribtion>();
            StoryComments = new HashSet<StoryComment>();
            StoryMarkAsSpams = new HashSet<StoryMarkAsSpam>();
            StoryTags = new HashSet<StoryTag>();
            StoryViews = new HashSet<StoryView>();
            StoryVotes = new HashSet<StoryVote>();
        }

        public Guid Id { get; set; }
        public string UniqueName { get; set; }
        public string Title { get; set; }

        public string HtmlDescription
        {
            get => _htmlDescription;
            set
            {
                _htmlDescription = value;
                TextDescription = value.StripHtml().Trim();
            }

        }

        public string TextDescription { get; set; }
        public string Url { get; set; }
        public string UrlHash { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public string IPAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActivityAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int? Rank { get; set; }
        public DateTime? LastProcessedAt { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
        public ICollection<CommentSubscribtion> CommentSubscribtions { get; set; }
        public ICollection<StoryComment> StoryComments { get; set; }
        public ICollection<StoryMarkAsSpam> StoryMarkAsSpams { get; set; }
        public ICollection<StoryTag> StoryTags { get; set; }
        public ICollection<StoryView> StoryViews { get; set; }
        public ICollection<StoryVote> StoryVotes { get; set; }
    }
}
