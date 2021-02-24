using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseItem : MonoBehaviour
{

    //クリックした時に、アイテムボックスに格納し、非表示にする
    //列挙型で管理

    public enum Type
    {
        card1 = 0,
        card2 = 1,
        card3 = 2,
        card4 = 3,
        card5 = 4,
        card6 = 5,
        glasses = 6,
        key = 7
    }
    public Type type;
    public string lastQuestionObjectName;
    GameObject lastQuestionObject;
    public GameObject releaseGameObject;

    public void ItemHide()
    {
        bool successed = InItemBox.instance.SetItem(gameObject); //Itemの格納
        if (successed)
        {
            gameObject.SetActive(false);
        }
    }
    public void InPasswordBoxItem()
    {
        lastQuestionObject = GameObject.Find(lastQuestionObjectName);
        if (lastQuestionObject)
        {
            InPasswordBox presentItem = GameObject.FindWithTag("InPasswordBox").GetComponent<InPasswordBox>();
            presentItem.CreateItemInPasswordBox(gameObject);
        }
        return;
    }
    public void ReturnInItemBox()
    {
        Debug.Log("111");
        InItemBox.instance.SetItem(gameObject); //Itemの格納
        Debug.Log("222");
        InPasswordBox presentItem = GameObject.FindWithTag("InPasswordBox").GetComponent<InPasswordBox>();
        Debug.Log("333");
        presentItem.ReleaseItemInPasswordBox(gameObject);
        Debug.Log("444");
    }
}
