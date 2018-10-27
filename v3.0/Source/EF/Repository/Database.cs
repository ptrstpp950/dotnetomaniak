using System;
using System.Data;
using System.IO;
using Kigg.LinqToSql.Repository;
using Microsoft.EntityFrameworkCore;

namespace Kigg.LinqToSql.DomainObjects
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using DomainObjects;
    
    public partial class dotnetomaniakContext : IDatabase
    {

        public IQueryable<Category> CategoryDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<Category>();
            }
        }

        public IQueryable<Tag> TagDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<Tag>();
            }
        }

        public IQueryable<Story> StoryDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<Story>();
            }
        }

        public IQueryable<StoryComment> CommentDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<StoryComment>();
            }
        }

        public IQueryable<StoryVote> VoteDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<StoryVote>();
            }
        }

        public IQueryable<StoryMarkAsSpam> MarkAsSpamDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<StoryMarkAsSpam>();
            }
        }

        public IQueryable<StoryTag> StoryTagDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<StoryTag>();
            }
        }

        public IQueryable<StoryView> StoryViewDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<StoryView>();
            }
        }

        public IQueryable<UserTag> UserTagDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<UserTag>();
            }
        }

        public IQueryable<User> UserDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<User>();
            }
        }

        public IQueryable<UserScore> UserScoreDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<UserScore>();
            }
        }

        public IQueryable<Achievement> AchievementsDataSource
        {
            [DebuggerStepThrough]
            get 
            { 
                return GetQueryable<Achievement>(); 
            }
        }

        public IQueryable<UserAchievement> UserAchievementsDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<UserAchievement>();
            }
        }

        public IQueryable<CommentSubscribtion> CommentSubscribtionDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<CommentSubscribtion>();
            }
        }

        public IQueryable<KnownSource> KnownSourceDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<KnownSource>();
            }
        }

        public IQueryable<Recommendation> RecommendationDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<Recommendation>();
            }
        }

        public IQueryable<CommingEvent> CommingEventDataSource
        {
            [DebuggerStepThrough]
            get
            {
                return GetQueryable<CommingEvent>();
            }
        }

        public virtual IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class
        {
            return this.Query<TEntity>();
        }

        public IEnumerable<T> ExecuteQuery<T>(string query, params object[] parameters)
        {
            if(typeof(T)!=typeof(KnownSource))
                throw new NotImplementedException();
            return (IEnumerable<T>) KnownSource.FromSql(query, parameters);
        }

        public void Insert<TEntity>(TEntity instance) where TEntity : class
        {
            Add(instance);
            SaveChanges();
        }

        public void InsertAll<TEntity>(IEnumerable<TEntity> instances) where TEntity : class
        {
            AddRange(instances);
            SaveChanges();
        }

        public void Delete<TEntity>(TEntity instance) where TEntity : class
        {
            Remove(instance);
            SaveChanges();
        }

        public void DeleteAll<TEntity>(IEnumerable<TEntity> instances) where TEntity : class
        {
            RemoveRange(instances);
            SaveChanges();
        }

        public void SubmitChanges()
        {
            SaveChanges();
        }

        /*public IQueryable<StorySearchResult> StorySearch(string query)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CommentSearchResult> CommentSearch(string query)
        {
            throw new NotImplementedException();
        }*/

        public int _10kPoints()
        {
            throw new NotImplementedException();
        }

        public int StoryAdder()
        {
            throw new NotImplementedException();
        }

        public int EarlyBird()
        {
            throw new NotImplementedException();
        }

        public int _1kPoints()
        {;
            throw new NotImplementedException();
        }

        public int Commeter()
        {
            throw new NotImplementedException();
        }

        public int NightOwl()
        {
            throw new NotImplementedException();
        }

        public int UpVoter()
        {
            throw new NotImplementedException();
        }

        public int GoodStory()
        {
            throw new NotImplementedException();
        }

        public int GreatStory()
        {
            throw new NotImplementedException();
        }

        public int PopularStory()
        {
            throw new NotImplementedException();
        }

        public int MultiAdder()
        {
            throw new NotImplementedException();
        }

        public int Globetrotter()
        {
            throw new NotImplementedException();
        }

        public int Dotnetomaniak()
        {
            throw new NotImplementedException();
        }

        public int Facebook()
        {
            throw new NotImplementedException();
        }
    }
}