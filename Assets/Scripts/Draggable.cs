﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;
    GameObject placeholder = null;
    public bool isPlayed = false, played=false;

    public string getControlInstance() {
        return GameObject.Find("Control").GetComponent<Control>().turnControl;
    }

    public void OnBeginDrag(PointerEventData eventData) {

        if (!played && getControlInstance() == "play") {
            Debug.Log("Begging");
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
        Debug.Log("Dragging");
        if (!played && getControlInstance() == "play")
            this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End of Dragging");

        if (getControlInstance() == "play") {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            Destroy(placeholder);
            if (isPlayed)
                played = true;
        }

    }

}
