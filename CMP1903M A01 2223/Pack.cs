using System.Collections.Generic;
using System.Linq;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        public List<Card> cards = new List<Card>();

        public Pack()
        {
            for (int Value = 1; Value <= 13; Value++)
            {
                for (int Suit = 1; Suit <= 4; Suit++)
                {
                    Card card = new Card();
                    card.Value = Value;
                    card.Suit = Suit;
                    cards.Add(card);
                }
            }
        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            if (typeOfShuffle == 1)
            { return Program.PACK.fisherShatesShuffle(); }
            else if (typeOfShuffle == 2)
            { return Program.PACK.riffleShuffle(); }
            else
            { return Program.PACK.noShuffle(); }
        }

        public static Card deal()
        {
            var packSize = Program.PACK.cards.Count - 1;
            Card deal_card = Program.PACK.cards[packSize];
            Program.PACK.cards.RemoveAt(packSize);
            return deal_card;
        }

        public static List<Card> dealCard(int amount)
        {
            List<Card> tempCards = new List<Card>();
            var packSize = Program.PACK.cards.Count - 1;
            {
                for (int i = 0; i < amount; i++)
                {
                    tempCards.Add(Program.PACK.cards[packSize - i]);
                    Program.PACK.cards.RemoveAt(packSize - i);
                }
                return tempCards;
            }
        }

        public bool riffleShuffle()
        {
            var packSize = cards.Count - 1;
            if (packSize % 2 != 0 && packSize <= 2)
            {
                return false;
            }
            var leftPack = cards.GetRange(0, (packSize / 2));
            var rightPack = cards.GetRange((packSize / 2), packSize / 2);
            var newPack = new List<Card>();
            for (var i = 0; i < (packSize / 2); i++)
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
            var packSize = cards.Count - 1;
            foreach (Card card in cards.ToList())
            {
                var index = cards.IndexOf(card);
                var randIndex = Program.RANDOM.Next(0, (packSize));
                var tempVar = cards[randIndex];
                cards[randIndex] = cards[index];
                cards[index] = tempVar;
            }
            return true;
        }

    }
}
