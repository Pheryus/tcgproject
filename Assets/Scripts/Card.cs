using UnityEngine;
using System.Collections;

public class Card {

    private int id, cost;
    private int? armor, load, time, power;
    private string name, type, color, text;
    private GameObject go;
    private bool on_hand, on_play, on_grave;
    private Renderer renderer;

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

    public void setRenderer() {
        renderer = go.GetComponent<Renderer>();
        renderer.material.mainTexture = (Texture)Resources.Load("Cards/" + id.ToString());
    }

    public void setGO(GameObject g){
        go = g;
        setRenderer();
    }

    public GameObject getGO() {
        return go;
    }

    public void printCard(){
        Debug.Log(id +  name + text);
    }

    public void setOnHand(bool v){
        on_hand = v;
    }

    public void translateCard(int id) {
        go.transform.Translate(Vector3.up * 0.05f * id);
    }


}
