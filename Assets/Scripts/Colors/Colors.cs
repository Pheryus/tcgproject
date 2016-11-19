using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;


public class Colors {
    

    public int red, green, blue, yellow, purple;
    public int temp_red, temp_green, temp_blue, temp_yellow, temp_purple;
    public int max_red, max_green, max_blue, max_yellow, max_purple;

    public int rcount = 0, bcount = 0, gcount = 0, pcount = 0, ycount = 0;

    CostChoice cost_choices;
    Vector3 whereWas;
    Pallete pallete;
    ManaControl manacontrol;
    GameObject text;


    public Colors() {
        pallete = new Pallete();
        FillColors();
    }


    public int GetIncolorCostFromCard(string mana) {
        string resultString = Regex.Match(mana, @"\d+").Value;
        return Int32.Parse(resultString);
    }

    public bool CheckOnlyOneColorDisponible(int mana) {
        if (blue >= mana && red + green + purple + yellow == 0) {
            blue -= mana;
            return true;
        }
        else if (red >= mana && blue + green + purple + yellow == 0) {
            red -= mana;
            return true;
        }
        else if (green >= mana && blue + red + purple + yellow == 0) {
            green -= mana;
            return true;
        }
        else if (yellow >= mana && blue + red + purple + green == 0) {
            yellow -= mana;
            return true;
        }
        else if (purple >= mana && blue + red + green + yellow == 0) {
            purple -= mana;
            return true;
        }
        return false;
    }

    public int CheckIfItsPlayable(Card c) { 
        int incolor = GetIncolorCostFromCard(c.cost2);
        if (CheckIfHaveMana(c.cost2, incolor) >= 0)
            return 0;
        return -1;
    }
    
    public int SpendMana(GameObject go) {
        Card c = go.GetComponent<CardInstance>().card;
        int incolor = GetIncolorCostFromCard(c.cost2);
        red -= rcount; blue -= bcount; green -= gcount; yellow -= ycount; purple -= pcount;
        int yourtotalmana = red + green + blue + yellow + purple;
        rcount = 0; bcount = 0; gcount = 0; ycount = 0; pcount = 0;
        if (CheckOnlyOneColorDisponible(incolor)) {
            return 0;
        }
        else
            return incolor;
    }

    public void ResetManaCount() {
        rcount = bcount = gcount = ycount = pcount = 0;
    }

    public int CheckIfHaveMana(string mana, int incolor) {
        foreach (char o in mana) {
            if (o == 'r') rcount++;
            if (o == 'b') bcount++;
            if (o == 'g') gcount++;
            if (o == 'y') ycount++;
            if (o == 'p') pcount++;
        }

        int yourtotalmana = red + green + blue + yellow + purple;
        //temp_red -= rcount; temp_blue -= bcount; temp_green -= gcount; temp_yellow -= ycount; temp_purple -= pcount;
        if (red >= rcount && blue >= bcount && green >= gcount && yellow >= ycount && purple >= pcount) {
            yourtotalmana -= rcount + gcount + bcount + ycount + pcount;
            return yourtotalmana - incolor;
        }

        return -1;
    }


    public bool ChooseColor() {
        if (pallete.TestEmptyPallete()) {
            pallete.ModifyingPallete();
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
        if (name == "r") 
            t.text = max_red.ToString();
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
        temp_red = red;
        green = max_green;
        temp_green = green;
        blue = max_blue;
        temp_blue = max_blue;
        yellow = max_yellow;
        temp_yellow = max_yellow;
        purple = max_purple;
        temp_purple = max_purple;
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
            g.GetComponent<ClickColor>().color = pallete.color_pallete[i];

            switch (pallete.color_pallete[i]) {
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

    public void EndColorPhase() {
        pallete.RestartPallete();
        DestroyImage();
        RefreshColors();
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
