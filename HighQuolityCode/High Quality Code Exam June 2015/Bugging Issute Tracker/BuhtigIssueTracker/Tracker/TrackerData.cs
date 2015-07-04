namespace BuhtigIssueTracker.Tracker
{
    using System.Collections.Generic;
    using BuhtigIssueTracker.Contracts;
    using BuhtigIssueTracker.Issues;
    using BuhtigIssueTracker.Users;
    using Wintellect.PowerCollections;

    public class TrackerData : ITrackerData
    {
        private const int IssueIdStartingNumber = 1;

        private int nextIssueId;

        public TrackerData()
        {
            this.nextIssueId = IssueIdStartingNumber;
            this.Users = new Dictionary<string, User>();
            this.Issues = new MultiDictionary<Issue, string>(true);
            this.IssuesById = new OrderedDictionary<int, Issue>();
            this.IssuesByUser = new MultiDictionary<string, Issue>(true);
            this.UsersAllComments = new MultiDictionary<User, Comment>(true);
            this.Comments = new Dictionary<Comment, User>();
            this.IssuesByTags = new MultiDictionary<string, Issue>(true);
        }

        public User CurrentUser { get; set; }

        public IDictionary<string, User> Users { get; set; }

        public MultiDictionary<Issue, string> Issues { get; set; }

        public OrderedDictionary<int, Issue> IssuesById { get; set; }

        public MultiDictionary<string, Issue> IssuesByUser { get; set; }        

        public MultiDictionary<string, Issue> IssuesByTags { get; set; }

        public MultiDictionary<User, Comment> UsersAllComments { get; set; }

        public Dictionary<Comment, User> Comments { get; set; }

        public int AddIssue(Issue issue)
        {
            issue.Id = this.nextIssueId;
            this.IssuesById.Add(issue.Id, issue);
            this.IssuesByUser[this.CurrentUser.Username].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.IssuesByTags[tag].Add(issue);
            }

            return ++this.nextIssueId;
        }

        public void RemoveIssue(Issue issue) 
        {
            this.IssuesByUser[this.CurrentUser.Username].Remove(issue);

            foreach (var tag in issue.Tags)
            {
                this.IssuesByTags[tag].Remove(issue);
            }

            this.IssuesById.Remove(issue.Id);
        }
    }
}