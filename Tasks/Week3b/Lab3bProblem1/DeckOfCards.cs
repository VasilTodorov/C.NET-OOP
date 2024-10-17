// DeckOfCards.cs
// DeckOfCards class represents a deck of playing cards.
using System;
using System.Runtime.CompilerServices;

namespace Lab3bProblem1
{
    public class DeckOfCards
    {
        #region Datamembers
        private Card[] deck; // array of Card objects
        private int currentCard; // index of next Card to be dealt
        private const int NUMBER_OF_CARDS = 52; // constant number of Cards
        private Random randomNumbers; // random number generator

        // constructor fills deck of Cards

        private int[] faceCounters;
        private int[] suitCounters;
        private Card[] handOfCards;
        #endregion

        #region Constructor
        public DeckOfCards()
        {

            faceCounters = new int[Card.FACES.Length];
            suitCounters = new int[Card.SUITS.Length];
            handOfCards = new Card[5];

            deck = new Card[NUMBER_OF_CARDS]; // create array of Card objects
            currentCard = 0; // set currentCard so deck[ 0 ] is dealt first  
            randomNumbers = new Random(); // create random number generator

            // populate deck with Card objects
            for (int count = 0; count < deck.Length; count++)
                deck[count] = new Card(count % 13, count / 13);
        } // end DeckOfCards constructor

        #endregion

        #region BasicGame methods
        // shuffle deck of Cards with one-pass algorithm
        public void Shuffle()
        {
            // after shuffling, dealing should start at deck[ 0 ] again
            currentCard = 0; // reinitialize currentCard

            // for each Card, pick another random Card and swap them
            for (int first = 0; first < deck.Length; first++)
            {
                // select a random number between 0 and 51 
                int second = randomNumbers.Next(NUMBER_OF_CARDS);

                // swap current Card with randomly selected Card
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            } // end for
        } // end method Shuffle

        // deal one Card
        public Card? DealCard()
        {
            // determine whether Cards remain to be dealt
            if (currentCard < deck.Length)
                return deck[currentCard++]; // return current Card in array
            else
                return null; // indicate that all Cards were dealt
        } // end method DealCard 
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void DealHand()
        {
            for (int i = 0; i < handOfCards.Length; i++)
            {
                handOfCards[i] = DealCard()!;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public void EvaluateHand()
        {
            DealHand();
            // init coiunters
            Array.Fill(faceCounters, 0);
            Array.Fill(suitCounters, 0);
            //for (int i = 0; i< faceCounters.Length, i++)
            //{
            //    faceCounters[i] = 0;
            //}

            // evaluate
            for (int i = 0; i < handOfCards.Length; i++)
            {
                if (handOfCards[i] != null)
                {
                    ++faceCounters[handOfCards[i].Face];
                    ++suitCounters[handOfCards[i].Suit];
                }
            }
        }

        public bool HasNFaces(int numOfFaces)
        {
            if (!(numOfFaces > 0  && numOfFaces <= 4)) return false;

            for (int i = 0; i < faceCounters.Length; i++)
                if (faceCounters[i] == numOfFaces) return true;
            return false;
        }
        public bool HasNSuits(int numOfSuits)
        {
            if (!(numOfSuits > 0 && numOfSuits <= 5)) return false;

            for (int i = 0; i < suitCounters.Length; i++)
                if (suitCounters[i] == numOfSuits) return true;
            return false;
        }

        public void PrintHand( )
        {
            Console.WriteLine( "Cards in current hand...");
            for (int i = 0; i < handOfCards.Length; i++)
            {
                if (handOfCards[i] != null)
                    Console.WriteLine(handOfCards[i]);
            }
        }

    } // end class DeckOfCards
}