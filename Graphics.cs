using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BlackJackGame
{
    class Graphics
    {
        private char[] shapes = { '♥', '♦', '♠', '♣'};
        private string[] types = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        public void DrawCards(Player p)
        {
            Card[] cards = p.GetCards();
            int xLoc = Console.CursorLeft, yLoc = Console.CursorTop + 3;

            for (int i = 0; i < cards.Length; i++)
            {
                Console.SetCursorPosition(xLoc, yLoc);
                PrintCard((cards[i].GetShape() - 1), (cards[i].GetNum() - 1), xLoc, yLoc);
                xLoc += 15;
                if (i == 5)
                {
                    yLoc += 13;
                    xLoc = 3;
                }
            }
            Console.WriteLine("\nThe cards add up to {0} points.", p.CardSum());
        }

        public void PrintCard(int shape, int num, int x, int y)
        {
            string space = (num - 1) == 10? "" : " ";
            
            Console.WriteLine("+-----------+");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("| {0}       {1} |", types[num], space);
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("|           |");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("|           |");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("|     {0}     |", shapes[shape]);
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("|           |");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("|           |");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("| {1}       {0} |", types[num], space);
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("+-----------+");
        }
    }
}
