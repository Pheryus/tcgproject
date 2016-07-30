using UnityEngine;
using System.Collections;

public class Deck {
    int size;
    public ArrayList deck = new ArrayList();
    int num_cards;
    Random r = new Random();

	//construtor
	public Deck (Card[] cards, int siz) {
        size = siz;
        num_cards = size;
        createDeck(cards);
        shuffleDeck();
	}
	
    void createDeck(Card[] cards){
        foreach(Card c in cards)
            deck.Add(c);
    }

    void shuffleDeck(){
        for (int i = num_cards - 1; i > 0; i--){
            int n = Random.Range(0, i + 1);
            Swap(i, n);
        }
        updateDeck();
    }

    //função para modificar a posição de cada carta (chamar sempre que o deck for embaralhado)
    void updateDeck() {
        for (int i = 0; i < num_cards - 1; i++) {
            Card card = (Card)deck[i];
            card.translateCardInDeck(i);
        }
    }

    public Card[] drawCards(int num){
        Card[] cards = new Card[num];
        for (int i = 0; i < num; i++) {
            cards[i] = getTopCard();
            deck.RemoveAt(num_cards - 1);
            num_cards--;
        }
        return cards;
    }

    void Swap(int i, int n)
    {
        Card aux = (Card) deck[i];
        deck[i] = deck[n];
        deck[n] = aux;
    }

    void printDeck(){
        for (int i = 0; i < num_cards - 1; i++){
            Card card = (Card) deck[i];
            card.printCard();
        }
    }

    Card getTopCard() {
        return (Card)deck[num_cards - 1];
    }

    public Vector3 getTopCardPosition() {
        Card card = getTopCard();
        return card.getGO().transform.position;
    }

}
