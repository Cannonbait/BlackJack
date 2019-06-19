using System;
using Simulation.Core;
using Simulation.Bots;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;

namespace Simulation
{

    class Program
    {
        const int GAMESTOPLAY = 10000;

        static void Main(string[] args)
        {
            Random rnd = new Random();

            Stopwatch stopwatch = Stopwatch.StartNew();
            Simulate(new SimpleBot(14), 0, rnd.Next());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);


        }

        private static void Simulate(Bot bot, int initialMoney, int seed)
        {
            IBlackjack game = new Game(new Random(seed));
            for (int gamesPlayed = 0; gamesPlayed < GAMESTOPLAY; gamesPlayed++)
            {
                game.NewHand(bot.GetBet(game));
                while (!game.HandsOver)
                {
                    bot.Play(game);
                }
                game.FinishHand();
            }
            Console.WriteLine(string.Format("{0}\t Money: {1} \t Percent: {2}", bot.ToString(), game.Money, (game.Money + GAMESTOPLAY) / (GAMESTOPLAY * 2.0) * 100));
        }
    }
}
