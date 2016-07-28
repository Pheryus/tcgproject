using UnityEngine;
using System.Collections;

public class Hand {

    private int max_cards = 10;
    private ArrayList hand_cards;

    //construtor
    public Hand(Card[] cards){
        foreach (Card c in cards)
            hand_cards.Add(c);
    }
   
    //adding card to hand
    void draw_card(Card card){
        card.setOnHand(true);
        hand_cards.Add(card);
    }


}
