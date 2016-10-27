using UnityEngine;
using System.Collections;

public class ViewModel : MonoBehaviour {

    public void ButtonClick() {
        Control controlreference = GameObject.FindObjectOfType(typeof(Control)) as Control;
        controlreference.EndPhase();
    }
}
