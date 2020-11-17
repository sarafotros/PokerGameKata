using Xunit;

namespace PokerKata.UnitTests
{
    public class PokerHandTests
    {
        [Theory]
        [InlineData("2C 3H 4S 8C AH", "high card: Ace")]
        [InlineData("2C 3H 4S 8C QH", "high card: Queen")]
        [InlineData("2C 3H 4S 8C 8H", "Pair: eights")]

        public void AcceptPlayersHand_ReturnsHighestScore(string playersHand, string expectedScore)
        {
            var hand = new PlayerHand(playersHand);
            var result = hand.GetScore();
            Assert.Equal(expectedScore, result);
        }

    }

}



