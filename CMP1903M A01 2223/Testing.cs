using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    class Testing
    {
        public Testing()
        {
            int amount;

            var shuffle1 = Pack.shuffleCardPack(1);
            var shuffle2 = Pack.shuffleCardPack(2);
            var shuffle3 = Pack.shuffleCardPack(3);

            if (shuffle1)
            {
                Console.WriteLine("Fisher-Yates Shuffle Complete");
            }

            if (shuffle2)
            {
                Console.WriteLine("Riffle Shuffle Complete");
            }

            if (!shuffle3)
            {
                Console.WriteLine("No-Shuffle Shuffle Complete");
            }

            Console.WriteLine();
            Card card_dealt = Pack.deal();
            string strValue = card_dealt.Value.ToString();
            string strSuit = card_dealt.Suit.ToString();
            Console.WriteLine($"Value: {strValue}, Suit: {strSuit}");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("How Many Cards Would You Like To Deal ");
                    amount = int.Parse(Console.ReadLine());
                    if (amount > 0 && amount <= Program.PACK.cards.Count) { break; }
                    else { Console.WriteLine("Invalid Number"); }
                }
                catch { Console.WriteLine("Invalid Number"); }
            }
            List<Card> cards = Pack.dealCard(amount);
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine($"Value: {cards[i].Value}, Suit: {cards[i].Suit}");
            }
        }
    }
}
