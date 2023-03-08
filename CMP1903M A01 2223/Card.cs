using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        private int Value;
        public int card_val{
            get { return Value; }
            set { if (card_val > 0 && card_val < 13) { Value = card_val; }
                  else { Console.WriteLine("Invalid Value - Must be in the range 1 - 13"); }}
        }
        private int Suit;
        public int card_suit{
            get { return Suit; }
            set {if (card_suit > 0 && card_suit <= 4) { Suit = card_suit; }
                else { Console.WriteLine("Invalid Value - Must be in the range 1 - 4"); }}
        }
    }
}
