using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour {

    public string showObjectName;
    GameObject showObject;

    public void Start() {
        showObject = GameObject.Find(showObjectName);
        showObject.SetActive(true);
    }
    
    public void HidePanel() {
        showObject.SetActive(false);
    }
}
