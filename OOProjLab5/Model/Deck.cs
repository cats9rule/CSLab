using System;
using System.Collections.Generic;

namespace CardGame.Model
{
    public class Deck
    {
        #region Attributes

        private List<Card> deck;
        private string colour;
        private Random rng;

        #endregion

        #region Properties

        public Card this[int ind]
        {
            get
            {
                return deck[ind];
            }
            set
            {
                deck[ind] = value;
            }
        }
        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }
        public Random Rng
        {
            get { return rng; }
            set { rng = value; }
        }
        public int DeckCount
        {
            get { return deck.Count; }
        }

        #endregion

        #region Constructors
        
        public Deck(string col)
        {
            // sets specified colour
            if(col == "random")
            {
                rng = new Random(DateTime.Now.Millisecond);
                int num = rng.Next() % 6;
                switch (num)
                {
                    case 0:
                        colour = "red";
                        break;
                    case 1:
                        colour = "green";
                        break;
                    case 2:
                        colour = "blue";
                        break;
                    case 3:
                        colour = "yellow";
                        break;
                    case 4:
                        colour = "purple";
                        break;
                    case 5:
                        colour = "gray";
                        break;
                }
            }
            else
            {
                colour = col;
            }

            // creating the deck
            deck = new List<Card>(52);

            for (int i = 2; i <= 14; i++)
            {
                deck.Add(new Card(i.ToString(), SignEnum.SPADES, colour));
                deck.Add(new Card(i.ToString(), SignEnum.HEARTS, colour));
                deck.Add(new Card(i.ToString(), SignEnum.CLUBS, colour));
                deck.Add(new Card(i.ToString(), SignEnum.DIAMONDS, colour));
            }
            rng = new Random(DateTime.Now.Millisecond);
        }

        #endregion

        #region Methods

        public void Shuffle()
        {
            // Knuth shuffle
            
            for(int i = deck.Count - 1; i > 0; i--)
            {
                int ind = rng.Next(i + 1);
                Card temp = deck[ind];
                deck[ind] = deck[i];
                deck[i] = temp;
            }
        }

        public Card PullCard()
        {
            int ind = rng.Next(0, deck.Count-1);
            Card c = deck[ind];
            deck.RemoveAt(ind);
            return c;
        }

        public void ReturnCard(Card c)
        {
            if (!deck.Contains(c))
            {
                Card card = new Card(c);
                deck.Add(card);
            }
            else throw new Exception("Card already in deck!");
        }

        #endregion
    }
}
