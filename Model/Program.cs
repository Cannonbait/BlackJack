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
            Simulate(new MonteCarloBot());

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
            Console.WriteLine(string.Format("{0}%", (double)wins / totalPlayed * 100));
        }
    }
}
