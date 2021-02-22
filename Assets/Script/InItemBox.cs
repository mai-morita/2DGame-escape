using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InItemBox : MonoBehaviour
{
    private int MAX_ITEMBOX_LENGTH = 5;
    public GameObject lastQuestionObject;
    public GameObject NumberPassword;
    public static InItemBox instance;
    List<GameObject> itemBoxes = new List<GameObject>();
    void Start()
    {
        instance = this;
    }
    //static化=どのファイルからでも参照できる
    public bool SetItem(GameObject itemObject)
    {
        return CreateItem(itemObject);
    }
    public bool HasKey()
    {
        foreach (GameObject box in itemBoxes)
        {
            ReleaseItem releaseItem = box.GetComponent<HaveItem>().releaseGameObject.GetComponent<ReleaseItem>();
            if (releaseItem.type == ReleaseItem.Type.key)
            {
                return true;
            }
        }
        return false;
    }
    public void ReleaseItemFromItemBox(GameObject itemInBoxGameObject)
    {
        bool lastQuestionObjActive = lastQuestionObject.activeSelf;
        if (lastQuestionObjActive)
        {
            itemBoxes.Remove(itemInBoxGameObject);
            Destroy(itemInBoxGameObject);

        }
        else
        {
            HaveItem script = itemInBoxGameObject.GetComponent<HaveItem>();
            GameObject releaseObject = script.releaseGameObject;
            releaseObject.SetActive(true);

            itemBoxes.Remove(itemInBoxGameObject);
            Destroy(itemInBoxGameObject);

            foreach (GameObject box in itemBoxes)
            {
                int index = 0;
                box.GetComponent<RectTransform>().anchoredPosition = new Vector2(index * 240 - 480, -1144);
                index++;
            }
        }
    }
    bool CreateItem(GameObject releaseObject)
    {
        bool lastQuestionObjActive = lastQuestionObject.activeSelf;
        if (lastQuestionObjActive)
        {
            NumberPasswordPanel passwordChecker = NumberPassword.GetComponent<NumberPasswordPanel>();
            if (!passwordChecker.AlignCardPassword(releaseObject))
            {
                return false;
            }
        }
        else
        {
            int count = itemBoxes.Count;

            if (count >= MAX_ITEMBOX_LENGTH)
            {
                return false;
            }
            ReleaseItem releaseItem = releaseObject.GetComponent<ReleaseItem>();
            GameObject HaveItemObj = (GameObject)Resources.Load(releaseItem.type.ToString());

            HaveItemObj.GetComponent<HaveItem>().releaseGameObject = releaseObject;

            GameObject createHaveObj = (GameObject)Instantiate(HaveItemObj, new Vector2(count * 240 - 480, -1144), Quaternion.identity);
            createHaveObj.transform.SetParent(transform, false);
            itemBoxes.Add(createHaveObj);
        }
        return true;
    }
}
