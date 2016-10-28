using UnityEngine;
using System.Collections;

public class ViewModel : MonoBehaviour {

    public void ButtonClick() {
        Control controlreference = GameObject.FindObjectOfType(typeof(Control)) as Control;
        if (controlreference.turnControl == "play")
            controlreference.EndPhase();
    }
}
