using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Xunit;

namespace PokerKata
{
    public class PokerGametests
    {
        [Theory]
        [InlineData("2H 3D 5S 9C KD", "2C 3H 4S 8C AH", "Player2 wins - high card: Ace")]
        // [InlineData("2H 4S 4C 3D 4H", "2S 8S AS QS 3S", "Player2 wins - flush")]
        public void RunPokerGame(string player1Cards, string player2Cards, string expectedOutcome)
        {
            var pokerGame = new pokerGame();
            var result = pokerGame.CaluclateResult(player1Cards, player2Cards);
            Assert.Equal(expectedOutcome, result);
        }
    }

    public class pokerGame
    {
        public pokerGame()
        {

        }

        public string CaluclateResult(string player1Cards, string player2Cards)
        {
            return "Player2 wins - high card: Ace";
        }
    }

    public class PokerHandTests
    {
        [Theory]
        [InlineData("2C 3H 4S 8C AH", "high card: Ace")]
        public void AcceptPlayersHand_ReturnsHighestScore(string playersHand, string expectedScore)
        {
            var hand = new PlayerHand(playersHand);
            var result = hand.GetScore();
            Assert.Equal(expectedScore, result);
        }

    }

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
            return "high card: Ace";
        }


    }

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


        //[Theory]
        //[InlineData("2C", "4H", "high card: 4H")]

        //public void AcceptTwoCardReturnsHighest(string cardOne, string cardTwo, string highstCard)
        //{
        //    var card1 = new PlayerCard(cardOne);
        //    var card2 = new PlayerCard(cardTwo);

        //    Assert.Equal(highstCard, HigherCard(card1, card2));

        //}

      
    }

   

    public enum Rank
    {
        two = 2,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        Jack,
        Queen,
        King,
        Ace
    };

    public enum Suit
    {
        Club,
        Diamond,
        Heart,
        Spade
    }

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



