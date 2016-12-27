using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CancelColorChoiceButton : MonoBehaviour, IPointerClickHandler {

    private Control GetControlReference() {
        return GameObject.Find("Control").GetComponent<Control>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        Control c = GetControlReference();
        if (eventData.button == PointerEventData.InputButton.Left) {
            GameObject g = GameObject.Find(c.color.zonePlayed);
            c.color.ResetManaCount();
            c.color.ReturnOriginalMana();
            ReferenceCardToHand(g);
            RemoveCardFromField(g);
            c.turnControl = "play";
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    public void ReferenceCardToHand(GameObject g) {
        g.transform.GetChild(0).SetParent(GameObject.Find("Hand").transform);
    }

    public void RemoveCardFromField(GameObject g) {
        DropZone d = g.GetComponent<DropZone>();
        d.SetSize(0);
    }

}
