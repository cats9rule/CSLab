using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Model;

namespace CardGame.Controller
{
    public class GameController
    {
        #region Attributes

        private Deck deck;
        private List<Card> hand;
        private List<bool> selectedCards;
        private int selectedCount;

        private int points;
        private int bettingPoints;

        #endregion

        #region Properties

        public Deck Deck
        {
            get { return deck; }
        }
        public List<Card> Hand
        {
            get { return hand; }
        }
        public List<bool> SelectedCards
        {
            get { return selectedCards; }
        }
        public int SelectedCount
        {
            get { return selectedCount; }
            set { selectedCount = value; }
        }
        public int Points
        {
            get { return points; }
        }
        public int BettingPoints
        {
            get { return bettingPoints; }
            set { if (value <= points) bettingPoints = value; }
        }
        
        public string StringRepresentation
        {
            get
            {
                return (hand[0].CardName + hand[1].CardName + hand[2].CardName +
                    hand[3].CardName + hand[4].CardName);
            }
        }

        #endregion

        #region Constructors

        public GameController()
        {
            hand = new List<Card>();
            selectedCards = new List<bool>(5);
            for(int i = 0; i < 5; i++)
            {
                selectedCards.Add(false);
            }
            selectedCount = 0;
            points = 0;
            bettingPoints = 0;
        }
        public GameController(int points)
        {
            hand = new List<Card>();
            selectedCards = new List<bool>(5);
            for (int i = 0; i < 5; i++)
            {
                selectedCards.Add(false);
            }
            selectedCount = 0;
            this.points = points;
            bettingPoints = 0;
        }

        #endregion

        #region Methods

        public void ResetGame()
        {
            ResetSelection();
            hand.Clear();
            deck.Shuffle();
            points = 0;
            bettingPoints = 0;
        }
        public void ResetHand()
        {
            ResetSelection();
            hand.Clear();
            if(deck.DeckCount < 5)
            {
                string col = deck.Colour;
                deck = new Deck(col);
            }
            deck.Shuffle();
            bettingPoints = 0;
        }

        #region Deck
        public void CreateDeck()
        {
            deck = new Deck();
        }
        public void CreateDeck(string colour)
        {
            deck = new Deck(colour);
        }
        #endregion

        #region Hand
        public void DrawHand()
        {
            for(int i = 0; i < 5; i++)
            {
                hand.Add(deck.PullCard());
            }
        }

        private void ReplaceCard(int index)
        {
            Card replacement = deck.PullCard();
            deck.ReturnCard(hand[index]);
            hand[index] = replacement;
        }

        public void ReplaceSelectedCards()
        {
            for(int i = 0; i < 5; i++)
            {
                if (selectedCards[i])
                {
                    ReplaceCard(i);
                }
            }
        }

        public void ResetSelection()
        {
            if(selectedCount > 0)
            {
                for(int i = 0; i < 5; i++)
                {
                    selectedCards[i] = false;
                }
                selectedCount = 0;
            }
        }

        public List<Card> GetSortedHand()
        {
            List<Card> sorted = new List<Card>(hand);
            sorted.Sort();
            return sorted;
        }

        public List<Card> SortHandByValue()
        {
            List<Card> sorted = new List<Card>(hand);
            sorted.Sort(new CardValueComparer()); // the comparer doesnt care about the card suit

            return sorted;
        }
        #endregion

        #region Points
        public bool IsGameOver()
        {
            if (points == 0)
            {
                return true;
            }
            else return false;
        }

        public void UpdatePoints(out int multiplier)
        {
            multiplier = ComboMultiplier();
            points += bettingPoints * multiplier;
        }

        public void PlaceBet(int betAmount)
        {
            bettingPoints = betAmount;
            points -= betAmount;
        }

        public void SetPoints(int points)
        {
            if(points <= 1000000 && points > 0)
            {
                this.points = points;
            }
            else
            {
                this.points = 0;
            }
        }
        #endregion

        #region Combination Checks

        /* Classification and Rules:
         * 
         * If its a flush, it could possibly be a straight flush, possibly bobtail, and
         * it cant be anything else (pair, two pairs, three of a kind, four of a kind, full house)
         *    blaze - special case 
         *    
         *    There are 3 groups of combinations:
         *      1) Flush kind - straight flush, flush or bobtail
         *      2) Non-Flush kind - four of a kind, three of a kind, full house, pair or two pairs
         *      3) Miscellaneous - blaze, straight, no combination (all are mutually exclusive)
         *          - all three are mutually exclusive
         
         * straight flush   x- 100 (straight and flush - same suit, consecutive order)
         * four of a kind   x-  60
         * big bobtail      x-  40 (4 cards same suit consecutive order)
         * full house       x-  24 (3-2 combo)
         * flush            x-  16 (all cards same suit)
         * straight         x-  12 (all cards consecutive order)
         * blaze            x-   9 (all Js, Qs or Ks)
         * three of a kind  x-   6
         * two pairs        x-   4 
         * one pair         x-   2 
         
         */

