using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class ChooseButtonColor : MonoBehaviour, IPointerClickHandler {

    int costReference=0;
    Text costTextReference;
    GameObject sumObject;

    public GameObject okObject;

    public void Start() {
        okObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData) {

        if (eventData.button == PointerEventData.InputButton.Left)
            ClickButton(true);
        else if (eventData.button == PointerEventData.InputButton.Right)
            ClickButton(false);
    }

    private Control GetControlReference() {
        return GameObject.Find("Control").GetComponent<Control>();
    }

    private void ChangeCost(int cost) {
        costReference += cost;
        costTextReference.text = costReference.ToString();
    }

    private void ClickButton(bool left) {
        sumObject = GameObject.FindGameObjectWithTag("SumColor");
        costTextReference = sumObject.GetComponent<Text>();
        Int32.TryParse(costTextReference.text, out costReference);

        Colors c = GetControlReference().color;
        Transform sonTransform = gameObject.transform.GetChild(0);
        String sonReference = sonTransform.name;

        Text colorText = sonTransform.GetComponent<Text>();
        int value = 0;
        Int32.TryParse(colorText.text, out value);

        if (costReference > 0 && left && c.GetActualColors(sonReference) > 0 && c.GetActualColors(sonReference) >= c.GetSpentColors(sonReference)) {
            c.ChangeSpentColor(sonReference, 1);
            value++; 
            ChangeCost(-1);
            if (costReference == 0)
                okObject.SetActive(true);
        }
        else if (!left && value > 0) {
            c.ChangeSpentColor(sonReference, -1);
            value--;
            ChangeCost(1);
        }

        if (costReference != 0 && okObject.activeSelf)
            okObject.SetActive(false);

        colorText.text = value.ToString();

    }

}
