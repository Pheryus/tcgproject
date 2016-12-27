using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Linq;

public class Colors {
    //cores atuais
    private Dictionary<string, int> colors;

    //cores já gastas
    private Dictionary<string, int> spent_colors;

    //limite de cores atual
    private Dictionary<string, int> max_colors;

    //cores a serem gastas
    private Dictionary<string, int> aux_colors;

    //define cor de verdade mesmo (com siglas r,g,b,y,p)
    private Dictionary<string, Color> real_color;

    Pallete pallete;

    public string zonePlayed;

    public Images images;

    public Control controlreference;
    public ShowMessages message;

    public Colors(Control control, ShowMessages message) {
        controlreference = control;
        this.message = message;
        InitializingDictionaries();
        pallete = new Pallete();
        images = new Images();
        FillColors();
    }

    public int GetActualColors(string key) {
        return colors[key];
    }

    public int GetMaxColors(string key) {
        return max_colors[key];
    }

    public int GetSpentColors(string key) {
        return spent_colors[key];
    }


    public void ChangeSpentColor(string key, int x) {
        spent_colors[key] += x;
    }

    private void InitializingDictionaries() {
        colors = new Dictionary<string, int>();
        max_colors = new Dictionary<string, int>();
        real_color = new Dictionary<string, Color>();
        spent_colors = new Dictionary<string, int>();
        aux_colors = new Dictionary<string, int>();
        foreach (char c in "rgbyp") {
            colors.Add(c.ToString(), 0);
            max_colors.Add(c.ToString(), 0);
            spent_colors.Add(c.ToString(), 0);
            aux_colors.Add(c.ToString(), 0);
        }
        real_color.Add("r", Color.red);
        real_color.Add("g", Color.green);
        real_color.Add("b", Color.blue);
        real_color.Add("y", Color.yellow);
        real_color.Add("p", Color.magenta);
    }

    public int GetIncolorCostFromCard(string mana) {
        string resultString = Regex.Match(mana, @"\d+").Value;
        if (resultString == "") 
            return 0;
        return Int32.Parse(resultString);
    }

    public int CheckOnlyOneColorDisponible(int mana) {
        foreach (KeyValuePair<string, int> color in colors) {
            if (color.Value >= mana && colors.Sum(x => x.Value) - color.Value == 0) {
                colors[color.Key] -= mana;
                return 0;
            }
        }
        return mana;
    }
    


    public void SpendMana() {
        foreach (string key in colors.Keys.ToList()) {
            aux_colors[key] = colors[key];
            colors[key] -= spent_colors[key];
            spent_colors[key] =  0;
        }
    }


    //Controle de mana quando a carta é jogada. retorna 0 se nao existe opção de escolha. 
    //Retorna o numero de mana faltando, caso tenha mais de uma opção. 
    public int CardPlayed(Card c) {
        SpendMana();
        return CheckOnlyOneColorDisponible(GetIncolorCostFromCard(c.cost));
    }

    public bool CheckIfItsPlayable(Card c) {
        return CheckIfHaveMana(c.cost, GetIncolorCostFromCard(c.cost));
    }

    public void ResetManaCount() {
        foreach (string key in spent_colors.Keys.ToList())
            spent_colors[key] = 0;
    }

    public void ReturnOriginalMana() {
        foreach (string key in colors.Keys.ToList()) {
            colors[key] = aux_colors[key];
            Debug.Log(colors[key]);
            aux_colors[key] = 0;
        }
    }

    public bool CheckIfHaveMana(string mana, int incolor) {

        foreach (char o in mana)
            if (spent_colors.ContainsKey(o.ToString().ToLower()))
                spent_colors[o.ToString().ToLower()]++;

        int yourtotalmana = colors.Sum(x => x.Value);
                
        if (colors.All(x=> x.Value >= spent_colors[x.Key])) {
            yourtotalmana -= spent_colors.Sum(x => x.Value);
            if (yourtotalmana - incolor >= 0)
                return true;
        }
        return false;
    }

    //Fase das Cores 
    public bool ChooseColor() {
        if (pallete.TestEmptyPallete()) {
            pallete.ModifyingPallete();
            message.InstantiateImage("Image1Prefab", "Canvas", new Vector3(0, -30f, -270));
            return true;
        }
        else {
            FillColors();
            return false;
        }
    }

    public void AddColor(char c) {
        max_colors[c.ToString()]++;
    }

    public void RefreshColors() {
        List<string> keys = new List<string>(colors.Keys);
        foreach (string key in keys)
            colors[key] = max_colors[key];
    }

    public void FillColors() {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Color");
        int i = 0;
        Color aux = Color.gray;

        foreach (GameObject g in go) {
            g.GetComponent<ClickColor>().color = pallete.color_pallete[i];
            g.GetComponent<Renderer>().material.color = real_color[pallete.color_pallete[i].ToString()];
            i++;
        }
    }

    public void EndColorPhase() {
        pallete.RestartPallete();
        message.DestroyImage("Image1Prefab");
        RefreshColors();
    }
    

}
