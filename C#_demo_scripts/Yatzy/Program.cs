using System;
using System.Collections.Generic;

class Program
{
    static readonly List<string> Categories = new List<string>
    {
        "Ones", "Twos", "Threes", "Fours", "Fives", "Sixes",
        "Three of a Kind", "Four of a Kind", "Full House",
        "Small Straight", "Large Straight", "Yatzy", "Chance"
    };

    static void Main(string[] args)
    {
        Console.WriteLine("-- Welcome to Yatzy --");

        Console.Write("Enter number of players: ");
        if (!int.TryParse(Console.ReadLine(), out int numPlayers) || numPlayers <= 0)
        {
            Console.WriteLine("Invalid number of players. Please enter a positive integer.");
            return;
        }

        List<Player> players = InitializePlayers(numPlayers);

        bool gameActive = true;

        while (gameActive)
        {
            foreach (Player player in players)
            {
                Console.WriteLine($"\n-- {player.Name}'s Turn --");
                PlayTurn(player);

                Console.WriteLine("\nCurrent Scoreboard:");
                DisplayScoreboard(players);
            }

            Console.WriteLine("Play another round? (y/n)");
            string playAgain = Console.ReadLine()?.ToLower();
            if (playAgain != "y")
                gameActive = false;
        }

        Console.WriteLine("-- Thanks for playing Yatzy! --");
    }

 static List<Player> InitializePlayers(int numPlayers)
{
    List<Player> players = new List<Player>();
    for (int i = 1; i <= numPlayers; i++)
    {
        Console.Write($"Enter name for Player {i}: ");
        string name = Console.ReadLine();
        players.Add(new Player(Categories) { Name = name });
    }
    return players;
}

    static void PlayTurn(Player player)
    {
        int[] dice = RollDice();
        List<int> savedDice = new List<int>();

        for (int roll = 1; roll <= 3; roll++)
        {
            Console.WriteLine($"\nRoll {roll}/3");
            DisplayDice(dice, savedDice);

            if (roll < 3)
            {
                Console.WriteLine("Enter dice positions (1-5) to save, separated by spaces, or press Enter to skip:");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    int[] positions = ParsePositions(input);
                    if (positions != null)
                        SaveDice(dice, savedDice, positions);
                }

                dice = RollDice(5 - savedDice.Count);
            }
        }

        Console.WriteLine("\nFinal Dice:");
        DisplayDice(dice, savedDice);

        Console.WriteLine("\nAvailable Categories:");
        DisplayAvailableCategories(player);

        Console.WriteLine("Enter category for scoring:");
        string category = Console.ReadLine();

        if (player.Scoreboard.ContainsKey(category) && player.Scoreboard[category] >= 0)
        {
            Console.WriteLine("Category already used! Choose another category.");
            return;
        }

        int score = CalculateScore(savedDice.ToArray(), dice, category);
        player.AddScore(category, score);

        Console.WriteLine($"{player.Name} scored {score} points in {category}!");
    }

    static int[] ParsePositions(string input)
    {
        try
        {
            return Array.ConvertAll(input.Split(' '), int.Parse);
        }
        catch
        {
            Console.WriteLine("Invalid positions. Please enter numbers between 1 and 5.");
            return null;
        }
    }

    static void DisplayDice(int[] dice, List<int> savedDice)
    {
        Console.WriteLine("Rolled Dice: " + string.Join(" ", dice));
        Console.WriteLine("Saved Dice: " + string.Join(" ", savedDice));
    }

    static void SaveDice(int[] dice, List<int> savedDice, int[] positions)
    {
        foreach (int pos in positions)
        {
            if (pos >= 1 && pos <= dice.Length)
            {
                int diceValue = dice[pos - 1];
                savedDice.Add(diceValue);
            }
        }
    }

    static int[] RollDice(int numDice = 5)
    {
        Random rand = new Random();
        int[] dice = new int[numDice];
        for (int i = 0; i < numDice; i++)
        {
            dice[i] = rand.Next(1, 7);
        }
        return dice;
    }

    static int CalculateScore(int[] savedDice, int[] dice, string category)
    {
       
        return new Random().Next(1, 50); 
    }

    static void DisplayScoreboard(List<Player> players)
    {
        Console.WriteLine("\n-- Scoreboard --");
        foreach (var player in players)
        {
            Console.WriteLine($"{player.Name}: {player.GetTotalScore()} points");
            foreach (var category in Categories)
            {
                string score = player.Scoreboard.ContainsKey(category) && player.Scoreboard[category] >= 0 
                               ? player.Scoreboard[category].ToString() 
                               : "-";
                Console.WriteLine($"  {category}: {score}");
            }
        }
    }

    static void DisplayAvailableCategories(Player player)
    {
        foreach (var category in Categories)
        {
            if (!player.Scoreboard.ContainsKey(category) || player.Scoreboard[category] == -1)
            {
                Console.WriteLine($"- {category}");
            }
        }
    }
}

class Player
{
    public string Name { get; set; }
    public Dictionary<string, int> Scoreboard { get; private set; }

    public Player(IEnumerable<string> categories)
    {
        Scoreboard = new Dictionary<string, int>();
        foreach (var category in categories)
        {
            Scoreboard[category] = -1; // -1 indicates unused category
        }
    }

    public void AddScore(string category, int score)
    {
        if (Scoreboard.ContainsKey(category))
            Scoreboard[category] = score;
    }

    public int GetTotalScore()
    {
        int total = 0;
        foreach (var score in Scoreboard.Values)
        {
            if (score >= 0) total += score;
        }
        return total;
    }
}

