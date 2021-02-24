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
        if (!lastQuestionObject)
        {
            gameObject.SetActive(true);
        }
        InItemBox.instance.ReleaseItemFromItemBox(gameObject);
    }
}
