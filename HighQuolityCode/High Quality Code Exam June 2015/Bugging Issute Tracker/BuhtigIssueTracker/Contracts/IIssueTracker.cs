namespace BuhtigIssueTracker.Contracts
{
    using BuhtigIssueTracker.Enumerations;

    /// <summary>
    /// This interface defines the main actions that an issue tracker must handle managing the issue data
    /// </summary>
    /// 
    public interface IIssueTracker
    {
        /// <summary>
        /// This method registers a new user into the issue tracker
        /// </summary>
        /// <param name="username">User's username into the system</param>
        /// <param name="password">User's password into the system</param>
        /// <param name="confirmPassword">Confirmation of user's password into the system.
        /// It has to match password field</param>
        /// <returns>A successful register message in case of a successfull registration
        /// or an error message in case of an error</returns>         
        string RegisterUser(string username, string password, string confirmPassword);

        /// <summary>
        /// This method logins an existing user into the issue tracker
        /// </summary>
        /// <param name="username">User's username into the system</param>
        /// <param name="password">User's password into the system</param>        
        /// <returns>A successful login message in case of a successfull login
        /// or an error message in case of an error</returns>        
        string LoginUser(string username, string password);

        /// <summary>
        /// This method logs out the currently logged user
        /// </summary>       
        /// <returns>A successful logout message in case of a successfull logout
        /// or an error message in case of an error</returns>        
        string LogoutUser();

        /// <summary>
        /// This method creates a new issue and adds it into the tracker data
        /// </summary>
        /// <param name="title">Title of the issue</param>
        /// <param name="description">Description of the issue</param> 
        /// <param name="priority">Priority of the issue</param>  
        /// <param name="tags">Description tags about the issue</param>  
        /// <returns>A successful issue creation message in case of a successfull creation
        /// or an error message in case of an error</returns>  
        string CreateIssue(string title, string description, IssuePriorities priority, string[] tags);

        /// <summary>
        /// Removes an issue from tracker data
        /// </summary>
        /// <param name="issueId">Id number of issue to be removed</param>      
        /// <returns>A successful issue removal message in case of a successfull removal
        /// or an error message in case of an error</returns>  
        string RemoveIssue(int issueId);

        /// <summary>
        /// Adds a comment to a certain issue
        /// </summary>
        /// <param name="issueId">Id of the issue the user wants to comment</param>   
        /// /// <param name="itext">Content text of user's comment</param> 
        /// <returns>A successful commend add message in case of a successfull add
        /// or an error message in case of an error</returns>  
        string AddComment(int issueId, string text);

        /// <summary>
        /// Searches for all issues of the user currently logged in.
        /// </summary>       
        /// <returns>A List of currently logged user issues in case of success
        /// or an error message in case of an error</returns>
        string GetMyIssues();

        /// <summary>
        /// Searches for all comments of the user currently logged in.
        /// </summary>       
        /// <returns>A List of currently logged user comments in case of success
        /// or an error message in case of an error</returns>
        string GetMyComments();

        /// <summary>
        /// Searches for all issues holding certain tags
        /// </summary>     
        /// <param name="tags">Tags by which we are looking for issues</param> 
        /// <returns>A List of issues linked to a certain tag in case of success
        /// or an error message in case of an error</returns>
        string SearchForIssues(string[] tags);
    }
}