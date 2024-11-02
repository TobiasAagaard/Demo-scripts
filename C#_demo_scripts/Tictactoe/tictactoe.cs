using System;

class TicTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1;
    static int choice;
    static int flag = 0;

    static void Main()
    {
        bool playAgain = true;

        while (playAgain)
        {
            ResetBoard();
            Console.Clear(); 

            do
            {
                Console.Clear();
                DisplayBoard();

                if (player % 2 == 0)
                {
                    Console.WriteLine("Det er spiller O tur");
                }
                else
                {
                    Console.WriteLine("Det er spiller X tur");
                }

                Console.Write("Vælg et felt (1-9): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9)
                {
                    choice--; 

                    if (board[choice] != 'X' && board[choice] != 'O')
                    {
                        board[choice] = player % 2 == 0 ? 'O' : 'X';
                        player++;
                        flag = CheckWin(); 
                    }
                    else
                    {
                        Console.WriteLine("Feltet er allerede valgt, prøv et andet.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg, vælg et tal mellem 1 og 9.");
                    Console.ReadLine();
                }

            } while (flag == 0);

            Console.Clear();
            DisplayBoard();
            if (flag == 1)
            {
                Console.WriteLine($"Spiller {(player % 2) + 1} Vinder");
            }
            else
            {
                Console.WriteLine("Det blev uafgjort");
            }

            Console.WriteLine("Vil du spille igen? (j/n)");
            playAgain = Console.ReadLine().Trim().ToLower() == "j";
        }
    }

    static void ResetBoard()
    {
        board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        player = 1;
        flag = 0;
    }

    static int CheckWin()
    {
        int[,] winningCombinations = new int[,] {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Vandrette
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Lodrette
            { 0, 4, 8 }, { 2, 4, 6 }              // Diagonale
        };

        for (int i = 0; i < 8; i++)
        {
            int a = winningCombinations[i, 0];
            int b = winningCombinations[i, 1];
            int c = winningCombinations[i, 2];

            if (board[a] == board[b] && board[b] == board[c])
            {
                return 1; 
            }
        }

        foreach (char cell in board)
        {
            if (cell != 'X' && cell != 'O')
            {
                return 0; 
            }
        }

        return -1; 
    }

    static void DisplayBoard()
    {
        Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
    }
}



