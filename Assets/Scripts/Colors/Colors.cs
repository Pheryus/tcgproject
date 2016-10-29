using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;


public class Colors {

    public int red, green, blue, yellow, purple;
    public int max_red, max_green, max_blue, max_yellow, max_purple;

    public Transform pos;

    public string color_pallete;

    Vector3 whereWas;

    GameObject text;

    public Colors(string color_pallete="rrggb") {

        this.color_pallete = color_pallete;
        FillColors();

    }

    public bool CheckIfItsPlayable(GameObject go) {
        Card c = go.GetComponent<CardInstance>().card;
        if (CheckIfHaveMana(c.cost2))
            return true;
        return false;
    }

    public bool CheckIfHaveMana(string mana, string additional_mana="") {

        string resultString = Regex.Match(mana, @"\d+").Value;
        int incolor = Int32.Parse(resultString);
        int rcount = 0,  bcount = 0, gcount = 0, pcount = 0, ycount = 0;
        foreach (char c in mana) {
            if (c == 'r') rcount++;
            if (c == 'b') bcount++;
            if (c == 'g') gcount++;
            if (c == 'y') ycount++;
            if (c == 'p') pcount++;
        }

        int yourtotalmana = red + green + blue + yellow + purple;
        
        if (rcount <= red && bcount <= blue && gcount <= green && ycount <= yellow && pcount <= purple) {
            yourtotalmana -= rcount + bcount + gcount + ycount + pcount;
            if (yourtotalmana >= incolor)
                return true;
        }
        

        return false;
    }


    public bool ChooseColor() {
        if (TestEmptyPallete()) {
            ModifyingPallete();
            InstantiateImage();
            return true;
        }
        else {
            FillColors();
            return false;
        }
                
    }

    public void AddColor(char c) {

        switch (c) {
            case 'r':
                max_red++;
                break;
            case 'g':
                max_green++;
                break;
            case 'b':
                max_blue++;
                break;
            case 'y':
                max_yellow++;
                break;
            case 'p':
                max_purple++;
                break;
        }
        IncreaseMaxColorImage(c);
    }

    public int getMaxColor(char c) {
        if (c == 'r')
            return max_red;
        else if (c == 'g')
            return max_green;
        else if (c == 'b')
            return max_blue;
        else if (c == 'y')
            return max_yellow;
        else if (c == 'p')
            return max_purple;
        return 0;
    }

    public void setMaxColor(char c, int i) {
        if (c == 'r') { 
            max_red = i;
        }
        else if (c == 'g')
            max_green = i;
        else if (c == 'b')
            max_blue = i;
        else if (c == 'y')
            max_yellow = i;
        else if (c == 'p')
            max_purple = i;
    }

    public void IncreaseMaxColorImage(char c) {
        GameObject[] go = GameObject.FindGameObjectsWithTag("IdentifierColor");

        foreach (GameObject g in go) {
            if (g.name == c.ToString()) {
                int i = getMaxColor(c);
                Text t = g.transform.GetChild(2).GetComponent<Text>();
                Int32.TryParse(t.text, out i);
                i++;
                t.text = i.ToString();
                setMaxColor(c, i); 
                break;
            }
        }
    }

    public void RefreshTextColors(string name, Text t) {
        if (name == "r") {
            t.text = max_red.ToString();
        }
        else if (name == "g")
            t.text = max_green.ToString();
        else if (name == "b")
            t.text = max_blue.ToString();
        else if (name == "p")
            t.text = max_purple.ToString();
        else if (name == "y")
            t.text = max_yellow.ToString();
    }

    public void RefreshVariableColors() {
        red = max_red;
        green = max_green;
        blue = max_blue;
        yellow = max_yellow;
        purple = max_purple;
    }

    public void RefreshColors() {
        GameObject[] go = GameObject.FindGameObjectsWithTag("IdentifierColor");
        foreach (GameObject g in go) {
            Text t = g.transform.GetChild(0).GetComponent<Text>();
            RefreshTextColors(g.name, t);
        }
        RefreshVariableColors();
    }

    public void FillColors() {

        GameObject[] go = GameObject.FindGameObjectsWithTag("Color");
        int i = 0;
        Color aux = Color.gray;

        foreach (GameObject g in go) {
            g.GetComponent<ClickColor>().color = color_pallete[i];

            switch (color_pallete[i]) {
                case 'r':
                    aux = Color.red;
                    break;
                case 'g':
                    aux = Color.green;
                    break;
                case 'b':
                    aux = Color.blue;
                    break;
                case 'y':
                    aux = Color.yellow;
                    break;
            }

            g.GetComponent<Renderer>().material.color = aux;
            i++;
        }

    }

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

    public void EndColorPhase() {
        ReturnPallete();
        DestroyImage();
        RefreshColors();
    }
    
    public void ModifyingPallete() {
        GameObject go = GameObject.Find("Pallete");
        whereWas = go.transform.position;
        Transform whereGo = GameObject.Find("targetPallete").transform;
        go.transform.position = whereGo.position;
    }

    public void ReturnPallete() {
        GameObject go = GameObject.Find("Pallete");
        go.transform.position = whereWas;   
    }

    public void DestroyImage() {
        UnityEngine.Object.Destroy(text);
    }

    public void InstantiateImage() {
        text = (GameObject)GameObject.Instantiate(Resources.Load("Image1Prefab"));
        
        text.transform.parent = GameObject.Find("Canvas").transform;
        text.transform.localPosition = new Vector3(0, -30f, -270);
    }

}
