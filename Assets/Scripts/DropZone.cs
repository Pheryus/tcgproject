using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {

    public int max_size;
    private int size=0;

    public Control getControlInstance() {
        return GameObject.Find("Control").GetComponent<Control>();
    }

    public void SetSize(int size) {
        this.size = size;
    }


    public void OnDrop(PointerEventData eventData) {
        
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        Control c = getControlInstance();
        
        if (d != null && size + 1 <= max_size && d.canBeMoved) {
            int colorneeded = c.color.CardPlayed(d.gameObject.GetComponent<CardInstance>().card);
            if (colorneeded > 0) { 
                c.turnControl = "color_choose";
                d.parentToReturnTo = this.transform;
                c.color.zonePlayed = gameObject.name;
                size++;
                d.cardIs = "waiting";
                c.color.images.CreateChoiceColor(colorneeded);
            }
            else {
                d.parentToReturnTo = this.transform;
                size++;
                d.cardIs = "played";
            }
        }
    }



}
