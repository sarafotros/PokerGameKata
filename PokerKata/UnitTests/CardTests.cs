using Xunit;

namespace PokerKata.UnitTests
{
    public class CardTests
    {
        [Theory]
        [InlineData("2C", Rank.two, Suit.Club)]
        [InlineData("AH", Rank.Ace, Suit.Heart)]
        [InlineData("6S", Rank.six, Suit.Spade)]

        public void AcceptPlayersCardReturnsRankAndSuit(string playersCard, Rank expectedRank, Suit expectedSuit)
        {
            var card = new PlayerCard(playersCard);

            Assert.Equal(expectedRank, card.Rank);
            Assert.Equal(expectedSuit, card.Suit);
        }


    }

}



