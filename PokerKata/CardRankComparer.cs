using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PokerKata
{
    internal class CardRankComparer : IComparer<PlayerCard>
    {
        public int Compare([AllowNull] PlayerCard x, [AllowNull] PlayerCard y)
        {
            return (int)x.Rank - (int)y.Rank;
        }
    }

}



