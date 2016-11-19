using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour{
   
    private const int max_cards = 10;
    public  ArrayList hand_cards = new ArrayList();
    public ArrayList canplayHandCards = new ArrayList();
    public GameObject prefab;

    //adding card to hand
    public void draw_card(Card card){

        GameObject go =  (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
        go.GetComponent<CardInstance>().setCard(card);
        go.GetComponent<CardInstance>().setImage(this.gameObject.transform);
        hand_cards.Add(go);
        canplayHandCards.Add(false);
    }
    
    public string CheckIfCanPlay(int id) {
        //hand_cards[id];
        return "";
    }
    
}
