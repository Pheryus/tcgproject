using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;
    GameObject placeholder = null;
    public bool played=false;
    public string cardIs;
    public bool isChoosingColor = false;

    public bool canBeMoved = false;
    public GameObject choice_color;

    public Control getControlInstance() {
        return GameObject.Find("Control").GetComponent<Control>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Control controlinstance = getControlInstance();
        Card c = gameObject.GetComponent<CardInstance>().card;
        if (controlinstance.turnControl == "play") {
            if (controlinstance.color.CheckIfItsPlayable(c)) {
                this.canBeMoved = true;
                creatingPlaceholder();
                creatingLayoutElement();
                settingParent();
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }

    }

    private void creatingPlaceholder() {
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
    }

    private void creatingLayoutElement() {
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;
    }

    private void settingParent() {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData) {
        Control controlinstance = getControlInstance();

        if (getControlInstance().turnControl == "play" && this.canBeMoved) {
            this.transform.position = eventData.position;
        }
    }


    public void OnEndDrag(PointerEventData eventData) {
        Control controlinstance = getControlInstance();
     
        if (this.canBeMoved) {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            Destroy(placeholder);
            if (cardIs == "played")
                played = true;

            this.canBeMoved = false;

        }
        controlinstance.color.ResetManaCount();
    }
    
}
