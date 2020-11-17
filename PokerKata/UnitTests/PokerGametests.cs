using Xunit;

namespace PokerKata.UnitTests
{
    public class PokerGametests
    {
        [Theory]
        [InlineData("2H 3D 5S 9C KD", "2C 3H 4S 8C AH", "Player2 wins - high card: Ace")]
        // [InlineData("2H 4S 4C 3D 4H", "2S 8S AS QS 3S", "Player2 wins - flush")]
        public void RunPokerGame(string player1Cards, string player2Cards, string expectedOutcome)
        {
            var pokerGame = new PokerGame();
            var result = pokerGame.CaluclateResult(player1Cards, player2Cards);
            Assert.Equal(expectedOutcome, result);
        }
    }

}



