using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    
	int minute;
	int seconds;
    int oldSeconds;
    public float totalTime;

    public Text timerText;
	public string showObjectName;
    GameObject showObject;

    void Start() {
        showObject = GameObject.Find(showObjectName);
        showObject.SetActive(false);
    }
    
    public void ShowPanel() {
        showObject.SetActive(true);
    }
 
	void Update () {

		totalTime -= Time.deltaTime;  //　一旦トータルの制限時間を計測；
 
		minute = (int) totalTime / 60;  //　再設定
		seconds = (int) totalTime - minute * 60;
 
		if(seconds != oldSeconds) {
			timerText.text = minute.ToString("00") + ":" + seconds.ToString("00");
		}
		oldSeconds = seconds;
        //  oldSecondsは、同じ秒数だった時にTextを更新しない
        //　タイマー表示用UIテキストに時間を表示する
        
		if (totalTime <= 0f) {
			return;  //　制限時間が0秒以下なら何もしない
            Debug.Log("制限時間終了");
		}
	}
}
