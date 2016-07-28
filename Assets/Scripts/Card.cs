using UnityEngine;
using System.Collections;

public class Card {

    private int id, cost;
    private int? armor, load, time, power;
    private string name, type, color, text;
    
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
    }
	
    public int getID(){
        return id;
    }
}
