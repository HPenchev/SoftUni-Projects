using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException();
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    { 
        get
        {
            return this.grade;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Value can't be a negative number");
            }

            this.grade = value;
        }
    }

    public int MinGrade 
    { 
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Min grade can't be negative");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value <= this.MinGrade)
            {
                throw new ArgumentOutOfRangeException("Max grade has to be more than min grade");
            }

            this.minGrade = value;
        }
    }

    public string Comments 
    { 
        get
        {
            return this.comments;
        }

        private set
        {
            if (string.IsNullOrEmpty(comments))
            {
                throw new ArgumentNullException("Comments are mandatory");
            }

            this.comments = value;
        }
    }
}