using System;

internal static class Checkers
{
    internal static void CheckSide(double side)
    {
        if (side < 0)
        {
            throw new ArgumentOutOfRangeException("Lenght can't be a negative number");
        }
    }
}