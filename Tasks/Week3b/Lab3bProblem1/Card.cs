// Card.cs
// Card class represents a playing card.

namespace Lab3bProblem1
{
    public class Card
    {
        public static readonly string[] FACES = { "Ace", "Deuce", "Three", "Four", "Five", "Six",
         "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        public static readonly string[] SUITS = { "Hearts", "Diamonds", "Clubs", "Spades" };

        //private readonly int face; 
        //private readonly int suit;

        public int Face { get; init; } // face of card ("Ace", "Deuce", ...)
        public int Suit { get; init; }  // suit of card ("Hearts", "Diamonds", ...)
        // two-parameter constructor initializes card's face and suit
        public Card(int cardFace, int cardSuit)
        {
            Face = cardFace >=0 && cardFace < FACES.Length?  cardFace: 0; // initialize face of card
            Suit = cardSuit >= 0 && cardSuit < SUITS.Length? cardSuit: 0; // initialize suit of card
        } // end two-parameter Card constructor

        // return string representation of Card
        public override string ToString()
        {
            return FACES[Face] + " of " + SUITS[Suit];
        } // end method ToString
    } // end class Card
}