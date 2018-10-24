using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class Story
    {
        public Story()
        {
            CommentSubscribtion = new HashSet<CommentSubscribtion>();
            StoryComment = new HashSet<StoryComment>();
            StoryMarkAsSpam = new HashSet<StoryMarkAsSpam>();
            StoryTag = new HashSet<StoryTag>();
            StoryView = new HashSet<StoryView>();
            StoryVote = new HashSet<StoryVote>();
        }

        public Guid Id { get; set; }
        public string UniqueName { get; set; }
        public string Title { get; set; }
        public string HtmlDescription { get; set; }
        public string TextDescription { get; set; }
        public string Url { get; set; }
        public string UrlHash { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public string Ipaddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActivityAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int? Rank { get; set; }
        public DateTime? LastProcessedAt { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
        public ICollection<CommentSubscribtion> CommentSubscribtion { get; set; }
        public ICollection<StoryComment> StoryComment { get; set; }
        public ICollection<StoryMarkAsSpam> StoryMarkAsSpam { get; set; }
        public ICollection<StoryTag> StoryTag { get; set; }
        public ICollection<StoryView> StoryView { get; set; }
        public ICollection<StoryVote> StoryVote { get; set; }
    }
}
