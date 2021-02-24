using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPasswordBox : MonoBehaviour
{
    private int MAX_PWBOX_LENGTH = 4;
    List<GameObject> pwBoxes = new List<GameObject>();
    List<ReleaseItem.Type> correctPassword = new List<ReleaseItem.Type>() { ReleaseItem.Type.card1, ReleaseItem.Type.card3, ReleaseItem.Type.card4, ReleaseItem.Type.card5 };  //パスワードの解答
    public GameObject usePanel;
    public GameObject countObj;
    bool correct;

    public bool CreateItemInPasswordBox(GameObject inBoxItemObject)
    {
        int count = pwBoxes.Count;
        if (count >= MAX_PWBOX_LENGTH)
        {
            return false;
        }
        ReleaseItem inBoxItemScript = inBoxItemObject.GetComponent<ReleaseItem>();
        GameObject inBoxItemObj = (GameObject)Resources.Load(inBoxItemScript.type.ToString() + "_inPasswordBox");
        inBoxItemObj.GetComponent<ReleaseItem>().releaseGameObject = inBoxItemObject;

        GameObject createPasswordObj = (GameObject)Instantiate(inBoxItemObj, new Vector2(count * 300 - 450, -360), Quaternion.identity);
        createPasswordObj.transform.SetParent(transform, false);
        pwBoxes.Add(createPasswordObj);
        return true;
    }
    public void ReleaseItemInPasswordBox(GameObject itemInBoxGameObject)
    {
        Debug.Log("777");
        HaveItem script = itemInBoxGameObject.GetComponent<HaveItem>();
        GameObject releaseObject = script.releaseGameObject;

        pwBoxes.Remove(itemInBoxGameObject);
        Destroy(itemInBoxGameObject);


        int index = 0;
        foreach (GameObject pw in pwBoxes)
        {
            Debug.Log("888");
            pw.GetComponent<RectTransform>().anchoredPosition = new Vector2(index * 300 - 450, -360);
            index++;
        }
        Debug.Log("999");
    }
    bool CorrectPasswordCheker()
    {
        if (pwBoxes.Count == 0)
        {
            return false;
        }
        int i = 0;
        correct = true;
        foreach (GameObject pw in pwBoxes)
        {
            if (correctPassword[i] != pw.GetComponent<ReleaseItem>().type)
            {
                correct = false;
            }
            i++;
        }
        return correct;
    }
    GameObject twoListBoxItems;

    public void OnClickEnter()
    {
        bool correctFlag = CorrectPasswordCheker();
        if (!correctFlag)
        {
            Debug.Log("MISS");
            return;
        }
        if (correctFlag)
        {
            Debug.Log("CLEAR");
            CountDown timeStoper = countObj.GetComponent<CountDown>();
            timeStoper.StopGame();
            FadeCanvas fadePanel = usePanel.GetComponent<FadeCanvas>();
            fadePanel.StartFadeOut();
            //フェードアウト開始
        }
    }
    // 答えあわせ
}
