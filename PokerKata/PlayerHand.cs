using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PokerKata
{
    internal class PlayerHand
    {
        private List<PlayerCard> PlayingCards = new List<PlayerCard>();
        
        public PlayerHand(string playersHand)
        {
            var arrayOfCards = playersHand.Split(" ");
            foreach (var card in arrayOfCards)
            {
                PlayingCards.Add(new PlayerCard(card));
      
            }
            var json = JsonConvert.SerializeObject(PlayingCards);
        }

        public string GetScore()
        {
            //GroupedBy does not change underlying collection 
            var groupedByRank = PlayingCards.GroupBy(x => x.Rank);

            if (groupedByRank.Last().Count() == 2)
             {
                return $"Pair: {groupedByRank.Last().Last().Rank}s";
             };

            
            // Sort changes underlying collection
            PlayingCards.Sort(new CardRankComparer());
            
            return $"high card: {PlayingCards.Last().Rank}";
        }

    }

}



