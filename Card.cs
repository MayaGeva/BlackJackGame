using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame
{
    class Card
    {
        int cardNum, cardShape;
        Random rnd = new Random();

        public Card()
        {
            this.cardNum = rnd.Next(1, 14);
            this.cardShape = rnd.Next(1, 5);
        }

        public int GetNum()
        {
            return this.cardNum;
        }

        public void SetNum(int num)
        {
            this.cardNum = num;
        }

        public int GetShape()
        {
            return this.cardShape;
        }
    }
}
