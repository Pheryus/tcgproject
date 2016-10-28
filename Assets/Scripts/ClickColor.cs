using UnityEngine;
using System.Collections;

public class ClickColor : MonoBehaviour {

    public char color;

    void OnMouseOver() {
        Control controlreference = GameObject.FindObjectOfType(typeof(Control)) as Control;

        if (controlreference.turnControl != "color") {
            return;
        }    

        if (Input.GetMouseButtonDown(0) && color != 'd' && color != 'e') {
            controlreference.color.AddColor(color);
            color = 'e';
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
            controlreference.EndColorPhase();
        }

    }
	
}
