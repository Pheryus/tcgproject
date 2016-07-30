using UnityEngine;
using System.Collections;

public class Hand {

    private int max_cards = 10;
    public  ArrayList hand_cards = new ArrayList();

    //construtor
    public Hand(Card[] cards){
        foreach (Card c in cards)
            draw_card(c);
    }
   
    //adding card to hand
    public void draw_card(Card card){
        card.setOnHand(true);
        hand_cards.Add(card);
    }
    
    public GameObject getGOInHand(int n) {
        Card card = (Card)hand_cards[n];
        return card.getGO();
    }

    public void setPositionInHand(int n, Transform transform) {
        Card card = (Card)hand_cards[n];
        card.setPosition(transform.position);
    }

}
