using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardInstance : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Card card = null;

    public void setCard(Card card) {
        this.card = card;
    }

    public void setImage(Transform parent) {
        this.gameObject.transform.SetParent(parent);
        this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + card.getID().ToString());
   }

    public void OnPointerEnter(PointerEventData eventData) {
        
        GameObject go = GameObject.Find("targetCard");
       
        go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + card.getID().ToString());
        Color c = go.GetComponent<Image>().color;
        c.a = 255;
        go.GetComponent<Image>().color = c;
        
    }

    public void OnPointerExit(PointerEventData eventData) {
        GameObject go = GameObject.Find("targetCard");
        Color c = go.GetComponent<Image>().color;
        c.a = 0;
        go.GetComponent<Image>().color = c;
    }

}

