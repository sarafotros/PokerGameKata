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

            if (playerTwoHand.GetScore().Value == playerOneHand.GetScore().Value)
            {
                if ( playerTwoHand.HighCard().Rank > playerOneHand.HighCard().Rank )
                {
                    return $"Player2 wins - {playerTwoHand.GetScore().Description}";
                }

                if (playerOneHand.HighCard().Rank > playerTwoHand.HighCard().Rank)
                {
                    return $"Player1 wins - {playerOneHand.GetScore().Description}"; 
                }
                return "Draw";
            }
            if (playerTwoHand.GetScore().Value > playerOneHand.GetScore().Value)
            {
                return $"Player2 wins - {playerTwoHand.GetScore().Description}"; 
            }
            return $"Player1 wins - {playerOneHand.GetScore().Description}"; 

        }
    }

}



