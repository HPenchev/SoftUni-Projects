namespace BuhtigIssueTrackerTests
{
    using System;    
    using BuhtigIssueTracker.Contracts;
    using BuhtigIssueTracker.Enumerations;
    using BuhtigIssueTracker.Tracker;    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BuhtigIssueTrackerTests
    {
        private IIssueTracker tracker = new IssueTracker();
        
        [TestMethod]
        public void RegisterUserTest()
        {
            string result = this.tracker.RegisterUser("pesho", "123", "123");
            string expectedResult = "User pesho registered successfully";
            Assert.AreEqual(result, expectedResult);

            this.tracker.LoginUser("pesho", "123");
            result = this.tracker.RegisterUser("gosho", "123", "123");
            expectedResult = "There is already a logged in user";
            Assert.AreEqual(result, expectedResult);
            this.tracker.LogoutUser();

            result = this.tracker.RegisterUser("gosho", "123", "456");
            expectedResult = "The provided passwords do not match";
            Assert.AreEqual(result, expectedResult);

            result = this.tracker.RegisterUser("pesho", "123", "123");
            expectedResult = "A user with username pesho already exists";
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void CreateIssueTest()
        {
            this.tracker.RegisterUser("pesho", "123", "123");
            this.tracker.LoginUser("pesho", "123");

            string result = this.tracker.CreateIssue(
                "Azis", 
                "Azis e pederas",
                IssuePriorities.High, 
                new string[] { "azis", "pederas" });
            string expectedResult = "Issue 1 created successfully";
            Assert.AreEqual(result, expectedResult);

            this.tracker.LogoutUser();
            result = this.tracker.CreateIssue(
               "Azis",
               "Azis e pederas",
               IssuePriorities.High,
               new string[] { "azis", "pederas" });
            expectedResult = "There is no currently logged in user";
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void GetMyIssuesTest()
        {
            this.tracker.RegisterUser("pesho", "123", "123");
            this.tracker.LoginUser("pesho", "123");

            string result = this.tracker.GetMyIssues();
            string expectedResult = "No issues";
            Assert.AreEqual(result, expectedResult);

            this.tracker.CreateIssue(
                "Azis",
                "Azis e pederas",
                IssuePriorities.High,
                new string[] { "azis", "pederas" });            
            this.tracker.LogoutUser();

            this.tracker.RegisterUser("gosho", "123", "123");
            this.tracker.LoginUser("gosho", "123");
            this.tracker.CreateIssue("Issue 1", "This is issue 1", IssuePriorities.High, new string[] { "new" });
            this.tracker.CreateIssue("Issue 2", "This is issue 2", IssuePriorities.High, new string[] { "new" });

            result = this.tracker.GetMyIssues();
            expectedResult = "Issue 1\r\nPriority: ***\r\nThis is issue 1\r\nTags: new\r\n" +
                "Issue 2\r\nPriority: ***\r\nThis is issue 2\r\nTags: new";
            Assert.AreEqual(result, expectedResult);

            this.tracker.LogoutUser();
            result = this.tracker.GetMyIssues();
            expectedResult = "There is no currently logged in user";
        }

        [TestMethod]
        public void SearchForIssuesTest()
        {
            this.tracker.RegisterUser("pesho", "123", "123");
            this.tracker.LoginUser("pesho", "123");

            string result = this.tracker.SearchForIssues(new string[] { "new" });
            string expectedResult = "No issues";
            Assert.AreEqual(result, expectedResult);

            this.tracker.CreateIssue(
                "Azis",
                "Azis e pederas",
                IssuePriorities.High,
                new string[] { "azis", "pederas" });
            this.tracker.LogoutUser();

            this.tracker.RegisterUser("gosho", "123", "123");
            this.tracker.LoginUser("gosho", "123");
            this.tracker.CreateIssue("Issue 1", "This is issue 1", IssuePriorities.High, new string[] { "new" });
            this.tracker.CreateIssue("Issue 2", "This is issue 2", IssuePriorities.High, new string[] { "new" });

            result = this.tracker.SearchForIssues(new string[] { "old" });
            expectedResult = "There are no issues matching the tags provided";
            Assert.AreEqual(result, expectedResult);

            result = this.tracker.SearchForIssues(new string[] { });
            expectedResult = "There are no tags provided";
            Assert.AreEqual(result, expectedResult);

            result = this.tracker.SearchForIssues(new string[] { "new" });
            expectedResult = "Issue 1\r\nPriority: ***\r\nThis is issue 1\r\nTags: new\r\n" +
                "Issue 2\r\nPriority: ***\r\nThis is issue 2\r\nTags: new";
            Assert.AreEqual(result, expectedResult);
        }
    }
}