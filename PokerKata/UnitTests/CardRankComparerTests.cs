using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PokerKata.UnitTests
{
    public class CardRankComparerTests
    {
        [Fact]
        public void Sorting_cards_using_card_rank_comparer_correctly_orders_list()
        {
            var cardslist = new List<PlayerCard>()
            {
                new PlayerCard("2C"),
                new PlayerCard("AH"),
                new PlayerCard("5C"),
            };

            cardslist.Sort(new CardRankComparer());

            Assert.Equal(Rank.Ace, cardslist.Last().Rank);
        }
    }

}



