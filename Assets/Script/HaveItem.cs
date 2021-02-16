using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveItem : MonoBehaviour {

    public GameObject releaseGameObject;

    public void ReleaseItem() {
        ItemBox.instance.ReleaseItem(gameObject); 
    }
}
