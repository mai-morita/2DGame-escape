using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPasswordBox : MonoBehaviour
{
    public static InPasswordBox instance;
    List<GameObject> pwBoxes = new List<GameObject>();
    void Start()
    {
        instance = this;
    }
    //static化=どのファイルからでも参照できる

}
