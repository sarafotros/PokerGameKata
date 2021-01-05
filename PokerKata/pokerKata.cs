using System;

// Two Poker hand objects, player1hand player2hand
// Create container for different hands so the hands can be compared. 

namespace PokerKata
{

    public class PokerGame
    {

        public PokerGame()
        {

        }

        public string CaluclateResult(string player1Cards, string player2Cards)
        {
            var playerOneHand = new PlayerHand(player1Cards);
            var playerTwoHand = new PlayerHand(player2Cards);

           
            return $"Player2 wins - {playerTwoHand.GetScore()}";
        }
    }

}



