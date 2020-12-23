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

        public string GetScore()
        {
            if (RoyalFlush())
            {
                return "Royal Flush";
            }

            if (StraightFlush())
            {
                return $"Straight Flush , high card: {HighCard().Rank}";
            }

            if (HaveWeGotOfAKind(4))
            {
                return $"Four of a kind: {GetBestRank()}s";
            };
            

            if(HaveWeGotOfAKind(3) && HaveWeGotOfAKind(2))
            {
                return $"Full House: {GetRankAtIndex(0)}s and {GetRankAtIndex(1)}s";
            }

            if (IsFlush())
            {
                return $"Flush: {groupedBySuit.First().First().Suit}s , high card: {HighCard().Rank}";
            }

            if (Straight())
            {
                return $"Straight , high card: {HighCard().Rank}";
            }

            if (HaveWeGotOfAKind(3))
            {
                return $"Three of a kind: {GetBestRank()}s";
            };

            if (HasTwoPairs())
            {
                return $"Two pair: {GetTwoPair().Highest}s and {GetTwoPair().Lowest}s";
            };
            
            if (HaveWeGotOfAKind(2))
            {
                return $"Pair: {GetBestRank()}s";
            };
            
            return $"high card: {HighCard().Rank}";
        }

        private PlayerCard HighCard()
        {
            return PlayingCards.Last();

        }

        private bool RoyalFlush()
        {
            return StraightFlush() && HighCard().Rank == Rank.Ace;
        }

        private bool StraightFlush()
        {
            return Straight() && IsFlush();
        }

        private bool IsFlush()
        {
            return groupedBySuit.Count() == 1;
        }

        private bool HasTwoPairs()
        {
           return groupedByRank.Where(group => group.Count() == 2)
                .Count() == 2;
        }

        private (Rank Highest, Rank Lowest) GetTwoPair()
        {
            var pairs = groupedByRank.Where(group => group.Count() == 2);
           
            var ranks = pairs.Select(group => group.First().Rank).ToList();

            ranks.Sort();

            return (ranks.Last(), ranks.First());
        }

        private bool HaveWeGotOfAKind(int number)
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

        private bool Straight()
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

           // var cardGroup = groupedByRank.ToList().First();


            //foreach (var card in cardGroup)
            //{

            //}

            //var rankAtIndexOne = GetRankAtIndex(1);
            //var rankAtIndexTwo = GetRankAtIndex(2);
            //var rankAtIndexThree = GetRankAtIndex(3);
            //var rankAtIndexFour = GetRankAtIndex(4);


            //if (rankAtIndexOne == rankAtIndexZero + 1 && rankAtIndexTwo == rankAtIndexOne + 1 && rankAtIndexThree == rankAtIndexTwo + 1 && rankAtIndexFour == rankAtIndexThree + 1)
            //{
            //    return true;
            //}

            //return false;

            
        }

    }

}



