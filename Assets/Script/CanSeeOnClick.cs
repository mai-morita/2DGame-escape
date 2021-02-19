using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanSeeOnClick : MonoBehaviour {

    GameObject[] storeditems;

    void Start() {
        storeditems = GameObject.FindGameObjectsWithTag("stored");
        foreach (GameObject item in storeditems) {
            item.SetActive(false);
        }
    }

    public void GetGlasses() {
        ItemBox.instance.SetItem(gameObject); //Itemの格納
        gameObject.SetActive(false);
        foreach (GameObject item in storeditems) {
            item.SetActive(true);
        }
    }

    public void GetKey() {
        ItemBox.instance.SetItem(gameObject); //Itemの格納
        gameObject.SetActive(false);
    }
}
