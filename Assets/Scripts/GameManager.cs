using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card> deck = new List<Card>();
    public List<Card> player_deck = new List<Card>();
    public List<Card> ai_deck = new List<Card>();
    public List<Card> player_hand = new List<Card>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card> discard_pile = new List<Card>();

    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeDeck();
        Shuffle();
        Deal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeDeck()
    {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        foreach (string suit in suits)
        {
            foreach (string value in values)
            {
                deck.Add(new Card(value, suit));
            }
        }
    }

    void Shuffle()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(0, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    void Deal()
    {
        player_hand.Add(deck[0]);
        deck.RemoveAt(0);
        ai_hand.Add(deck[0]);
        deck.RemoveAt(0);
        player_hand.Add(deck[0]);
        deck.RemoveAt(0);
        ai_hand.Add(deck[0]);
        deck.RemoveAt(0);
    }

    int CalculateHandValue(List<Card> hand)
    {
        int value = 0;
        int aceCount = 0;

        foreach (Card card in hand)
        {
            if (card.value == "J" || card.value == "Q" || card.value == "K")
            {
                value += 10;
            }
            else if (card.value == "A")
            {
                aceCount++;
                value += 11;
            }
            else
            {
                value += int.Parse(card.value);
            }
        }

        while (value > 21 && aceCount > 0)
        {
            value -= 10;
            aceCount--;
        }

        return value;
    }

    void DetermineWinner()
    {
        int playerValue = CalculateHandValue(player_hand);
        int aiValue = CalculateHandValue(ai_hand);

        if (playerValue > 21)
        {
            Debug.Log("Player busts! AI wins.");
        }
        else if (aiValue > 21)
        {
            Debug.Log("AI busts! Player wins.");
        }
        else if (playerValue > aiValue)
        {
            Debug.Log("Player wins!");
        }
        else if (aiValue > playerValue)
        {
            Debug.Log("AI wins!");
        }
        else
        {
            Debug.Log("It's a tie!");
        }
    }
}

public class Card
{
    public string value;
    public string suit;

    public Card(string value, string suit)
    {
        this.value = value;
        this.suit = suit;
    }
}
