using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextColor : MonoBehaviour {

    private Colors colorref;

    void Update() {
        colorref = GameObject.Find("Control").GetComponent<Control>().color;
        transform.GetChild(0).GetComponent<Text>().text = colorref.GetActualColors(gameObject.name).ToString();
        transform.GetChild(2).GetComponent<Text>().text = colorref.GetMaxColors(gameObject.name).ToString();
    }
}
