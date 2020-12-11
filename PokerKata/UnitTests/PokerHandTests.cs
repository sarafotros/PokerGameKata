using Xunit;

namespace PokerKata.UnitTests
{
    public class PokerHandTests
    {
        [Theory]
        [InlineData("2C 3H 4S 8C AH", "high card: Ace")]
        [InlineData("2C 3H 4S 8C QH", "high card: Queen")]
        [InlineData("2C 3H 4S 8C 8H", "Pair: eights")]
        [InlineData("2C 3H 3S 4C 8H", "Pair: threes")]
        [InlineData("2C 3H 7S QH QC", "Pair: Queens")]
        [InlineData("2C 3H QS QH QC", "Three of a kind: Queens")]
        [InlineData("2C 7H 7S QH QC", "Two pair: Queens and sevens")]
        [InlineData("2C QD QS QH QC", "Four of a kind: Queens")]


        public void AcceptPlayersHand_ReturnsHighestScore(string playersHand, string expectedScore)
        {
            var hand = new PlayerHand(playersHand);
            var result = hand.GetScore();
            Assert.Equal(expectedScore, result);
        }

    }
}



