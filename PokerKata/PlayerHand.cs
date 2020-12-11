using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PokerKata
{
    internal class PlayerHand
    {
        private List<PlayerCard> PlayingCards = new List<PlayerCard>();
        IOrderedEnumerable<IGrouping<Rank, PlayerCard>> groupedByRank;


        public PlayerHand(string playersHand)
        {
            var arrayOfCards = playersHand.Split(" ");
            foreach (var card in arrayOfCards)
            {
                PlayingCards.Add(new PlayerCard(card));

            }
            //GroupBy does not change underlying collection

            groupedByRank = PlayingCards.GroupBy(card => card.Rank)
                            .OrderByDescending(group => group.Count());

            var json = JsonConvert.SerializeObject(PlayingCards);
        }


        /*
         *
         *      PlayingCards = { card1, card2, card3, card4, card5,  } ;
         *
         *      GroupedBy = {   { card1, card2, }, {card4, card5}, { card3,}  }
         *
         */

        public string GetScore()
        {

            if (HaveWeGotOfAKind(4))
            {
                return $"Four of a kind: {GetBestRank()}s";
            };

            if (HasTwoPairs())
            {
                return $"Two pair: {GetTwoPair().Item1}s and {GetTwoPair().Item2}s";
            };


            if (HaveWeGotOfAKind(3))
            {
                return $"Three of a kind: {GetBestRank()}s";
            };

            if (HaveWeGotOfAKind(2))
            {
                return $"Pair: {GetBestRank()}s";
            };

            // Sort changes underlying collection
            PlayingCards.Sort(new CardRankComparer());

            return $"high card: {PlayingCards.Last().Rank}";
        }

        private bool HasTwoPairs()
        {
           return groupedByRank.Where(group => group.Count() == 2)
                .Count() == 2;
        }

        private (Rank Highest, Rank Lowest) GetTwoPair()
        {
            var pairs = groupedByRank.Where(group => group.Count() == 2);
            var firstRank = pairs.First().First().Rank;
            var secondRank = pairs.Last().First().Rank;

            if (firstRank > secondRank)
            {
                return (firstRank, secondRank);
            }

            return (secondRank, firstRank);
        }

        private bool HaveWeGotOfAKind(int number)
        {
            return groupedByRank.First().Count() == number;
        }

        private Rank GetBestRank()
        {
            return groupedByRank.First().First().Rank;
        }

    }

}



