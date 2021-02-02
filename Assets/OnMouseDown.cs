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
        Debug.Log("opened");
        showObject.SetActive(true);
    }

    public void HidePanel() {
        showObject.SetActive(false);
        Debug.Log("closed");
    }

}
