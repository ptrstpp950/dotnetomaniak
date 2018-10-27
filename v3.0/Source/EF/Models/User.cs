using System;
using System.Collections.Generic;
using Kigg.DomainObjects;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class User
    {
        public User()
        {
            CommentSubscribtion = new HashSet<CommentSubscribtion>();
            Story = new HashSet<Story>();
            StoryComment = new HashSet<StoryComment>();
            StoryMarkAsSpam = new HashSet<StoryMarkAsSpam>();
            StoryVote = new HashSet<StoryVote>();
            UserAchievements = new HashSet<UserAchievement>();
            UserScores = new HashSet<UserScore>();
            UserTags = new HashSet<UserTag>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsLockedOut { get; set; }
        public Roles Role { get; set; }
        public DateTime LastActivityAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FbId { get; set; }

        public ICollection<CommentSubscribtion> CommentSubscribtion { get; set; }
        public ICollection<Story> Story { get; set; }
        public ICollection<StoryComment> StoryComment { get; set; }
        public ICollection<StoryMarkAsSpam> StoryMarkAsSpam { get; set; }
        public ICollection<StoryVote> StoryVote { get; set; }
        public ICollection<UserAchievement> UserAchievements { get; set; }
        public ICollection<UserScore> UserScores { get; set; }
        public ICollection<UserTag> UserTags { get; set; }
    }
}
