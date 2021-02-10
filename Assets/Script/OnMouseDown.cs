using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDown : MonoBehaviour {

    //クリックした時　オブジェクトを表示する

    public string showObjectName;
    GameObject showObject;

    public void Start() {
        showObject = GameObject.Find(showObjectName);
        showObject.SetActive(false);
    }

    public void ShowPanel() {
        showObject.SetActive(true);
        Debug.Log("opened");
    }

    public void HidePanel() {
        showObject.SetActive(false);
        Debug.Log("closed");
    }
}
