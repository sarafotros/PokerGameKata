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
        [InlineData("3C 3D 3S 7H 7C", "Full House: threes and sevens")]
        [InlineData("QC QD QS 4H 4C", "Full House: Queens and fours")]
        [InlineData("3C 4C QC 8C 2C", "Flush: Clubs , high card: Queen")]
        [InlineData("8C 9D 10S JH QC", "Straight , high card: Queen")]
        [InlineData("8C 9C 10C JC QC", "Straight Flush , high card: Queen")]
        [InlineData("10C JC QC KC AC", "Royal Flush")]

        public void AcceptPlayersHand_ReturnsHighestScore(string playersHand, string expectedScore)
        {
            var hand = new PlayerHand(playersHand);
            var result = hand.GetScore();
            Assert.Equal(expectedScore, result.Description);
        }

    }
}



