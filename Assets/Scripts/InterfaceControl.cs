using UnityEngine;
using System.Collections;


public class InterfaceControl : MonoBehaviour {
    private int dsize = 40;
    //database
    private Database db;

    private float speed = 1;
    //array of cards 
    Deck deck;

    public GameObject prefab;

    //hand of player
    Hand hand;
    //position of the cards in hand
    GameObject hand_position;

	// Use this for initialization
	void Start () {
        db = new Database("cards.db", "SELECT * FROM cards WHERE id < 42");
        
        Card[] cards = db.getCards();
        cards = CreateGameObjects(cards);
        deck = new Deck(cards, dsize);
        setHandPosition();
        addHandCards();
        StartCoroutine(callHandCoroutine());
    }

    void setHandPosition() {
        hand_position = new GameObject();
        hand_position.transform.position = new Vector3(20, 25, -5);
    }

    //Gera um prefab para cada carta, e muda sua textura para cada id
    Card[] CreateGameObjects(Card[] cards) {
        for (int i = 0; i < dsize; i++) {
            //posiciona carta
            GameObject go = (GameObject)Instantiate(prefab, new Vector3(69, 5.01f + i * 0.05f, -15.5f), new Quaternion(0, 0, 0, 0));
            cards[i].setGO(go);
        }
        return cards;
    }

    void addHandCards() {
        Card[] hand_cards = deck.drawCards(1);
        hand = new Hand(hand_cards);
        
    }

    IEnumerator callHandCoroutine() {
        Debug.Log(hand.hand_cards.Count);
        for (int i = 0; i < hand.hand_cards.Count; i++) {
            yield return StartCoroutine(animationCardtoHand(0.5f));
            print("teste\n");
        }
    }

    IEnumerator animationCardtoHand(float time) {

        float rate = 1 / time;

        Vector3 startPos = deck.getTopCardPosition();
        for (float t = 0f; t < 1f; t += rate*Time.deltaTime) {
            //load go from the hand
            GameObject go = hand.getGOInHand(hand.hand_cards.Count - 1);
            //translate 
            go.transform.position = Vector3.Lerp(startPos, hand_position.transform.position, t);
            //rotate the card after the middle of the distance
            if (t > 0.5f)
                go.transform.Rotate(Vector3.back * Time.deltaTime*rate*360);
            hand.setPositionInHand(hand.hand_cards.Count - 1, go.transform);
            yield return null;
        }
    }

    void Update() {

        if (Input.GetKey(KeyCode.Backspace)) {
            Card[] c = deck.drawCards(1);
            c[0].setOnHand(true);
            hand.draw_card(c[0]);
        }
    }



}
