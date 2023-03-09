using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    //class to run all of the testing of the 
    class Testing
    {
        public Testing()
        {
            int amount; //declares all the variables used in the testing
            string strValue;
            string strSuit;
            Card card_dealt;
            List<Card> cards;
            int i = 1;
            int runCount = 1;

            while (runCount < 4) //runs through each iteration of the shuffle method and deals cards each time from a freshly reset deck
            {
                Program.PACK.reset();
                Console.WriteLine();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();
                Pack.shuffleCardPack(runCount);
                runCount += 1;

                Console.WriteLine();
                card_dealt = Pack.deal(); //takes a dealt card
                strValue = card_dealt.Value.ToString();
                strSuit = card_dealt.Suit.ToString();
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
                    catch (Exception e) { Console.WriteLine(e.Message); }
                }

                cards = Pack.dealCard(amount);

                for (i = 0; i < amount; i++) //loops through the total amount of chosen cards
                {
                    strValue = cards[i].Value.ToString();
                    strSuit = cards[i].Suit.ToString(); //reduces logic by assigning the values and suits from the card class to variables
                    strValue = valueConverter("Value", strValue);
                    strSuit = valueConverter("Suit", strSuit);
                    Console.WriteLine($"{strValue} of {strSuit}"); //prints all of the cards in a better format
                }
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


