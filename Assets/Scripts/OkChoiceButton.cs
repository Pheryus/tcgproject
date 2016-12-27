using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OkChoiceButton : MonoBehaviour, IPointerClickHandler {

    private Control GetControlReference() {
        return GameObject.Find("Control").GetComponent<Control>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        Control c = GetControlReference();
        if (eventData.button == PointerEventData.InputButton.Left) {
            c.color.SpendMana();
            c.turnControl = "play";
            Destroy(gameObject.transform.parent.gameObject);

        }
    }
}
