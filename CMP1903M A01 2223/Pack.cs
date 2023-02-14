using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        
        List<Card> cards;

        public Pack()
        {
            //Initialise the card pack here
        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            //Fisher-Yates Shuffle
            //Riffle Shuffle
            //No Shuffle
            //Shuffles the pack based on the type of shuffle
            if (typeOfShuffle == 1)
            {
                return Program.PACK.fisherShatesShuffle();
               
            } else if (typeOfShuffle == 2)
            {
                return Program.PACK.riffleShuffle();
            } else
            {
                return Program.PACK.noShuffle(); 
            }
        }
        public static Card deal()
        {
            //Deals one card

        }
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
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
