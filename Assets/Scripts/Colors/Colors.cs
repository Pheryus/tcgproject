using UnityEngine;
using System.Collections;
using System;

public class Colors {

    public int red, green, blue, yellow, purple;
    public int max_red, max_green, max_blue, max_yellow, max_purple;

    public string color_pallete;

    public Transform pos;

    public Colors(string color_pallete="rrrggn") {
        this.color_pallete = color_pallete;

    }
    
    public void ChooseColor() {
        ModifyingPallete();
        InstantiateImage();
        
    }
    
    public void ModifyingPallete() {
        GameObject go = GameObject.Find("Pallete");
        pos = go.transform;
        Transform whereGo = GameObject.Find("targetPallete").transform;
        go.transform.position = whereGo.position;
    }


    public void InstantiateImage() {
        GameObject text = (GameObject)GameObject.Instantiate(Resources.Load("Image1Prefab"));
        
        text.transform.parent = GameObject.Find("Canvas").transform;
        text.transform.localPosition = new Vector3(0, -30f, -270);
    }


}
