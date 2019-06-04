using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    class MonteCarloBot : Bot
    {
        const int SIMULATIONS = 500;
        public void Play(Blackjack game, int gamesPlayed)
        {
            while (game.GamesPlayed < gamesPlayed)
            {
                MakePlay(game);
            }
        }

        private void MakePlay(Blackjack game)
        {
            int losses = 0;
            Hand hand = game.PlayerHand;


            for (int i = 0; i < SIMULATIONS; i++)
            {
                Card c = game.Deck.SimulatedDraw();

                if (hand.AddCardBust(c))
                {
                    losses++;
                }

            }
            if (losses > SIMULATIONS / 2)
            {
                game.Stand();
            }
            else
            {
                game.Hit();
            }
        }
    }
}
