using UnityEngine;
using System.Collections;

public class ViewModel : MonoBehaviour {

    public void ButtonClick() {
        Debug.Log("teste");
        Control controlreference = GameObject.FindObjectOfType(typeof(Control)) as Control;
        controlreference.EndPhase();
    }
}
