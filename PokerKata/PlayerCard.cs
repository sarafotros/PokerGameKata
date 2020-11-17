using System.Collections.Generic;
using System.Linq;

namespace PokerKata
{
    internal class PlayerCard
    {
        private Dictionary<string, Suit> SuitDictionary = new Dictionary<string, Suit>() {
            {"C", Suit.Club},
            {"D", Suit.Diamond},
            {"H", Suit.Heart},
            {"S", Suit.Spade}
        };

        private Dictionary<string, Rank> RankDictionary = new Dictionary<string, Rank>() {
            {"2", Rank.two},
            {"3", Rank.three},
            {"4",Rank.four },
            {"5",Rank.five },
            {"6",Rank.six },
            {"7",Rank.seven },
            {"8",Rank.eight },
            {"9",Rank.nine },
            {"10",Rank.ten },
            {"J",Rank.Jack },
            {"Q",Rank.Queen },
            {"K",Rank.King },
            {"A",Rank.Ace },
        };

        public PlayerCard(string card)
        {
            var suitChar = card.Last();
            Suit = SuitDictionary[suitChar.ToString()];
            var rankString = card.Replace(suitChar.ToString(), "");
            Rank = RankDictionary[rankString];
        }
        public Rank Rank { get; }
        public Suit Suit { get; }

    }

}



