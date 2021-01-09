using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;

namespace CardGame.Model
{
    public enum SignEnum
    {
        SPADES,
        HEARTS,
        CLUBS,
        DIAMONDS
    }

    public class Card : IComparable
    {

        #region Attributes

        private string number;
        private SignEnum sign;
        private Image imgFront;
        private Image imgBack;

        #endregion

        #region Properties

        public string Number
        {
            get { return number; }
            set 
            {
                int val = 0;
                if(Int32.TryParse(value, out val))
                {
                    if (val >= 2 && val <= 10)
                    {
                        number = value;
                    }
                    else
                    {
                        switch (val)
                        {
                            case 11:
                                number = "J";
                                break;
                            case 12:
                                number = "Q";
                                break;
                            case 13:
                                number = "K";
                                break;
                            case 14:
                                number = "A";
                                break;
                            default:
                                number = "K";
                                break;
                        }
                    }
                }
                else if(value == "A" || value=="a")
                {
                    number = "A";
                }
                else if(value == "J" || value == "j")
                {
                    number = "J";
                }
                else if(value == "Q" || value == "q")
                {
                    number = "Q";
                }
                else if(value=="K" || value == "k")
                {
                    number = "K";
                }
                else
                {
                    number = "";
                }

            }
        }
        public SignEnum Sign
        {
            get { return sign; }
        }
        public Image ImgFront
        {
            get { return imgFront; }
        }
        public Image ImgBack
        {
            get { return imgBack; }
        }
        public string CardName
        {
            get
            {
                string name = number;
                switch (sign)
                {
                    case SignEnum.CLUBS:
                        name += "C";
                        break;
                    case SignEnum.SPADES:
                        name += "S";
                        break;
                    case SignEnum.HEARTS:
                        name += "H";
                        break;
                    case SignEnum.DIAMONDS:
                        name += "D";
                        break;
                }
                return name;
            }
        }
        string CardNameSuitFirst // exists solely for the purposes of Compare() function to work
        {
            get
            {
                string name = "";
                switch (sign)
                {
                    case SignEnum.CLUBS:
                        name += "C";
                        break;
                    case SignEnum.SPADES:
                        name += "S";
                        break;
                    case SignEnum.HEARTS:
                        name += "H";
                        break;
                    case SignEnum.DIAMONDS:
                        name += "D";
                        break;
                }
                if(Value < 10)
                {
                    name += "0";
                }
                name += Value.ToString();

                return name;
            }
        }
        public int Value
        {
            get
            {
                int val = 0;
                switch (number)
                {
                    case "2":
                        val = 2;
                        break;
                    case "3":
                        val = 3;
                        break;
                    case "4":
                        val = 4;
                        break;
                    case "5":
                        val = 5;
                        break;
                    case "6":
                        val = 6;
                        break;
                    case "7":
                        val = 7;
                        break;
                    case "8":
                        val = 8;
                        break;
                    case "9":
                        val = 9;
                        break;
                    case "10":
                        val = 10;
                        break;
                    case "J":
                        val = 11;
                        break;
                    case "Q":
                        val = 12;
                        break;
                    case "K":
                        val = 13;
                        break;
                    case "A":
                        val = 14;
                        break;
                }
                return val;
            }
        }

        #endregion

        #region Constructors

        public Card() { }

        public Card(string num, SignEnum sgn, string colour)
        {
            Number = num;
            sign = sgn;

            LoadBackImage(colour);
            LoadFrontImage();
        }
        
        public Card(Card c)
        {
            number = c.Number;
            sign = c.Sign;
            imgFront = c.ImgFront;
            imgBack = c.ImgBack;
        }

        #endregion

        #region Methods

        private bool LoadBackImage(string colour)
        {
            if(colour != "red" && colour != "green" && colour != "blue" && 
                colour != "gray" && colour != "purple" && colour != "yellow")
            {
                return false;
            }
            colour += "_back.png";
            string path = "../CardSprites/" + colour;
            if (File.Exists(path))
            {
                imgBack = Image.FromFile(path);
                return true;
            }
            else return false;
        }
        private bool LoadFrontImage()
        {
            // based on the name of the card
            string path = "../../../CardSprites/" + CardName + ".png";
            if (File.Exists(path))
            {
                imgFront = Image.FromFile(path);
                return true;
            }
            else return false;
        }

        public int CompareTo(object obj) // compares suit first, value second
        {
            Card c = (Card)obj;

            string card1 = CardNameSuitFirst;
            
            string card2 = c.CardNameSuitFirst;
            
            return card1.CompareTo(card2);
        }

        #endregion
    }

    public class CardValueComparer : IComparer<Card>
    {
        // compares value, ignores suit
        public int Compare(Card c1, Card c2)
        {
            return c1.Value - c2.Value;
        }
    }

    public class CardValueFirstComparer : IComparer<Card>
    {
        public int Compare(Card c1, Card c2)
        {
            string card1 = "";
            if(c1.Value < 10)
            {
                card1 += "0";
            }
            card1 += c1.Value.ToString();
            switch (c1.Sign)
            {
                case SignEnum.SPADES:
                    card1 = "S";
                    break;
                case SignEnum.HEARTS:
                    card1 = "H";
                    break;
                case SignEnum.CLUBS:
                    card1 = "C";
                    break;
                case SignEnum.DIAMONDS:
                    card1 = "D";
                    break;
            }
            string card2 = "";
            if (c2.Value < 10)
            {
                card2 += "0";
            }
            card2 += c2.Value.ToString();
            switch (c2.Sign)
            {
                case SignEnum.SPADES:
                    card2 = "S";
                    break;
                case SignEnum.HEARTS:
                    card2 = "H";
                    break;
                case SignEnum.CLUBS:
                    card2 = "C";
                    break;
                case SignEnum.DIAMONDS:
                    card2 = "D";
                    break;
            }
            return card1.CompareTo(card2);
        }
    }
}
