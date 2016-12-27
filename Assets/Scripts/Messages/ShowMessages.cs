using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ShowMessages {

    public Dictionary<string, GameObject> imgs;

    public ShowMessages() {
        imgs = new Dictionary<string, GameObject>();
    }

    public void DestroyImage(string text) {
        imgs.Remove(text);
    }

    public void InstantiateImage(string imgname, string parent, Vector3 pos) {
        GameObject go = (GameObject)GameObject.Instantiate(Resources.Load(imgname));
        imgs.Add(imgname, go);
        if (parent != "")
            imgs[imgname].transform.SetParent(GameObject.Find(parent).transform, false);
        imgs[imgname].transform.localPosition = pos;
    }

}
