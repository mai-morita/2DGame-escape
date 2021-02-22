using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnMouseDown : MonoBehaviour
{

    //クリックした時　オブジェクトを表示する

    public string showObjectName;
    GameObject showObject;
    public GameObject parentObject;
    public GameObject usePanel;


    public void Awake()
    {
        showObject = GameObject.Find(showObjectName);
        showObject.SetActive(false);
    }

    public void ShowPanel()
    {
        parentObject = showObject.transform.parent.gameObject;
        bool onParent = parentObject.activeSelf;
        if (onParent)
        {
            showObject.SetActive(true);
        }
    }
    public void HidePanel()
    {
        showObject.SetActive(false);
    }
}
