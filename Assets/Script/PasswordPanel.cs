using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PasswordPanel : MonoBehaviour {
    
    // パスワードを入れる配列
    int[] pwArray= new int[] {0, 1, 2, 3, 4, 5, 6};
    // パスワードの解答
    int[] correct = new int[] {4, 5, 6};
    // 画像の配列
    public Image[] buttons;
    // 画像ソースの配列
    public Sprite[] sprites;

    // パスワードボタンが押されたら呼ばれる。positionはボタン番号を表す。
    public void OnClickPassword(int position) {
        Debug.Log("password" + position);
        ChangeNumber(position);
        ShowNumber(position);
    }
 
    // 管理している番号を＋１する。
    void ChangeNumber(int position) {
        Debug.Log("000");
        int tmp = pwArray[position];
        Debug.Log("111");
        tmp++;
        tmp %= 7;
        pwArray[position] = tmp;
        Debug.Log(position + "::" + tmp);
    }
 
    // 画像を変更する。
    void ShowNumber(int position) {
        int tmp = pwArray[position];
        buttons[position].sprite = sprites[tmp];
    }

    public void OnClickEnter() {
        if (pwArray.SequenceEqual(correct)) {
            Debug.Log("CLEAR");
        } else {
            Debug.Log("MISS");
        }
    }
}
