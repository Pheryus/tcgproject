using UnityEngine;
using UnityEngine.UI;
using System;

using System.Collections;

public class ChooseButtonColor : MonoBehaviour {

    public void ButtonClick() {
        int i = 0; 
        Text t = GameObject.Find("sum").GetComponent<Text>();
        Int32.TryParse(t.text, out i);
        if (i < 0) {
            return; 
        }

        if (gameObject.name == "b") {
            //gameObject.
        }
        
    }
}
