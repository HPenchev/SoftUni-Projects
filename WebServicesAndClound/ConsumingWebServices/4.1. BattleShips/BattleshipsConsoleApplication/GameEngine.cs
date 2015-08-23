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
                string output = CommandProcessor.ProcessCommand(input);
            }
        }
    }
}