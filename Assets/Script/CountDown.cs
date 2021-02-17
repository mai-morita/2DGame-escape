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
		if (totalTime >= 0) {
			totalTime -= Time.deltaTime;  //　一旦トータルの制限時間を計測；
 
			minute = (int) totalTime / 60;  //　再設定
			seconds = (int) totalTime - minute * 60;
	
			if(seconds != oldSeconds) {
				timerText.text = minute.ToString("00") + ":" + seconds.ToString("00");
			}
			oldSeconds = seconds;
			//  oldSecondsは、同じ秒数だった時にTextを更新しない
			//　タイマー表示用UIテキストに時間を表示する
		}
	}

	public void StopGame() {
        Time.timeScale = 0f;
		Debug.Log(totalTime);
	}

	public void ReStartGame() {
        Time.timeScale = 1f;
	}
}
