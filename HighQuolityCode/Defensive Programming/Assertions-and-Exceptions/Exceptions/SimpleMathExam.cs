using System;

public class SimpleMathExam : Exam
{
    private int problemSolved;
    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved 
    { 
        get
        {
            return this.problemSolved;
        }

        private set
        {
            if (value < 0)
            {
                value = 0;
            }

            if (value > 10)
            {
                value = 10;
            }

            problemSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved > 2)
        {
            return new ExamResult(6, 2, 6, "Whoever created this homework is retard!.");
        }

        return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
    }
}
