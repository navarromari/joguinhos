using System;

namespace TicTacToe
{
    class Program
    {
        
        public static int currentPlayer = 1;

        public static int[,] board =
        {
            {0, 0, 0 },
            {0, 0, 0 },
            {0, 0, 0 },
        };

        static void Main()
        {
            Play();
        }

        static void Play()
        {
            while (!Checker(board))
            {
                PlayerTurn();
            }

            Reset();

        }

        static void drawBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("     |     |     ");


                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                    {
                        Console.Write($"  {i * 3 + j + 1}  ");
                    }
                    else if (board[i, j] == 1)
                    {
                        Console.Write("  O  ");
                    }
                    else if (board[i, j] == 2)
                    {
                        Console.Write("  X  ");
                    }
                    else
                    {
                        Console.Write("  ?  ");
                    }

                    if (j <= 1)
                    {
                        Console.Write("|");
                    }
                }
                if (i <= 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("_____|_____|_____");
                }
            }
            Console.WriteLine();
            Console.WriteLine("     |     |     ");
        }

        static void PlayerTurn()
        {
            // Get int
            bool userEnteredANumber;
            int fieldNumber;

            drawBoard();

            do
            {
                Console.Write($"\nPlayer {currentPlayer}: Choose your field! ");
                string field = Console.ReadLine();
                userEnteredANumber = int.TryParse(field, out fieldNumber);
                if (!userEnteredANumber)
                {
                    Console.WriteLine("Please enter a number!");
                    Console.WriteLine("\n   Incorrect input! Please use another field!");

                }
            } while (!userEnteredANumber);
            
            // Compute play
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    board[(fieldNumber-1)/3, (fieldNumber - 1) % 3] = currentPlayer;
                }
            }

            currentPlayer = currentPlayer == 1 ?  2 :  1;
            Console.Clear();

        }
        
         static bool Checker(int[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != 0)
                {
                    drawBoard();
                    Console.WriteLine($"\nPlayer {board[i, 0]} has won!");
                    return true;
                }
               else if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != 0)
                {
                    drawBoard();
                    Console.WriteLine($"\nPlayer {board[0, i]} has won!");
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != 0)
                {
                    drawBoard();
                    Console.WriteLine($"\nPlayer {board[0, 0]} has won!");
                    return true;
                }
                else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != 0)
                {
                    drawBoard();
                    Console.WriteLine($"\nPlayer {board[0, 2]} has won!");
                    return true;
                }
            }

            return false;

        }

        static void Reset()
        {
            Console.WriteLine("\nPress any Key to Reset the Game");
            if (Console.ReadLine() != null)
            {
                currentPlayer = 1;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[i, j] = 0;
                    }
                }
                
                Play();
            }
        }
    }
}
