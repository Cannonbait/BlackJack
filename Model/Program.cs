using System;
using Simulation.Core;
using Simulation.Bots;

namespace Simulation
{

    class Program
    {
        const int GAMESTOPLAY = 1000;
        static void Main(string[] args)
        {
            //Simulate(new SimpleBot(13));
            //Simulate(new SimpleBot(14));
            Simulate(new SimpleBot(15));
            //Simulate(new SimpleBot(16));
            //Simulate(new IntermediateBot());
            Simulate(new MonteCarloBot(200, 3));

        }

        private static void Simulate(Bot bot)
        {
            Game game = new Game();
            for (int gamesPlayed = 0; gamesPlayed < GAMESTOPLAY; gamesPlayed++)
            {
                game.NewHand();
                while (!game.HandOver)
                {
                    bot.Play(game);
                }
                game.FinishHand();
                game.SetBet(bot.SetBet(game));
            }
            Console.WriteLine(string.Format("{0}\t Money: {1}", bot.ToString(), game.Money));
        }
    }
}