        public int ComboMultiplier()
        {
            if (IsFlush())
            {
                if (IsStraight())
                {
                    return 100;
                }
                if (IsBobtail())
                {
                    return 40;
                }
                return 16;
            }
            else
            {
                if (IsBlaze())
                {
                    return 9;
                }
                else if (IsStraight())
                {
                    return 12;
                }

                bool ind;
                if(IsFourOrThreeOfAKind(out ind))
                {
                    return 60;
                }
                if (ind)
                {
                    if (IsFullHouse(ind))
                    {
                        return 24;
                    }
                    else return 6;
                }
                else
                {
                    if (IsTwoPair(out ind))
                    {
                        return 4;
                    }
                    if (ind)
                    {
                        return 2;
                    }
                }
            }

            // if nothing reached return statement, then its an empty hand
            
            return 0;
        }

        private bool IsFlush()
        {
            bool isFlush = true;
            for(int i = 0; i < 4; i ++)
            {
                // check if all cards are in the same suit
                if(hand[i].Sign != hand[i + 1].Sign)
                {
                    isFlush = false;
                    break;
                }
            }
            return isFlush;
        }
        private bool IsStraight() // i am not
        {
            hand = SortHandByValue();
            int low = hand[0].Value;
            if (hand[1].Value == low + 1 && hand[2].Value == low + 2 && hand[3].Value == low + 3 &&
                hand[4].Value == low + 4)
            {
                return true;
            }
            else return false;
        }
        private bool IsBobtail()
        {
            // 4 cards of the same suit in consecutive order
            hand = GetSortedHand(); // sorts suit first
            int ind = 0;
            if(hand[0].Sign != hand[1].Sign)
            {
                if(hand[1].Sign == hand[2].Sign)
                {
                    ind++;
                }
                else
                {
                    // cant be a bobtail then
                    return false;
                }
            }
            int low = hand[ind].Value;
            SignEnum sgn = hand[ind].Sign;
            for(int i = 1; i < 4; i++) // C6 D10 DJ DQ DK
            {
                if(hand[ind + i].Sign != sgn || hand[ind + i].Value != low + i)
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsBlaze()
        {
            // all cards are either Js, Qs or Ks
            for(int i = 0; i < 5; i++)
            {
                string royalty = hand[i].Number;
                if (royalty != "J" && royalty != "Q" && royalty != "K")
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsFourOrThreeOfAKind(out bool threeOfAKind)
        {
            /* priority: 4 of a kind > 3 of a kind 
             * if 3 of a kind is true, needs to be checked for full house 
             */
            hand = SortHandByValue();
            threeOfAKind = false;
            for(int i = 0; i < 3; i++)
            {
                if(hand[i].Value == hand[i+1].Value && hand[i].Value == hand[i + 2].Value)
                {
                    threeOfAKind = true;
                    if (i + 3 < 5 && hand[i].Value == hand[i + 3].Value)
                        return true;
                }
            }
            return false;
        }
        private bool IsTwoPair(out bool onePair)
        {
            hand = SortHandByValue();
            // the hand is sorted, pairs should be adjacent
            int ind = 10;
            for (int i = 0; i < 4; i++)
            {
                if (hand[i].Value == hand[i + 1].Value)
                {
                    ind = i;
                    break;
                }
            }
            if (ind >= 3)
            {
                if(ind == 10)
                {
                    onePair = false;
                    return false;
                }
                onePair = true;
                return false;
            }
            // if none of the conditions are met, that means theres potential for another pair
            for(int i = ind + 1; i < 4; i++)
            {
                if(hand[i].Value == hand[i + 1].Value)
                {
                    onePair = false;
                    return true;
                }
            }
            onePair = true;
            return false;
        }
        private bool IsFullHouse(bool foundThree)
        {
            if (!foundThree)
            {
                this.hand = SortHandByValue();
            }
            // its sorted, so if there is a full house, its either XXYYY of YYYXX format

            if (hand[0].Value == hand[1].Value &&
                hand[2].Value == hand[3].Value &&
                hand[2].Value == hand[4].Value)
            {
                return true;
            }
            else if (hand[0].Value == hand[1].Value &&
                hand[0].Value == hand[2].Value &&
                hand[3].Value == hand[4].Value)
            {
                return true;
            }
            else return false;
        }
        #endregion

        #endregion


    }
}
