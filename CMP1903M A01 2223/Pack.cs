using System;
using System.Collections.Generic;
using System.Linq;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        public List<Card> cards = new List<Card>(); //creates a list to add all the cards to
        int cardCount;
        public Pack() 
        {
            
            for (int Value = 1; Value <= 13; Value++) //loops through the amount of values in a deck of cards
            {
                for (int Suit = 1; Suit <= 4; Suit++) //loops through the amount of suits in a deck of cards
                {
                    Card card = new Card(); //creates a new card
                    card.Value = Value; //sets the value to the card
                    card.Suit = Suit; //sets the suit to the card
                    cards.Add(card); //adds the card to the deck
                }
            }
        }

        public static bool shuffleCardPack(int typeOfShuffle) //runs each shuffle depending on which the user has selected
        {
            if (typeOfShuffle == 1)
            { return Program.PACK.fisherShatesShuffle(); } //runs the Fisher-Yates shuffle
            else if (typeOfShuffle == 2)
            { return Program.PACK.riffleShuffle(); } //runs the Riffle shuffle
            else
            { return Program.PACK.noShuffle(); } //runs the no shuffle
        }

        public static Card deal() //deals a single card
        {
            var packSize = Program.PACK.cards.Count-1; //sets a pack size to reduce logic
            Card deal_card = Program.PACK.cards[packSize]; //copies(draws) a card from the deck
            Program.PACK.cards.RemoveAt(packSize); //removes the drawn card from the original deck
            return deal_card; //returns the card
        }

        public static List<Card> dealCard(int amount) //deals a set number of cards
        {
            List<Card> tempCards = new List<Card>(); //declares a list to add the drawn cards to
            var packSize = Program.PACK.cards.Count-1; //presets the pack size to reduce logic
            {
                for (int i = 0; i < amount; i++) //loops through the set amount of cards
                {
                    tempCards.Add(Program.PACK.cards[packSize - i]); //copies across the drawn card to the temporary list
                    Program.PACK.cards.RemoveAt(packSize - i); //removes the drawn card from the current deck
                }
                return tempCards; //returns the list of drawn cards
            }
        }

        public bool riffleShuffle() //riffle shuffle function for the deck
        {
            var packSize = cards.Count; //presets packsize to reduce logic
            if (packSize % 2 != 0 && packSize <= 2) //ensures that the cards can be riffle shuffled equally
            {
                return false; //returns false if the cards cannot be shuffled
            }
            var leftPack = cards.GetRange(0, (packSize / 2));
            var rightPack = cards.GetRange((packSize / 2), packSize / 2); //splits the cards into two seperate decks
            var newPack = new List<Card>();
            for (var i = 0; i < (packSize / 2); i++) //alternates through each deck adding one card from each to the new deck
            {
                newPack.Add(leftPack[i]);
                newPack.Add(rightPack[i]);
            }
            cards = newPack; //sets the main deck as the new shuffled deck
            return true; //confirms the successful shuffle
        }

        public bool noShuffle() //doesn't shuffle the cards
        {
            return false;
        }

        public bool fisherShatesShuffle() //shuffles the cards using the Fisher-Yates method
        {
            var packSize = cards.Count; //presets packsize to reduce logic
            foreach (Card card in cards.ToList()) //runs through each card in the deck
            {
                var index = cards.IndexOf(card); //grabs the index of the card
                var randIndex = Program.RANDOM.Next(0, (packSize)); //grabs a random position/number in the set range
                var tempVar = cards[randIndex]; //takes a random card from the random position our of the deck
                cards[randIndex] = cards[index]; //places the card somewhere else in the deck
                cards[index] = tempVar; //places the card somewehere else in the deck
            }
            return true; //confirms the shuffle has completed
        }

    }
}
