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

    public void GetItem() {
        ItemBox.instance.SetItem(gameObject); //Itemの格納
        gameObject.SetActive(false);
        foreach (GameObject item in storeditems) {
            item.SetActive(true);
        }
    }

    // public void ReleaseItem() {
    //     ItemBox.instance.ReleaseItem(gameObject); 
    //     gameObject.SetActive(true);
    //     foreach (GameObject item in storeditems) {
    //         item.SetActive(false);
    //     }
    // }

//  初期値:カードは非表示にする
//  眼鏡を所得した時:カードが表示される
//  眼鏡を戻した時:落ちているカードが非表示・アイテムボックスの配列の中身をDestroyする(ReleaseItem.Script?)
}
