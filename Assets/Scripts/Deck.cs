using UnityEngine;
using System.Collections;

public class Deck {
    const int size = 40;
    ArrayList deck = new ArrayList();
    Random r = new Random();

	//construtor
	public Deck (Card[] cards) {
        createDeck(cards);
        printDeck();
        shuffleDeck();
        printDeck();
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
