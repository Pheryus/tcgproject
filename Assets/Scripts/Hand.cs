using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour{
   
    private const int max_cards = 10;
    public  ArrayList hand_cards = new ArrayList();
    public GameObject prefab;
    //adding card to hand
    public void draw_card(Card card){
        card.setGO(prefab);
        card.setImage(this.transform);
        hand_cards.Add(card);
    }
    


}
