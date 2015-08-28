using System;

namespace BattleshipsConsoleApplication
{
    public class GameEngine
    {
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                CommandProcessor.ProcessCommand(input);
                //Console.WriteLine(output);
            }
        }
    }
}