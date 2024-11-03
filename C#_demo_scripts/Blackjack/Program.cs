using System;
using System.Collections.Generic;

class Card
{
    public string Suit { get; set; }
    public string Value { get; set; }
    public int GetCardValue()
    {
        return Value switch
        {
            "Ace" => 11,
            "2" => 2,
            "3" => 3,
            "4" => 4,
            "5" => 5,
            "6" => 6,
            "7" => 7,
            "8" => 8,
            "9" => 9,
            "10" => 10,
            "Jack" => 10,
            "Queen" => 10,
            "King" => 10,
            _ => 0
        };
    }
}

class Deck
{
    private List<Card> cards = new List<Card>();
    private Random random = new Random();

    public Deck()
    {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] values = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        foreach (var suit in suits)
        {
            foreach (var value in values)
            {
                cards.Add(new Card { Suit = suit, Value = value });
            }
        }
    }

    public void Shuffle()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (cards[i], cards[j]) = (cards[j], cards[i]);
        }
    }

    public Card DrawCard()
    {
        if (cards.Count == 0) return null;
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}

class Hand
{
    public List<Card> Cards { get; private set; } = new List<Card>();
    
    public void AddCard(Card card)
    {
        Cards.Add(card);
    }

    public int CalculateScore()
    {
        int score = 0;
        int aceCount = 0;
        foreach (var card in Cards)
        {
            score += card.GetCardValue();
            if (card.Value == "Ace") aceCount++;
        }
        while (score > 21 && aceCount > 0)
        {
            score -= 10;
            aceCount--;
        }
        return score;
    }
}

class BlackjackGame
{
    private Deck deck;
    private Hand playerHand;
    private Hand dealerHand;

    public BlackjackGame()
    {
        deck = new Deck();
        deck.Shuffle();
        playerHand = new Hand();
        dealerHand = new Hand();
    }

    public void StartGame()
    {
        playerHand.AddCard(deck.DrawCard());
        playerHand.AddCard(deck.DrawCard());
        dealerHand.AddCard(deck.DrawCard());
        dealerHand.AddCard(deck.DrawCard());

        Console.WriteLine("Welcome to Blackjack!");
        PlayerTurn();
        DealerTurn();
        DetermineWinner();
    }

    private void PlayerTurn()
    {
        while (true)
        {
            Console.WriteLine($"Your hand: {DisplayHand(playerHand)}, Score: {playerHand.CalculateScore()}");
            if (playerHand.CalculateScore() > 21)
            {
                Console.WriteLine("Bust! You lose.");
                return;
            }

            Console.Write("Do you want to (H)it or (S)tand? ");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "H")
            {
                playerHand.AddCard(deck.DrawCard());
            }
            else if (choice == "S")
            {
                break;
            }
        }
    }

    private void DealerTurn()
    {
        Console.WriteLine($"Dealer's hand: {DisplayHand(dealerHand)}, Score: {dealerHand.CalculateScore()}");

        while (dealerHand.CalculateScore() < 17)
        {
            Console.WriteLine("Dealer hits.");
            dealerHand.AddCard(deck.DrawCard());
            Console.WriteLine($"Dealer's hand: {DisplayHand(dealerHand)}, Score: {dealerHand.CalculateScore()}");
        }
        if (dealerHand.CalculateScore() > 21)
        {
            Console.WriteLine("Dealer busts! You win.");
        }
    }

    private void DetermineWinner()
    {
        int playerScore = playerHand.CalculateScore();
        int dealerScore = dealerHand.CalculateScore();

        if (playerScore > 21)
        {
            Console.WriteLine("You busted. Dealer wins.");
        }
        else if (dealerScore > 21)
        {
            Console.WriteLine("Dealer busted. You win!");
        }
        else if (playerScore > dealerScore)
        {
            Console.WriteLine("You win!");
        }
        else if (playerScore < dealerScore)
        {
            Console.WriteLine("Dealer wins.");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }

    private string DisplayHand(Hand hand)
    {
        return string.Join(", ", hand.Cards.Select(card => $"{card.Value} of {card.Suit}"));
    }
}

class Program
{
    static void Main(string[] args)
    {
        BlackjackGame game = new BlackjackGame();
        game.StartGame();
    }
}
