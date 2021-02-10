using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//クリックした時に特定のパネルの場所に移動する

public class ChangePanelOnClick : MonoBehaviour {

    //右のボタンを押した時、x値が1500ずつ移動する
    //左のボタンを押した時、x値が-1500ずつ移動する
    //一番右（または左）に移動した時、矢印をなくす（ループでもいいかも）

    int PANEL_DISTANCE = 1242;
    int TOTAL_PANELS = 4;

    public void RightArrow() {
        Debug.Log("clicked");
        Vector2 currentPosition = this.transform.localPosition;  //今いる場所
        int currentX = (int)currentPosition.x;  //今いるX値
        int panelNumber = -(currentX / PANEL_DISTANCE);  //1500分の1500 = 1となる
        int nextPanelNumber = (panelNumber + 1) % TOTAL_PANELS;  //2割る4の余り(%)　あまりなので0,1,2,3のどれかにしかならない。
        this.transform.localPosition = new Vector2(-(nextPanelNumber * PANEL_DISTANCE), currentPosition.y );
    }

    public void LeftArrow() {
        Vector2 currentPosition = this.transform.localPosition;
        int currentX = (int)currentPosition.x;
        int panelNumber = -(currentX / PANEL_DISTANCE);
        int nextPanelNumber = (panelNumber + TOTAL_PANELS - 1)%TOTAL_PANELS;
        this.transform.localPosition = new Vector2(-(nextPanelNumber * PANEL_DISTANCE), currentPosition.y );
    }//panelNumber=1の時は割る数字が0になってしまうため、TOTAL_PANELSを足す事で補う。
}
