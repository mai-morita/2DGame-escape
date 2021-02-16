using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {
    
    public static ItemBox instance;
    List<GameObject> boxes = new List<GameObject>();
    
    void Start() {
        instance = this;
    }
    //static化=どのファイルからでも参照できる

    public void SetItem(GameObject itemObject) {
        CreateItem(itemObject);
    }

    public void ReleaseItem(GameObject itemInBoxGameObject) {
        HaveItem script = itemInBoxGameObject.GetComponent<HaveItem>();
        GameObject releaseObject = script.releaseGameObject;
        releaseObject.SetActive(true);

        boxes.Remove(itemInBoxGameObject);
        Destroy(itemInBoxGameObject);

        int index = 0;
        foreach(GameObject box in boxes) {
            box.GetComponent<RectTransform>().anchoredPosition = new Vector2(index * 240 - 480, -1144);
            index++;
        }
    }
    //クリックした時、boxesの中から自分を消す
    //落ちているアイテムのSetActiveをtrueに戻す

    void CreateItem(GameObject releaseObject) {
        int count = boxes.Count;

        ReleaseItem releaseItem = releaseObject.GetComponent<ReleaseItem>();
        GameObject HaveItemObj = (GameObject)Resources.Load(releaseItem.type.ToString()); 

        HaveItemObj.GetComponent<HaveItem>().releaseGameObject = releaseObject;

        GameObject createHaveObj = (GameObject)Instantiate(HaveItemObj,new Vector2(count * 240 - 480, -1144),Quaternion.identity);
        createHaveObj.transform.SetParent (transform, false);
        boxes.Add(createHaveObj);
    }
    //消した時に配列が何個か所得して左に詰める
}
