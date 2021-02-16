using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseItem : MonoBehaviour {

    //クリックした時に、アイテムボックスに格納し、非表示にする
    //列挙型で管理

    public enum Type { 
        card1 = 0, 
        card2 = 1, 
        card3 = 2, 
        card4 = 3, 
        card5 = 4,
        card6 = 5
    }
    public Type type;

    public void ItemHide() {
        ItemBox.instance.SetItem(gameObject); //Itemの格納
        gameObject.SetActive(false);
    }
}
