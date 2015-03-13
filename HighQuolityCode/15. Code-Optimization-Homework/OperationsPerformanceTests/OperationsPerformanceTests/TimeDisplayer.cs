using System;
using System.Diagnostics;

public static class TimeDisplayer
{
    public static void DisplayExecutionTime(Action action)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
    }
}