using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public int max_size;
    private int size=0;

	public void OnPointerEnter(PointerEventData eventData) {


    }

    public void OnPointerExit(PointerEventData eventData) {

    }

    public void OnDrop(PointerEventData eventData) {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        
        if (d != null & size + 1 <= max_size ) {
            d.parentToReturnTo = this.transform;
            d.isPlayed = true;
            size++;
        }
    }

}
