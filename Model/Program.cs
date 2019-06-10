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
            Simulate(new SimpleBot(15));
            //Simulate(new SimpleBot(16));
            //Simulate(new IntermediateBot());
            Simulate(new MonteCarloBot(200, 3, 0.5));
            Simulate(new MonteCarloBot(200, 3, 0.55));
            Simulate(new MonteCarloBot(200, 3, 0.6));

        }

        private static void Simulate(Bot bot)
        {
            Game game = new Game();
            for (int gamesPlayed = 0; gamesPlayed < GAMESTOPLAY; gamesPlayed++)
            {
                game.SetBet(bot.SetBet(game));
                game.NewHand();
                while (!game.HandOver)
                {
                    bot.Play(game);
                }
                game.FinishHand();
            }
            Console.WriteLine(string.Format("{0}\t Money: {1}", bot.ToString(), game.Money));
        }
    }
}
