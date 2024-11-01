using System;

class TicTacToe {
    static char[] board = {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
    static int player = 1;
    static int choice; 
    static int flag = 0;

    static void Main() {
        do {
            if (player % 2 == 0) {
                Console.WriteLine("Det er spiller 0 tur");
            } else {
                Console.WriteLine("Det er spiller X tur");
            };

            DisplayBoard();
            choice = int.Parse(Console.ReadLine()) - 1;

              if (board[choice] != 'X' && board[choice] != 'O')
            {
                board[choice] = player % 2 == 0 ? 'O' : 'X';
                player++;
            }
            else
            {
                Console.WriteLine("Feltet er allerede valgt, prøv et andet.");
                Console.ReadLine();
            }

        } while(flag == 0);
        
            Console.Clear();
            DisplayBoard();
            if (flag == 1) {
                Console.WriteLine($"Spiller {(player % 2) +1} Vinder");
            } else {
                Console.WriteLine("Det blev uafgjort");
            }
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