using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Images {

    public void CreateChoiceColor(int n) {
        if (n == 0)
            return;
        GameObject instanciateObj = (GameObject)GameObject.Instantiate(Resources.Load("checkcolorcard"));
        instanciateObj.transform.SetParent(GameObject.Find("Canvas").transform);
        instanciateObj.GetComponent<RectTransform>().localPosition = new Vector3(24, 142, 0);
        instanciateObj.transform.GetChild(0).GetComponent<Text>().text = n.ToString();
    }

}
