using UnityEngine;
using System.Collections;

public class Deck {
    int size;
    public ArrayList deck = new ArrayList();
    Random r = new Random();

	//construtor
	public Deck (Card[] cards, int siz) {
        size = siz;
        createDeck(cards);
        shuffleDeck();
	}
	
    void createDeck(Card[] cards){
        foreach(Card c in cards)
            deck.Add(c);
    }

    void shuffleDeck(){
        for (int i = deck.Count - 1; i > 0; i--){
            int n = Random.Range(0, i + 1);
            Swap(i, n);
        }
        updateDeck();
    }

    //função para modificar a posição de cada carta (chamar sempre que o deck for embaralhado)
    void updateDeck() {
        for (int i = 0; i < deck.Count;i++) {
            Card card = (Card)deck[i];
            card.translateCard(i);
        }
    }

    Card drawCard(){
        Card card = (Card)deck[deck.Count - 1];
        deck.RemoveAt(deck.Count -1);
        return card;
    }

    void Swap(int i, int n)
    {
        Card aux = (Card) deck[i];
        deck[i] = deck[n];
        deck[n] = aux;
    }

    void printDeck(){
        for (int i = 0; i < deck.Count; i++){
            Card card = (Card) deck[i];
            card.printCard();
        }
    }



}
