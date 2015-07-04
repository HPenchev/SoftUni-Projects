namespace BuhtigIssueTracker.Engine
{
    using BuhtigIssueTracker.Contracts;
    using C = System.Console;

    public class Engine : IEngine
    {
        private Dispatcher dispatcher;

        public Engine(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public Engine()
            : this(new Dispatcher())
        {
        }

        public void Run()
        {
            while (true)
            {
                string url = C.ReadLine();

                if (url == null)
                {
                    break;
                }

                url = url.Trim();

                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {                        
                        IEndpoint endpoint = new Endpoint(url);
                        string viewResult = this.dispatcher.DispatchAction(endpoint); 
                        System.Console.WriteLine(viewResult);
                    }
                    catch (System.Exception ex)
                    {
                        C.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}