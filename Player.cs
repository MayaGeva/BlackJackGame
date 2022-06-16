using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame
{
    class Player
    {
        Card[] cards;
        int currentCards;

        public Player()
        {
            this.cards = new Card[10];
            this.currentCards = 2;
            this.cards[0] = new Card();
            this.cards[1] = new Card();
        }

        public Card[] GetCards()
        {
            Card[] c = new Card[this.currentCards];
            for (int i = 0; i < c.Length; i++)
            {
                if (this.cards[i] != null)
                    c[i] = this.cards[i];
            }
            return c;
        }

        public int GetNumCards()
        {
            return this.currentCards;
        }
        public void AddCard(Card card)
        {
            this.cards[this.currentCards] = card;
            this.currentCards++;
        }

        public int CardSum()
        {
            int sum = 0;
            for (int i = 0; i < this.currentCards; i++)
            {
                sum += this.cards[i].GetNum() > 10? 10 : this.cards[i].GetNum();
            }
            return sum;
        }
    }
}
