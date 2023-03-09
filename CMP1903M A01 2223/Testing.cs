using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    class Testing
    {
        public Testing()
        {
            int amount; //declares 

            var shuffle1 = Pack.shuffleCardPack(1);
            var shuffle2 = Pack.shuffleCardPack(2);
            var shuffle3 = Pack.shuffleCardPack(3); //assigns all the shuffle outputs to variables to reduce logic

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
            }// confirms if all the shuffles have successfully ran

            Console.WriteLine();
            Card card_dealt = Pack.deal(); //takes a dealt card
            string strValue = card_dealt.Value.ToString();
            string strSuit = card_dealt.Suit.ToString();
            strValue = valueConverter("Value", strValue);
            strSuit = valueConverter("Suit", strSuit);
            Console.WriteLine($"{strValue} of {strSuit}"); //outputs the cards in a good understandable format
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("How Many Cards Would You Like To Deal ");
                    amount = int.Parse(Console.ReadLine()); //ensures the value given is a number that can be taken
                    if (amount > 0 && amount <= Program.PACK.cards.Count) { break; } //checks the input is a valid number
                    else { Console.WriteLine("Invalid Number"); }
                }
                catch { Console.WriteLine("Invalid Number"); }
            }
            List<Card> cards = Pack.dealCard(amount);
            for (int i = 0; i < amount; i++) //loops through the total amount of chosen cards
            {
                strValue = cards[i].Value.ToString();
                strSuit = cards[i].Suit.ToString(); //reduces logic by assigning the values and suits from the card class to variables
                strValue = valueConverter("Value", strValue);
                strSuit = valueConverter("Suit", strSuit);
                Console.WriteLine($"{strValue} of {strSuit}"); //prints all of the cards in a better format
            }
        }

        public string valueConverter(string valueType, string value)
        {
            if (valueType == "Suit")
            {
                string strSuit = value;
                switch (strSuit) //reassigns the number values to their corresponding suits
                {
                    case "1":
                        strSuit = "Spades";
                        break;
                    case "2":
                        strSuit = "Clubs";
                        break;
                    case "3":
                        strSuit = "Diamonds";
                        break;
                    case "4":
                        strSuit = "Hearts";
                        break;
                    default:
                        strSuit = strSuit;
                        break;
                }
                return strSuit;
            }
            else
            {
                string strValue = value;
                switch (strValue) //reassigns the number values to their corresponding card types
                {
                    case "1":
                        strValue = "Ace";
                        break;
                    case "2":
                        strValue = "Two";
                        break;
                    case "3":
                        strValue = "Three";
                        break;
                    case "4":
                        strValue = "Four";
                        break;
                    case "5":
                        strValue = "Five";
                        break;
                    case "6":
                        strValue = "Six";
                        break;
                    case "7":
                        strValue = "Seven";
                        break;
                    case "8":
                        strValue = "Eight";
                        break;
                    case "9":
                        strValue = "Nine";
                        break;
                    case "10":
                        strValue = "Ten";
                        break;
                    case "11":
                        strValue = "Jack";
                        break;
                    case "12":
                        strValue = "Queen";
                        break;
                    case "13":
                        strValue = "King";
                        break;
                    default:
                        strValue = strValue;
                        break;
                }
                return strValue;
            }
        }
    }
}


