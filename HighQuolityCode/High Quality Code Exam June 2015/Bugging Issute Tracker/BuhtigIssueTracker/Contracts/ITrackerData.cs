namespace BuhtigIssueTracker.Contracts
{
    using System.Collections.Generic;
    using BuhtigIssueTracker.Issues;
    using BuhtigIssueTracker.Users;
    using Wintellect.PowerCollections;    
    
    public interface ITrackerData
    {
        User CurrentUser { get; set; }

        IDictionary<string, User> Users { get; }

        OrderedDictionary<int, Issue> IssuesById { get; }

        MultiDictionary<string, Issue> IssuesByUser { get; }

        MultiDictionary<string, Issue> IssuesByTags { get; }

        MultiDictionary<User, Comment> UsersAllComments { get; }

        int AddIssue(Issue p);

        void RemoveIssue(Issue p);
    }    
}