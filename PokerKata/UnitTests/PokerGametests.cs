using Xunit;
//Get score to returns a score object that returns string and weight of score. 

namespace PokerKata.UnitTests
{
    public class PokerGametests
    {
        [Theory]
        [InlineData("2H 3D 5S 9C KD", "2C 3H 4S 8C AH", "Player2 wins - high card: Ace")]
        [InlineData("2H 4S 4C 3D 4H", "2S 8S AS QS 3S", "Player2 wins - Flush: Spades , high card: Ace")]
        //[InlineData("2S 8S AS QS 3S", "2H 4S 4C 3D 4H", "Player1 wins - Flush: Spades , high card: Ace")]
        //[InlineData("2H 2D 5S 6C KD", "2C 3H 4S 8C AH", "Player1 wins - Pair: Twos")]
        //[InlineData("2H 2D 5S 6C KD", "2C 2S 4S 8C AH", "Player1 wins - Pair: Twos")]
        //[InlineData("2H 2D 5S 6C KD", "AH AC 4S 3C KD", "Player2 wins - Pair: Aces")]


        public void RunPokerGame(string player1Cards, string player2Cards, string expectedOutcome)
        {
            var pokerGame = new PokerGame();
            var result = pokerGame.CaluclateResult(player1Cards, player2Cards);
            Assert.Equal(expectedOutcome, result);
        }
    }

}



