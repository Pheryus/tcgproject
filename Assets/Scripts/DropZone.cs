using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler {

    public int max_size;
    private int size=0;

    public Control getControlInstance() {
        return GameObject.Find("Control").GetComponent<Control>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("esta em cima");
    }


    public void OnDrop(PointerEventData eventData) {
        
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        Control c = getControlInstance();
        Debug.Log("Oloco");
        if (d != null && size + 1 <= max_size ) {
            Debug.Log("carta jogada");
            d.parentToReturnTo = this.transform;
            
            size++;


            d.isPlayed = true;
        }
    }

}
