using System;
using Simulation.Core;
using Simulation.Bots;

namespace Simulation
{
    class Program
    {
        const int GAMESTOPLAY = 10000;
        static void Main(string[] args)
        {
            Simulate(new SimpleBot());
            //Simulate(new OneLevelMCBot());

        }

        private static void Simulate(Bot bot)
        {
            double winPercentage = bot.Play(new Game(), GAMESTOPLAY);
            Console.WriteLine(string.Format("{0}%", winPercentage));
        }
    }
}
