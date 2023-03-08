using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        List<Card> cards = new List<Card>();

        public Pack()
        {for (int Value = 1; Value <= 13; Value++)
            {for (int Suit = 1; Suit <= 4; Suit++)
                {
                    Card card = new Card();
                    card.card_val = Value;
                    card.card_suit = Suit;
                    cards.Add(card);
                }
            }
        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {if (typeOfShuffle == 1)
            {return Program.PACK.fisherShatesShuffle();} 
            else if (typeOfShuffle == 2)
            {return Program.PACK.riffleShuffle();} 
            else
            {return Program.PACK.noShuffle(); }
        }

        public static Card deal()
        {
            var packSize = cards.Count - 1;
            Console.WriteLine(cards[packSize]);
            Card deal_card = cards[packSize];
            cards.RemoveAt(packSize);
            return deal_card;
        }

        public static List<Card> dealCard(int amount)
        {
            List<Card> cards = new List<Card>();
            var packSize = cards.Count;
            {
                for (int i = 0; i < amount; i++)
                {
                    cards.Add(cards[packSize - i]);
                    cards.RemoveAt(packSize - i);
                }
                return cards;
            } 
        }

        public bool riffleShuffle()
        {
            var packSize = cards.Count - 1;
            if(packSize % 2 != 0 && packSize >= 2)
            {
                return false;
            }
            var leftPack = cards.GetRange(0, (packSize / 2));
            var rightPack = cards.GetRange((packSize/2), packSize);
            var newPack = new List<Card>();
            for(var i = 0; i < (packSize / 2); i++)
            {
                newPack.Add(leftPack[i]);
                newPack.Add(rightPack[i]);
            }
            cards = newPack;
            return true;             
        }

        public bool noShuffle()
        { 
            return false; 
        }

        public bool fisherShatesShuffle()
        {
            foreach (Card card in cards)
            {
                var index = cards.IndexOf(card);
                var randIndex = Program.RANDOM.Next(0, (cards.Count - 1));
                var tempVar = cards[randIndex];
                cards[randIndex] = cards[index];
                cards[index] = tempVar;
            }
            return true;
        }

    }
}
