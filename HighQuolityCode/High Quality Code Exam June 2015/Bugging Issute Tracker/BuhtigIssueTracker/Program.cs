namespace BuhtigIssueTracker
{
    using System.Globalization;
    using System.Threading;
    using BuhtigIssueTracker.Contracts;
    using BuhtigIssueTracker.Engine;

    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // DI: <Dependence on interface so that another kind of engine can be used>
            IEngine engine = new Engine.Engine();
            engine.Run();
        }
    }
}