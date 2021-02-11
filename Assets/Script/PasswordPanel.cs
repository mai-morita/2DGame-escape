using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PasswordPanel : MonoBehaviour {
    
    int[] enteredPassword = new int[] {0, 1, 2};  //パスワードを入れる配列
    int[] correctPassword = new int[] {0, 1, 2};  //パスワードの解答
    
    public Image[] buttons;  //画像の配列
    public Sprite[] sprites;  //画像ソースの配列
    public GameObject currentFlag;

    public void OnClickPassword(int position) {
        Debug.Log("password" + position);
        ChangeNumber(position);
        ShowNumber(position);
    }
    //パスワードボタンが押されたら呼ばれる。positionはボタン番号を表す。
 
    void ChangeNumber(int position) {
        // Debug.Log("000");
        int tmp = enteredPassword[position];
        // Debug.Log("111");
        tmp++;
        tmp %= 7;
        enteredPassword[position] = tmp;
        Debug.Log(position + "::" + tmp);
    }
    //管理している番号を＋１する。
 
    void ShowNumber(int position) {
        int tmp = enteredPassword[position];
        buttons[position].sprite = sprites[tmp];
    }
    //画像を変更する。

    public void OnClickEnter() {
        if (enteredPassword.Intersect(correctPassword).Count() == enteredPassword.Count()) {
            Debug.Log("CLEAR");
            FadeCanvas fadePanel = currentFlag.GetComponent<FadeCanvas>();
            fadePanel.FadeFlag();
            //フェードアウト開始
        } else {
            Debug.Log("MISS");
        }
    }
    //答えあわせ
}
