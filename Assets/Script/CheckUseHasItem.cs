using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUseHasItem : MonoBehaviour {

    public GameObject usePanel;

    public void CanUseItem() {
        if(ItemBox.instance.HasKey()){
            FadeCanvas fadePanel = usePanel.GetComponent<FadeCanvas>();
            fadePanel.StartFadeOut();
        }
    }
}
