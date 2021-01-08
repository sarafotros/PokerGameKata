namespace PokerKata
{
    public class Score
    {
        public Score(string description, int value)
        {
            Description = description;
            Value = value;
        }
        public string Description { get; }
        public int Value { get;  }
        
    }
}