using Xunit;
//Get score to returns a score object that returns string and weight of score. 

namespace PokerKata.UnitTests
{
    public class PokerGametests
    {
        [Theory]
        [InlineData("2H 3D 5S 9C KD", "2C 3H 4S 8C AH", "Player2 wins - high card: Ace")]
        [InlineData("2H 4S 4C 3D 4H", "2S 8S AS QS 3S", "Player2 wins - Flush: Spades , high card: Ace")]
        [InlineData("2S 8S AS QS 3S", "2H 4S 4C 3D 4H", "Player1 wins - Flush: Spades , high card: Ace")]
        [InlineData("2H 2D 5S 6C KD", "2C 3H 4S 8C AH", "Player1 wins - Pair: twos")]
        [InlineData("2H 2D 5S 6C KD", "2C 2S 4S 8C AH", "Player2 wins - Pair: twos")]
        [InlineData("2H 2D 5S 6C KD", "AH AC 4S 3C KD", "Player2 wins - Pair: Aces")]
        [InlineData("2H 2D 5S 5C KD", "AH AC 6D 6H KD", "Player2 wins - Two pair: Aces and sixs")]
        [InlineData("AH AC 6D 6H KD", "2H 2D 5S 5C KD", "Player1 wins - Two pair: Aces and sixs")]
        [InlineData("2S 2C 6D 6H KD", "2H 2D 6S 6C KC", "Draw")]
        [InlineData("2S 2C 2D 6H KD", "KH KD KS 6C QC", "Player2 wins - Three of a kind: Kings")]
        [InlineData("2S 3C 4D 5H 6D", "5H 6S 7C 8C 9D", "Player2 wins - Straight , high card: nine")]
        [InlineData("5H 6S 7C 8C 9D", "2S 3C 4D 5H 6D",  "Player1 wins - Straight , high card: nine")]
        [InlineData("5H 7H 9H QH KH", "2S 3C 4D 5H 6D",  "Player1 wins - Flush: Hearts , high card: King")]
        [InlineData("5H 7H 9H QH KH", "3S 5S 10S JS AS", "Player2 wins - Flush: Spades , high card: Ace")]
        [InlineData("10H 10D 10S 9C 9D", "3S 5S 10S JS AS", "Player1 wins - Full House: tens and nines")]
        [InlineData("10H 10D 10S 9C 9D", "3S 3D 3H 4S 4C", "Player1 wins - Full House: tens and nines")]
        [InlineData("10H 10D 10S 10C 9D", "3S 3D 3H 4S 4C", "Player1 wins - Four of a kind: tens")]
        [InlineData("10H 10D 10S 10C 9D", "AS AD AH AC 4C", "Player2 wins - Four of a kind: Aces")]
        [InlineData("6H 7H 8H 9H 10H", "AS AD AH AC 4C", "Player1 wins - Straight Flush , high card: ten")]
        [InlineData("2S 3S 4S 5S 6S", "6H 7H 8H 9H 10H", "Player2 wins - Straight Flush , high card: ten")]
        [InlineData("10S JS QS KS AS", "6H 7H 8H 9H 10H", "Player1 wins - Royal Flush")]
        [InlineData("10S JS QS KS AS", "10C JC QC KC AC", "Draw")]


        public void RunPokerGame(string player1Cards, string player2Cards, string expectedOutcome)
        {
            var pokerGame = new PokerGame();
            var result = pokerGame.CaluclateResult(player1Cards, player2Cards);
            Assert.Equal(expectedOutcome, result);
        }
    }

}



