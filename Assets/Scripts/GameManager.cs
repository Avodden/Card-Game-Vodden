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
    public List<Card> player_field = new List<Card>();
    public List<Card> ai_field = new List<Card>();
    public int player_health;
    public int ai_health;
    public int player_ammo;
    public int ai_ammo;
    public int player_max_ammo;
    public int ai_max_ammo;
    public int player_turns;
    public int ai_turns;
    public bool player_turn;
    public bool ai_turn;

    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        player_health = 30;
        ai_health = 30;
        player_ammo = 0;
        ai_ammo = 0;
        player_max_ammo = 0;
        ai_max_ammo = 0;
        player_turns = 0;
        ai_turns = 0;
        player_turn = true;
        ai_turn = false;

        for (int i = 0; i < deck.Count; i++)
        {
            if (deck[i].data.player)
            {
                player_deck.Add(deck[i]);
            }
            else
            {
                ai_deck.Add(deck[i]);
            }
        }
    }
}
