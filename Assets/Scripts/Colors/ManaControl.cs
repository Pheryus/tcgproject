using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;

public class ManaControl {



    public bool CheckIfHaveMana(Colors c, string mana, string additional_mana = "") {
        string resultString = Regex.Match(mana, @"\d+").Value;
        int incolor = Int32.Parse(resultString);
        int rcount = 0, bcount = 0, gcount = 0, pcount = 0, ycount = 0;
        foreach (char o in mana) {
            if (o == 'r') rcount++;
            if (o == 'b') bcount++;
            if (o == 'g') gcount++;
            if (o == 'y') ycount++;
            if (o == 'p') pcount++;
        }

        int yourtotalmana = c.red + c.green + c.blue + c.yellow + c.purple;

        if (rcount <= c.red && bcount <= c.blue && gcount <= c.green && ycount <= c.yellow && pcount <= c.purple) {
            yourtotalmana -= rcount + bcount + gcount + ycount + pcount;
            if (yourtotalmana >= incolor)
                return true;
        }

        return false;
    }



}
