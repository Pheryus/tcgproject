using UnityEngine;
using System.Collections;


public class Control : MonoBehaviour {
    private int dsize = 40;
    //database
    private Database db;
    //array of cards 
    Deck deck;

    public Hand referencetoHand;
    public Turn turn;
    public Colors color;


    public ShowMessages message;

    public string turnControl = "";
    
	
	void Start () {
       
        db = new Database("green_cards.db", "SELECT * FROM cards WHERE id < 42");
        Card[] cards = db.getCards();
        deck = new Deck(cards, dsize);
        Card[] draw = deck.drawCards(5);
        referencetoHand = GameObject.FindObjectOfType(typeof(Hand)) as Hand;
        for (int i = 0; i < 5; i++)
            referencetoHand.draw_card(draw[i]);
        
        message = new ShowMessages();
        color = new Colors(this, message);
        Turn();
    }

    public void Turn() {
        turnControl = "color";
        if (!color.ChooseColor()) {
            EndColorPhase();
        }
    }

    public void DrawPhase() {
        turnControl = "draw";
        Card[] card = deck.drawCards(1);
        referencetoHand.draw_card(card[0]);
        turnControl = "play";
    }

    public void EndColorPhase() {
        color.EndColorPhase();
        DrawPhase();
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

   

}


