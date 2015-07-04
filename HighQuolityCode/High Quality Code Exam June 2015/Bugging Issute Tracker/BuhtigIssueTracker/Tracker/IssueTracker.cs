namespace BuhtigIssueTracker.Tracker 
{
    using System;
    using System.Collections.Generic;    
    using System.Linq;
    using BuhtigIssueTracker.Contracts;
    using BuhtigIssueTracker.Enumerations;
    using BuhtigIssueTracker.Issues;
    using BuhtigIssueTracker.Users;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker(ITrackerData data)
        {
            this.Data = data as TrackerData;
        }

        public IssueTracker()
            : this(new TrackerData())
        { 
        }

        // DI: <Dependense on interface so that another kind of data can be used>
        public ITrackerData Data { get; set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.Data.CurrentUser != null)
            {
                return string.Format("There is already a logged in user");
            }

            if (password != confirmPassword)
            {
                return string.Format("The provided passwords do not match", username);
            }

            if (this.Data.Users.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            
            this.Data.Users.Add(username, user);

            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password) 
        {
            if (this.Data.CurrentUser != null)
            {
                return string.Format("There is already a logged in user");
            }

            if (!this.Data.Users.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.Data.Users[username];

            if (user.PasswordHash != User.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            this.Data.CurrentUser = user;

            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            string username = this.Data.CurrentUser.Username;

            this.Data.CurrentUser = null;

            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriorities priority, string[] tags)
        {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var issue = new Issue(
                title, 
                description, 
                priority, 
                tags.Distinct().ToList());

            // DI: <Delegating AddIssue logic to AddIssue method in IData. In this case data can be managed different
            // way in case other data type is used>
            this.Data.AddIssue(issue);             

            return string.Format("Issue {0} created successfully", issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Data.IssuesById[issueId];

            if (!this.Data.IssuesByUser[this.Data.CurrentUser.Username].Contains(issue))
            {
                return string.Format(
                    "The issue with ID {0} does not belong to user {1}", 
                    issueId, 
                    this.Data.CurrentUser.Username);
            }

            this.Data.RemoveIssue(issue);            

            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int issueId, string stringValue)
        {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            var comment = new Comment(this.Data.CurrentUser, stringValue);

            issue.AddComment(comment);
            this.Data.UsersAllComments[this.Data.CurrentUser].Add(comment);

            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues() 
        {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var issues = this.Data.IssuesByUser[this.Data.CurrentUser.Username];

            var newIssues = issues;

            if (!issues.Any())
            {
                // PERFORMANCE: <There is no need that we itterate over all issues in case the current user has none>
                // var result = "";
                // foreach (var issue in Data.IssuesByUser)
                // {
                //    result += issue.Value.Select(iss => iss.Comments.Select(c => c.Content)).ToString();
                // }
                return "No issues";
            }

            return string.Join(
                Environment.NewLine, 
                newIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }

        public string GetMyComments() 
        {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var comments = new List<Comment>();

            this.Data.IssuesById.Select(i => i.Value.Comments).ToList().ForEach(item => comments.AddRange(item));
            var resultComments = comments.Where(c => c.Author.Username == this.Data.CurrentUser.Username).ToList();
            var strings = resultComments.Select(x => x.ToString());

            if (!strings.Any())
            {
                return "No comments";
            }

            return string.Join(Environment.NewLine, strings);
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length < 1)
            {
                return "There are no tags provided";
            }

            if (this.Data.IssuesByTags.Count < 1)
            {
                return "No issues";
            }

            var issues = new List<Issue>();

            foreach (var tag in tags)
            {
                issues.AddRange(this.Data.IssuesByTags[tag]);
            }

            if (!issues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            var newIssue = issues.Distinct();

            return string
                .Join(
                Environment.NewLine, 
                newIssue.OrderByDescending(x => x.Priority).ThenBy(x => x.Title).Select(x => x.ToString()));
        }
    }
}