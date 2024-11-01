using System;

class TicTacToe {
    static char[] board = {'0', '1', '2', '3', '4', '5', '6', '7', '8'};
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
        } while(flag == 1);
    }
}