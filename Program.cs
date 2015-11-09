using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPE1700GiyeonKimICAs05
{
    class Program
    {

        static void Main(string[] args)
        {
            bool exit = false;
            Players player = new Players();
            Players computer = new Players();
            Console.ForegroundColor = ConsoleColor.White;

            player.GenerateHand();
            computer.GenerateHand();
            Console.WriteLine("Welcome to poker game!");
            Console.WriteLine("\nReady to play? (y/n)");
            string userinput = Console.ReadLine();
            if (userinput == "N" || userinput == "n")
                exit = true;
            string[] x = new string[5];
            string[] su = new string[5];
            string[] group = new string[5];
            int player_rank = 0;
            int computer_rank = 0;
            while (!exit)
            {
                Console.WriteLine("\nYour cards are:\n");
                for (int i = 0; i < 5; i++)
                {

                    x[i] = player.hand[i].Face.ToString();
                    su[i] = computer.hand[i].Suits.ToString();
                    group[i] = player.hand[i].Face.ToString() + " of " + computer.hand[i].Suits.ToString();
                }
                Array.Sort(x);
                Array.Sort(su);
                Array.Sort(group);
                
                             
                player_rank = num(x, su);
                organize(player_rank, x, su, group);
                Console.WriteLine("The rank of player is " + player_rank);
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nComputer Cards are: \n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine( " is the number of pair player got");
                string[] d = new string[5];
                string[] y = new string[5];
                string[] su1 = new string[5];
                
                for (int j = 0; j < 5; j++)
                {
                    y[j] = computer.hand[j].Face.ToString();
                    su1[j] = computer.hand[j].Suits.ToString();
                    d[j] = (computer.hand[j].Face.ToString()+" of "+ computer.hand[j].Suits.ToString()) ;
                }
                Array.Sort(d);
                Array.Sort(y);
                Array.Sort(su1);
                computer_rank = num(y, su1);
                organize(computer_rank, y, su1, d);
                Console.WriteLine("The computer rank is " + computer_rank);

                if (player_rank < computer_rank)
                    Console.WriteLine("player wins");
                if (player_rank > computer_rank)
                    Console.WriteLine("computer wins");
                if (player_rank == computer_rank)
                    Console.WriteLine("They are tie");


                exit = true;
            }

            Console.WriteLine("\nThank you for Playing the Game! \nPress any key to exit the game!");

            Console.ReadKey();
        }
        public static int num(string[]face, string[] suit)
        {
            int count = 0;
            int c = 0;
            int j = 0;
            int count1 = 0;
            int c1 = 0;
            int j1 = 0;
            int rank = 0;       
            for (int i = 0; i < 5; i++)
            {
                j = i + 1;
                if (j < 5)
                {
                    if (face[i] == face[j])
                    {
                        c++;
                        count += c;
                    }
                    else
                        c = 0;
                }
            }
            
            for (int i = 0; i < 5; i++)
            {
                j1 = i + 1;
                if (j1 < 5)
                {
                    if (suit[i] == suit[j1])
                    {
                        c1++;
                        count1 += c1;
                    }
                    else
                        c1 = 0;
                }

            }
            int e = 0;

            if (face[0] == "Ace" && face[1] == "Jack" && face[2] == "King" && face[3] == "Queen" && face[4] == "Ten" && count1 == 10)
            {
                rank = 1;

            }
            else if ((face[0] == "Five" && face[1] == "Four" && face[2] == "Six" && face[3] == "Three" & face[4] == "Two" & count1 == 10) || (
                (face[0] == "Five" && face[1] == "Four" && face[2] == "Seven" && face[3] == "Six" & face[4] == "Three" & count1 == 10) ||
                (face[0] == "Eight" && face[1] == "Five" && face[2] == "Four" && face[3] == "Seven" & face[4] == "Six" & count1 == 10) ||
                (face[0] == "Eight" && face[1] == "Five" && face[2] == "Nine" && face[3] == "Seven" & face[4] == "Six" & count1 == 10) ||
                (face[0] == "Eight" && face[1] == "Nine" && face[2] == "Seven" && face[3] == "Six" & face[4] == "Ten" & count1 == 10)))
           {
                rank = 2;
            }
            else if (count1 == 10)
            {
                rank = 5;
            }
            else if (count == 6)
                rank = 3;
            else if (count == 3)
                rank = 4;
            else if (count == 2)
                rank = 6;
            else if (count == 1)
                rank = 7;
            else if (count == 0)
                rank = 8;

            return rank;
        }
        public static void organize(int rank, string[]face, string []suit, string[]group)
        {
            for (int i = 0; i < 5; i++)
            {
                if (face[i] == "Two")
                {
                    face[i] = "2";
                }
                if (face[i] == "Three")
                {
                    face[i] = "3";
                }
                if (face[i] == "Four")
                {
                    face[i] = "4";
                }
                if (face[i] == "Five")
                {
                    face[i] = "5";
                }
                if (face[i] == "Six")
                {
                    face[i] = "6";
                }
                if (face[i] == "Seven")
                {
                    face[i] = "7";
                }
                if (face[i] == "Eight")
                {
                    face[i] = "8";
                }
                if (face[i] == "Nine")
                {
                    face[i] = "9";
                }
                if (face[i] == "Ten")
                {
                    face[i] = "10";
                }
            }
            if (rank == 1)
            {
                string[] card = new string[5] { "A", "K", "Q", "J", "10" };
                string s = suit[0];
                foreach (string x in card)
                    draw(x, s, group);
            }
            else if (rank == 2)
            {
                Array.Sort(face);

                string w = suit[0];
                foreach (string x in face)
                    draw(x, w, group);
            }
            else if (rank == 5)
            {
                
                string q = suit[0];
                for (int i = 0; i < 5; i++)
                {
                    if (group[i].Contains("Two"))
                    {
                        face[i] = "2";
                    }
                    if (group[i].Contains("Three"))
                    {
                        face[i] = "3";
                    }
                    if (group[i].Contains("Four"))
                    {
                        face[i] = "4";
                    }
                    if (group[i].Contains("Five"))
                    {
                        face[i] = "5";
                    }
                    if (group[i].Contains("Six"))
                    {
                        face[i] = "6";
                    }
                    if (group[i].Contains("Seven"))
                    {
                        face[i] = "7";
                    }
                    if (group[i].Contains("Eight"))
                    {
                        face[i] = "8";
                    }
                    if (group[i].Contains("Nine"))
                    {
                        face[i] = "9";
                    }
                    if (group[i].Contains("Ten"))
                    {
                        face[i] = "10";
                    }
                    if (group[i].Contains("Jack"))
                        face[i] = "J";
                    if (group[i].Contains("Queen"))
                        face[i] = "Q";
                    if (group[i].Contains("King"))
                        face[i] = "K";
                    if (group[i].Contains("Ace"))
                        face[i] = "A";

                }
                Array.Sort(face);
                foreach (string x in face)
                    draw(x, q, group);
            }
            else
            {
                
                for (int i = 0; i < 5; i++)
                {
                    if (group[i].Contains("Two"))
                    {
                        face[i] = "2";
                    }
                    if (group[i].Contains("Three"))
                    {
                        face[i] = "3";
                    }
                    if (group[i].Contains("Four"))
                    {
                        face[i] = "4";
                    }
                    if (group[i].Contains("Five"))
                    {
                        face[i] = "5";
                    }
                    if (group[i].Contains("Six"))
                    {
                        face[i] = "6";
                    }
                    if (group[i].Contains("Seven"))
                    {
                        face[i] = "7";
                    }
                    if (group[i].Contains("Eight"))
                    {
                        face[i] = "8";
                    }
                    if (group[i].Contains("Nine"))
                    {
                        face[i] = "9";
                    }
                    if (group[i].Contains("Ten"))
                    {
                        face[i] = "10";
                    }
                    if (group[i].Contains("Jack"))
                        face[i] = "J";
                    if (group[i].Contains("Queen"))
                        face[i] = "Q";
                    if (group[i].Contains("King"))
                        face[i] = "K";
                    if (group[i].Contains("Ace"))
                        face[i] = "A";
                   

                }

                 Array.Sort(group);

                for (int i = 0; i < 5; i++)
                {
                    if (group[i].Contains("Clubs"))
                        suit[i] = "Clubs";
                    if (group[i].Contains("Diamonds"))
                        suit[i] = "Diamonds";
                    if (group[i].Contains("Spades"))
                        suit[i] = "Spades";
                    if (group[i].Contains("Hearts"))
                        suit[i] = "Hearts";
                }
                for (int i = 0; i < 5; i++)
                {
                    draw(face[i], suit[i], group);
                }
            }
        }
        public static void draw(string face, string suit, string[] group)
        {
            int s = 0;
            if (suit == "Diamonds")
            {
                char c = '♦';

                s = 4;

                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (suit == "Hearts")
            {
                suit = @"♥";
                s = 3;

                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (suit == "Spades")
            {
                s = 6;

                Console.ForegroundColor = ConsoleColor.White;
            }
            if (suit == "Clubs")
            {
                suit = @"♣";
                s = 5;
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("______________");
            if (face.Length == 1)
            { 
                Console.WriteLine("| {0}{1}         |", face, ((char)s));
            }
            else
                Console.WriteLine("| {0}{1}        |", face, ((char)s));

            for (int i =0; i< 8;i++)
            {
                Console.WriteLine("|            |");
            }
            Console.WriteLine("______________");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void HandRank(int rank)
        {
            string rule = null;
            if (rank == 1)
            {
                rule = "Royal flush";
            }
            if (rank == 2)
            {
                rule = "Straight flush";
            }
            if (rank == 3)
            {
                rule = "Four of a kind";
            }
            if (rank == 4)
            {
                rule = "Full house";
            }
            if (rank == 5)
            {
                rule = "Flush";
            }
            if (rank == 6)
            {
                rule = "Straight";
            }
            if (rank == 7)
            {
                rule = "Three of a kind";
            }
            if (rank == 8)
            {
                rule = "Two Pair";
            }
            if (rank == 9)
            {
                rule = "One pair";
            }
            if (rank == 10)
            {
                rule = "No match";
            }

        }
    }
}
