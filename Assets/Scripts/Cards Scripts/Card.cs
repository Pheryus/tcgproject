using UnityEngine;
using System.Collections;

public class Effect {

    public ArrayList actions;
    public ArrayList fastactions;
    public ArrayList continuous;
    public ArrayList fast;
    public ArrayList trigger;

    public Effect() {
        actions = new ArrayList();
        fastactions = new ArrayList();
        continuous = new ArrayList();
        fast = new ArrayList();
        trigger = new ArrayList();
    }

};


public class Card {

 
    private int id;
    private int? armor, time, power;
    public string name, type, color, text, cost, cost2;
    
    //actual status
    private int actpow, acttime, actarmor;

    public Effect eff;

    //construct
    public Card (int id, string cost, int? armor, int? time, int? power, string name, string type, string color, string text) {
        this.id = id;
        this.cost = cost;
        this.time = time;
        acttime = this.time.GetValueOrDefault();
        actpow = this.power.GetValueOrDefault();
        actarmor = this.armor.GetValueOrDefault();
        this.name = name;
        this.type = type;
        this.color = color;
        this.text = text;

        //getting effects
        eff = CardEffects.getEffect(id, type);
     
    }
	
    public int getID(){
        return id;
    }

}
