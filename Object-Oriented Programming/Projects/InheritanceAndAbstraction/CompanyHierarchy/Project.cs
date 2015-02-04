using System;

public class Project : IProject
{
    private string projectName;
    private string details;
    private string state;

    public Project(string projectName, DateTime projectStartDate, string details, string state)
    {
        this.ProjectName = projectName;
        this.ProjectStartDate = projectStartDate;
        this.Details = details;
        this.State = state;
    }

    public string ProjectName
    {
        get
        {
            return this.projectName;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Project name is mandatory");
            this.projectName = value;
        }
    }
    public DateTime ProjectStartDate { get; set; }
    public string Details
    {
        get
        {
            return this.details;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Project details are mandatory");
            this.details = value;
        }
    }
    public string State
    {
        get
        {
            return this.state;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("State is mandatory");
            if (!CheckStateValidity(value)) throw new ArgumentException("Project state can me open or close only");
            this.state = value;
        }
    }
    private bool CheckStateValidity(string state)
    {
        if(state == "open"|| state == "closed")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void CloseProject()
    {
        this.State = "closed";
    }
    public override string ToString()
    {
        string result = "Project name: " + this.ProjectName + "\nProject start date: " + this.ProjectStartDate +
            "\nProject details: " + this.Details + "\nState: " + this.State;
        return result;
    }
}

