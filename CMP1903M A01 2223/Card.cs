namespace CMP1903M_A01_2223
{
    class Card
    {
        public int Suit { get; set; } //Card pnly has 2 variables, Value and Suit
        public int Value { get; set; }
        public Card(int Suit, int Value) //constructor to set Suit and Value
        {
            this.Suit = Suit;
            this.Value = Value;
        }
        
    }
}