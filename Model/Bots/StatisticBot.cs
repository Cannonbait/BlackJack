using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    class StatisticBot : Bot
    {
        public void Play(IBlackjack game)
        {
            Console.WriteLine(game.ActiveHand);
            Console.WriteLine(game.Dealer);
            Deck deck = game.Deck;
            //Dictionary<int, int> count = ProbabilitiesDraw(deck);
            //foreach (int val in count.Keys)
            //{
            //    Console.Write("(" + val + "," + count[val] + "), ");
            //}
            //Console.WriteLine();
            game.Hit();
        }


        //private List<(List<int>, int)> DrawAnother(Deck deck, List<(List<int>, int)> drawn)
        //{
        //    foreach ((List<int>, int) scenario in drawn)
        //    {

        //    }
        //    return null;

        //}

        //private Dictionary<int, int> ProbabilitiesDraw(Deck deck, List<int> drawn = null)
        //{
        //    Dictionary<int, int> cards = deck.Cards.GroupBy(x => x.Value).ToDictionary(x => (int)x.Key, x => x.Count());

        //    if (drawn != null)
        //    {
        //        foreach (int value in drawn)
        //        {
        //            cards[value] -= 1;
        //        }
        //    }
        //    return cards;
        //}




        public int GetBet(IBlackjack game)
        {
            return 1;
        }
    }
}
