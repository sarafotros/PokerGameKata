using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PokerKata
{
    internal class PlayerHand
    {
        private List<PlayerCard> PlayingCards = new List<PlayerCard>();
        IOrderedEnumerable<IGrouping<Rank, PlayerCard>> groupedByRank;
        IOrderedEnumerable<IGrouping<Suit, PlayerCard>> groupedBySuit;
        

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
            
            groupedBySuit = PlayingCards.GroupBy(card => card.Suit)
                .OrderByDescending(group => group.Count());
            
            var json = JsonConvert.SerializeObject(PlayingCards);
            
            // Sort changes underlying collection
            PlayingCards.Sort(new CardRankComparer());
        }


        /*
         *
         *      PlayingCards = { card1, card2, card3, card4, card5,  } ;
         *
         *      GroupedBy = {   { card1, card2, }, {card4, card5}, { card3,}  }
         * 
         **      GroupedBy = {   { 3Clubs, 3Hearts, 3 Diamonds }, {2Diamonds, 2Clubs} }
         */

        public Score GetScore()
        {
            if (IsRoyalFlush())
                return new Score("Royal Flush", 900 ); 
            
            if (IsStraightFlush())
                 return new Score($"Straight Flush , high card: {HighCard().Rank}", 800 );

            if (IsOfKind(4))
                return  new Score($"Four of a kind: {GetBestRank()}s", 700);
            
            if(IsFullHouse())
                return new Score($"Full House: {GetRankAtIndex(0)}s and {GetRankAtIndex(1)}s",600);
            

            if (IsFlush())
                return new Score( $"Flush: {groupedBySuit.First().First().Suit}s , high card: {HighCard().Rank}",500);
            
            if (IsStraight())
                return new Score( $"Straight , high card: {HighCard().Rank}",400);
            

            if (IsOfKind(3))
                return new Score( $"Three of a kind: {GetBestRank()}s",300 + (int)GetBestRank() );

            if (IsTwoPairs())
                return new Score($"Two pair: {GetTwoPair().Highest}s and {GetTwoPair().Lowest}s",200 + (int) GetTwoPair().Highest+(int)GetTwoPair().Lowest );
            
            if (IsOfKind(2))
                return new Score($"Pair: {GetBestRank()}s",100 + (int)GetBestRank());
            
            return  new Score($"high card: {HighCard().Rank}", (int) HighCard().Rank );
        }

        public PlayerCard HighCard()
        {
            return PlayingCards.Last();
        }

        private bool IsFullHouse()
        {
          return IsOfKind(3) && IsOfKind(2);
        }

        private bool IsRoyalFlush()
        {
            return IsStraightFlush() && HighCard().Rank == Rank.Ace;
        }

        private bool IsStraightFlush()
        {
            return IsStraight() && IsFlush();
        }

        private bool IsFlush()
        {
            return groupedBySuit.Count() == 1;
        }

        private bool IsTwoPairs()
        {
           return groupedByRank
               .Count(group => Enumerable.Count<PlayerCard>(@group) == 2) == 2;
        }

        private (Rank Highest, Rank Lowest) GetTwoPair()
        {
            var pairs = groupedByRank.Where(group => group.Count() == 2);
           
            var ranks = pairs.Select(group => group.First().Rank).ToList();

            ranks.Sort();

            return (ranks.Last(), ranks.First());
        }

        private bool IsOfKind(int number)
        {
            return groupedByRank.Any(group => group.Count() == number);
        }

        private Rank GetBestRank()
        {
            // return groupedByRank.First().First().Rank;
            return GetRankAtIndex(0);
        }

        private Rank GetRankAtIndex(int index)
        {
           var groupList = groupedByRank.ToList();
           return groupList[index].First().Rank;
        }

        private bool IsStraight()
        {
            var index = 0;

            while (index < PlayingCards.Count() - 1)
            {
                var rankAtCurrentIndex = PlayingCards[index].Rank;
                var rankAtNextIndex = PlayingCards[index + 1].Rank;

                if (rankAtNextIndex != rankAtCurrentIndex + 1)
                {
                    return false;
                }
                index++;
            }


            return true;

        }

    }

}



