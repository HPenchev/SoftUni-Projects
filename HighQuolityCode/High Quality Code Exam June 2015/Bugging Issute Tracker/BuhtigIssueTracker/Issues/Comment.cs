namespace BuhtigIssueTracker.Issues
{
    using System;
    using BuhtigIssueTracker.Users;    
    using S = System.Text.StringBuilder;

    public class Comment
    {
        private string content;

        public Comment(User author, string content)
        {
            this.Author = author;
            this.Content = content;
        }

        public User Author { get; set; }

        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentException("The text must be at least 2 symbols long");
                }

                this.content = value;
            }
        }

        public override string ToString()
        {
            return new S()
                .AppendLine(this.Content)
                .AppendFormat("-- {0}", this.Author.Username)
                .AppendLine()
                .ToString()
                .Trim();
        }
    }
}
