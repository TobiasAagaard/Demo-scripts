using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-- Welcome to Yatzy --");

        // Initialize game variables
        bool playing = true;
        int turn = 1;

        // Main game loop
        while (playing)
        {
            Console.WriteLine($"\n-- Turn {turn} --");
            int[] dice = RollDice();
            DisplayDice(dice);

            for (int roll = 1; roll < 3; roll++)
            {
                Console.WriteLine($"Roll {roll}/3 - Would you like to reroll? (y/n)");
                if (Console.ReadLine()?.ToLower() != "y")
                    break;

                Console.WriteLine("Enter the dice positions (1-5) to reroll, separated by spaces:");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    int[] positions = Array.ConvertAll(input.Split(' '), int.Parse);
                    dice = RerollDice(dice, positions);
                    DisplayDice(dice);
                }
            }

            // Add scoring logic here
            Console.WriteLine("Enter the category for scoring (e.g., '1s', '2s', 'Full House'):");
            string category = Console.ReadLine();

            // Calculate and display score
            int score = CalculateScore(dice, category);
            Console.WriteLine($"You scored {score} points for {category}!");

            // End turn
            Console.WriteLine("Play another turn? (y/n)");
            if (Console.ReadLine()?.ToLower() != "y")
                playing = false;

            turn++;
        }

        Console.WriteLine("-- Thanks for playing Yatzy! --");
    }

    static int[] RollDice()
    {
        Random rand = new Random();
        int[] dice = new int[5];
        for (int i = 0; i < 5; i++)
        {
            dice[i] = rand.Next(1, 7); // Rolls a number between 1 and 6
        }
        return dice;
    }

    static void DisplayDice(int[] dice)
    {
        Console.WriteLine("Dice: " + string.Join(" ", dice));
    }

    static int[] RerollDice(int[] dice, int[] positions)
    {
        Random rand = new Random();
        foreach (int pos in positions)
        {
            if (pos >= 1 && pos <= 5)
                dice[pos - 1] = rand.Next(1, 7);
        }
        return dice;
    }

    static int CalculateScore(int[] dice, string category)
    {
        // Placeholder: Replace with actual scoring logic
        return 0;
    }
}
