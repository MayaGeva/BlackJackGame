using System;
using System.Text;

namespace BlackJackGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Player player = new Player();
            Player computer = new Player();
            Graphics grp = new Graphics();

            Card[] temp = player.GetCards();
            CheckBlackJack(temp[0], temp[1]);

            player = Turn(player);

            Console.Clear();
            
            Console.WriteLine("\nYour cards were:");
            grp.DrawCards(player);

            Console.WriteLine("\nThe computer's cards were:");
            grp.DrawCards(computer);
            CheckWinner(player, computer);
            Console.ReadLine();
        }

        static Card GenarateCard()
        {
            Card c = new Card();
            return c;
        }

        static Player Turn(Player p)
        {
            bool playing = true, repeat = false;
            string input;
            Graphics grp = new Graphics();
            Card newCard;
            //print cards
            
            while (playing)
            {
                if (p.CardSum() > 21)
                {
                    playing = false;
                    break;
                }

                grp.DrawCards(p);
                Console.WriteLine("Would you like another card? (y or n)");
                input = Console.ReadLine();

                if (input == "y")
                {
                    newCard = GenarateCard();
                    if (newCard.GetNum() == 1)
                    {
                        do
                        {
                            Console.WriteLine("Would you like to upgrade the Ace to 11? (y or n)");
                            input = Console.ReadLine();
                            if (input == "n")
                                continue;
                            else if (input == "y")
                                newCard.SetNum(11);
                            else
                            {
                                repeat = true;
                                Console.WriteLine("Invalid answer");
                            }
                        } while (repeat);
                        repeat = false;
                    }
                    p.AddCard(newCard);
                }
                else if (input == "n")
                    playing = false;
                else
                {
                    Console.WriteLine("Invalid answer.");
                    Console.ReadLine();
                }
                Console.Clear();
            }
            return p;
        }

        static void CheckWinner(Player p, Player com)
        {
            if ((p.CardSum() >= com.CardSum() && p.CardSum() < 22) || (p.CardSum() > 21 && com.CardSum() > 21))
                Console.WriteLine("You Win!");
            
            else
                Console.WriteLine("You Lose!");
        }

        static bool CheckBlackJack(Card c1, Card c2)
        {
            if (c1.GetNum() + c2.GetNum() == 21 || ((c1.GetNum() == 1 && c2.GetNum() == 10) || (c2.GetNum() == 1 && c1.GetNum() == 10)))
            {
                Console.WriteLine("BlackJack!");
                return true;
            }
            return false;
        }
    }
}
