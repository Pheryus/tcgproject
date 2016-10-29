using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;
    GameObject placeholder = null;
    public bool isPlayed = false, played=false;

    public Control getControlInstance() {
        return GameObject.Find("Control").GetComponent<Control>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Control controlinstance = getControlInstance(); 

        if (!played && controlinstance.turnControl == "play" && controlinstance.color.CheckIfItsPlayable(gameObject)) {
            
            placeholder = new GameObject();
            placeholder.transform.SetParent(this.transform.parent);
            LayoutElement le = placeholder.AddComponent<LayoutElement>();
            le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
            le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
            le.flexibleHeight = 0;
            le.flexibleWidth = 0;

            placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            parentToReturnTo = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

    }

	public void OnDrag(PointerEventData eventData) {
        Control controlinstance = getControlInstance();

        if (!played && getControlInstance().turnControl == "play" && controlinstance.color.CheckIfItsPlayable(gameObject))
            this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End of Dragging");
        Control controlinstance = getControlInstance();

        if (getControlInstance().turnControl == "play" && controlinstance.color.CheckIfItsPlayable(gameObject)) {
            Debug.Log("oli");
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            Destroy(placeholder);
            if (isPlayed)
                played = true;
        }

    }

}
