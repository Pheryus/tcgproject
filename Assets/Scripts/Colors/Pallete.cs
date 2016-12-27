using UnityEngine;
using System.Collections;

public class Pallete {

    public Transform pos; //The pallete's position
    public string color_pallete; //The pallete's color
    Vector3 whereWas; //The pallete's position

    //Create the pallete
    public Pallete(string color_pallete = "rrggb") { 
        this.color_pallete = color_pallete;
    }

    //Restart the pallete's position  
    public void RestartPallete() {
        GameObject go = GameObject.Find("Pallete");
        go.transform.position = whereWas;
    }

    //Return true if the Pallete doesn't have colors
    public bool TestEmptyPallete() {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Color");
        bool empty = false;
        foreach (GameObject g in go) {
            if (g.GetComponent<ClickColor>().color != 'e') {
                empty = true;
                break;
            }
        }
        return empty;
    }

    //Move pallete's position to targetpallete's position
    public void ModifyingPallete() {
        GameObject go = GameObject.Find("Pallete");
        whereWas = go.transform.position;
        Transform whereGo = GameObject.Find("targetPallete").transform;
        go.transform.position = whereGo.position;
    }
}

