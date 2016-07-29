using UnityEngine;
using System.Collections;


public class InterfaceControl : MonoBehaviour {
    private int dsize = 40;
    //database
    private Database db;

    //array of cards 
    Deck deck;

    public GameObject prefab;


	// Use this for initialization
	void Start () {
        db = new Database("cards.db", "SELECT * FROM cards WHERE id < 42");
        Card[] cards = db.getCards();
        cards = CreateGameObjects(cards);

        deck = new Deck(cards, dsize);


    }

    //Gera um prefab para cada carta, e muda sua textura para cada id
    Card[] CreateGameObjects(Card[] cards) {

        for (int i = 0; i < dsize; i++) {
            //posiciona carta
            GameObject go = (GameObject)Instantiate(prefab, new Vector3(69, 5.01f + i * 0.05f, -15.5f), new Quaternion(0, 180, 0, 0));
            cards[i].setGO(go);
        }
        return cards;
    }

    


}
