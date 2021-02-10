using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {

    //アイテムがクリックされた時、boxに格納される
    //一番左から埋まっていく。
    //複数アイテムを格納する時は、一番左に何か入っていればその隣へ、入っていなければその位置に収納される
    //何が入っているか見つける必要がある

    //static化=どのファイルからでも参照できる


    public GameObject[] boxes;

    public static ItemBox instance;

    void Start() {
        instance = this;
    }

    public void SetItem(Item.Type type) {
        int index = (int)type;
        boxes[index].SetActive(true);
    }

    // public  void CanSetItem(Item.Type type) {
    //     int index = (int)type;
    //     return boxes[index].activeSelf;
    // }

    // public void UseItem(Item.Type type) {
    //     int index = (int)type;
    //     boxes[index].SetActive(false);
    // }
}

