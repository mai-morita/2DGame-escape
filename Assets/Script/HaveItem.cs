using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HaveItem : MonoBehaviour
{

    public GameObject releaseGameObject;
    public string lastQuestionObjectName;
    GameObject lastQuestionObject;
    public void ReleaseItem()
    {
        lastQuestionObject = GameObject.Find(lastQuestionObjectName);
        if (lastQuestionObject)
        {
            InPasswordBox presentItem = GameObject.FindWithTag("InPasswordBox").GetComponent<InPasswordBox>();
            presentItem.CreateItemInPasswordBox(gameObject);
            InItemBox.instance.ReleaseItemFromItemBox(gameObject);
        }
        else
        {
            InItemBox.instance.ReleaseItemFromItemBox(gameObject);
            gameObject.SetActive(true);
        }
    }
}
