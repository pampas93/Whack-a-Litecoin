using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showCoin : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //anim.SetTrigger("OnClick");
    }
    

    public void makeItActive()
    {
        this.GetComponent<Animator>().SetTrigger("Show");
        //Debug.Log(anim);
        //anim.SetTrigger("OnClickTrigger");
    }

}
