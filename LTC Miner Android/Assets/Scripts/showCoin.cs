﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showCoin : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //anim.SetTrigger("OnClick");
    }
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Clicked");
        //    anim.SetTrigger("OnClick");
        //}

        //if (Input.GetMouseButtonDown(1))
        //{
        //    Debug.Log("right Clicked");
        //    anim.SetTrigger("OnRightClick");
        //}

        //if (Input.GetKeyDown("space"))
        //    anim.speed = 0;
    }

    public void makeActive()
    {
        anim.SetTrigger("OnClick");
    }

}
