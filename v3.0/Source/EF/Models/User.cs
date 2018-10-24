using System;
using System.Collections.Generic;

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
            UserAchievement = new HashSet<UserAchievement>();
            UserScore = new HashSet<UserScore>();
            UserTag = new HashSet<UserTag>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsLockedOut { get; set; }
        public int Role { get; set; }
        public DateTime LastActivityAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FbId { get; set; }

        public ICollection<CommentSubscribtion> CommentSubscribtion { get; set; }
        public ICollection<Story> Story { get; set; }
        public ICollection<StoryComment> StoryComment { get; set; }
        public ICollection<StoryMarkAsSpam> StoryMarkAsSpam { get; set; }
        public ICollection<StoryVote> StoryVote { get; set; }
        public ICollection<UserAchievement> UserAchievement { get; set; }
        public ICollection<UserScore> UserScore { get; set; }
        public ICollection<UserTag> UserTag { get; set; }
    }
}
