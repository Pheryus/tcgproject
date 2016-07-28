using UnityEngine;
using System.Collections;

public class Card {

    private int id, cost;
    private int? armor, load, time, power;
    private string name, type, color, text;
    private GameObject go;
    private bool on_hand, on_play, on_grave;
    //construct
    public Card (int id, int cost, int? armor, int? load, int? time, int? power, string name, string type, string color, string text) {
        this.id = id;
        this.cost = cost;
        this.armor = armor;
        this.load = load;
        this.time = time;
        this.power = power;
        this.name = name;
        this.type = type;
        this.color = color;
        this.text = text;
        on_grave = on_play = on_hand = false;
    }
	
    public int getID(){
        return id;
    }

    public void setGO(GameObject g){
        go = g;
    }

    public void printCard(){
        Debug.Log(id +  name + text);
    }

    public void setOnHand(bool v){
        on_hand = v;
    }
}
