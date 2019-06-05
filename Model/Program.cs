using System;
using Simulation.Core;
using Simulation.Bots;

namespace Simulation
{
    class Program
    {
        const int GAMESTOPLAY = 100000;
        static void Main(string[] args)
        {
            Simulate(new SimpleBot(14));
            Simulate(new SimpleBot(15));
            Simulate(new SimpleBot(16));
            Simulate(new SimpleBot(17));
            //Simulate(new MonteCarloBot());

        }

        private static void Simulate(Bot bot)
        {
            int totalPlayed = 0;
            int wins = 0;
            Game game = new Game();
            while (totalPlayed < GAMESTOPLAY)
            {
                Result res = bot.Play(game);
                if (res != Result.None)
                {
                    totalPlayed++;
                    if (res == Result.Player)
                    {
                        wins++;
                    }
                }
            }
            Console.WriteLine(string.Format("{0}: {1}%", bot.ToString(), (double)wins / totalPlayed * 100));
        }
    }
}
