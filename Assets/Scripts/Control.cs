using UnityEngine;
using System.Collections;


public class Control : MonoBehaviour{
    private int dsize = 40;
    //database
    private Database db;
    //array of cards 
    Deck deck;

    public Hand referencetoHand;

    public Colors color;

    public string turnControl = "";
    
	// Use this for initialization
	void Start () {
        db = new Database("cards.db", "SELECT * FROM cards WHERE id < 42");
        Card[] cards = db.getCards();
        deck = new Deck(cards, dsize);
        Card[] draw = deck.drawCards(5);
        referencetoHand = GameObject.FindObjectOfType(typeof(Hand)) as Hand;
        for (int i=0; i<5;i++)
            referencetoHand.draw_card(draw[i]);
        color = new Colors();
        Turn();

    }

    public void Turn() {
        turnControl = "color";
        color.ChooseColor();

    }

   
    public void DrawPhase() {
        turnControl = "draw";
        Card[] card = deck.drawCards(1);
        referencetoHand.draw_card(card[0]);

    }

    public void EndColorPhase() {
        turnControl = "play";
        color.EndColorPhase();
    }


    public void EndPhase() {
        turnControl = "end";
        Process();
        Turn();
    }

    IEnumerator Process() {
        yield return StartCoroutine(WaitTurn(5.0f));
    }

    IEnumerator WaitTurn(float duration) {
        yield return new WaitForSeconds(duration);
    }

    /*
    //Gera um prefab para cada carta, e muda sua textura para cada id
    Card[] CreateGameObjects(Card[] cards) {
        //Quaternion rotate = new Quaternion(0, -90, 90, 0);
        for (int i = 0; i < dsize; i++) {
            //posiciona carta
            //Vector3 deck_position = deck.deckposition(i);
            Debug.Log("Criando carta\n");
            //Vector3 aux = new Vector3()
            GameObject go = (GameObject)Instantiate(prefab, new Vector3(3.3f, 0.21f + i*0.05f, -4.42f), Quaternion.identity);
            go.name = i.ToString();
            cards[i].setGO(go);
        }
        return cards;
    }

    void addCardstoHand(int n) {
        Card[] cards = deck.drawCards(n);

        StartCoroutine(callHandCoroutine(cards, n));
    }
    
    IEnumerator callHandCoroutine(Card[] cards, int n) {
        for (int i = 0; i < n; i++) {
            hand.draw_card(cards[i]);
            int size = hand.hand_cards.Count - 1;
            yield return StartCoroutine(animationCardtoHand(1f, size));
        }
       
    }

    IEnumerator animationCardtoHand(float time, int i) {

        float rate = 1 / time;

        Vector3 startPos = deck.getTopCardPosition();
        for (float t = 0f; t < 1f; t += rate*Time.deltaTime) {
            //load go from the hand
            GameObject go = hand.getGOInHand(i);
            //translate 
            go.transform.position = Vector3.Lerp(startPos, hand.getHandPosition().position, t);
            //rotate the card after the middle of the distance
            if (t > 0.5f)
                go.transform.Rotate(Vector3.back * Time.deltaTime*rate*360);
            hand.setPositionInHand(i, go.transform);
            yield return null;
        }
        //hand.changeHandPosition(new Vector3(7, 0, 0));

    }
    */


}


