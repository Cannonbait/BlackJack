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
            //Simulate(new SimpleBot(13));
            //Simulate(new SimpleBot(14));
            //Simulate(new SimpleBot(15));
            //Simulate(new SimpleBot(16));
            //Simulate(new IntermediateBot());
            Simulate(new MonteCarloBot(200, 3));

        }

        private static void Simulate(Bot bot)
        {
            int wins = 0;
            Game game = new Game();
            game.NewHand();
            for (int gamesPlayed = 0; gamesPlayed < GAMESTOPLAY; gamesPlayed++)
            {
                while (!game.HandOver)
                {
                    bot.Play(game);
                }
                if (game.Winner() == Result.Player)
                {
                    wins++;
                }
                game.NewHand();
            }
            Console.WriteLine(string.Format("{0}\t Winrate: {1}%", bot.ToString(), (double)wins / GAMESTOPLAY * 100));
        }
    }
}
