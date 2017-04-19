using System;
using System.Linq;
using System.Collections.Generic;

class CreatingDeckCollection
{
    class Card
    {
        public Card(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }

        public override string ToString()
        {
            return this.Value;
        }
    }

    class Deck
    {
        public Deck(params Card[] cards)
        {
            this.Cards = cards;
        }

        public ICollection<Card> Cards { get; private set; }

        public Card this[int index]
        {
            get
            {
                return Cards.ElementAt(index);
            }
        }
    }

    static void Main()
    {
        var deck = new Deck(new Card("Card1"), new Card("Card2"), new Card("Card3"), new Card("Card4"));
        Console.WriteLine(deck[2]);
    }
}