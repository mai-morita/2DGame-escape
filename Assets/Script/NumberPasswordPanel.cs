using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class NumberPasswordPanel : MonoBehaviour {

    private int MAX_PWBOX_LENGTH = 4;

    List<ReleaseItem.Type> correctPassword = new List<ReleaseItem.Type>() {ReleaseItem.Type.card1, ReleaseItem.Type.card3, ReleaseItem.Type.card4, ReleaseItem.Type.card5};  //パスワードの解答
    List<GameObject> pwBoxes = new List<GameObject>();

    public GameObject usePanel;
    public GameObject countObj;
    
    public bool AlignCardPassword(GameObject releaseObject) {
        int count = pwBoxes.Count;
        if( pwBoxes.Count() >= MAX_PWBOX_LENGTH) {
            return false;
        }
        ReleaseItem releaseItem = releaseObject.GetComponent<ReleaseItem>();
        GameObject HaveItemObj = (GameObject)Resources.Load(releaseItem.type.ToString()); 

        HaveItemObj.GetComponent<HaveItem>().releaseGameObject = releaseObject;

        GameObject createPasswordObj = (GameObject)Instantiate(HaveItemObj,new Vector2(count * 300 - 450, -360),Quaternion.identity);
        createPasswordObj.transform.SetParent(transform, false);
        pwBoxes.Add(createPasswordObj);

        int index = 0;
        foreach(GameObject pw in pwBoxes) {
            pw.GetComponent<RectTransform>().anchoredPosition = new Vector2(index * 300 - 450, -360);
            index++;
        }
        return true;
    }

    bool CorrectPasswordCheker() {
        if(pwBoxes.Count() == 0) {
            return false;
        }
        int i = 0;
        bool correct = true;
        foreach(GameObject pw in pwBoxes) {
            if(correctPassword[i] != pw.GetComponent<ReleaseItem>().type) {
                correct = false;
            }
            i++;
        }
        return correct;
    }

    public void OnClickEnter() {
        if (CorrectPasswordCheker()) {
            Debug.Log("CLEAR");
            CountDown timeStoper = countObj.GetComponent<CountDown>();
            timeStoper.StopGame();
            FadeCanvas fadePanel = usePanel.GetComponent<FadeCanvas>();
            fadePanel.StartFadeOut();
            //フェードアウト開始
        } else {
            Debug.Log("MISS");
        }
    }
    // 答えあわせ
}       