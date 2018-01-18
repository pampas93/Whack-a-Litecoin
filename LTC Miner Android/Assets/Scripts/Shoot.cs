﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour
{

    public GameObject bullet;
    public float bulletSpeed;
    public Transform bulletSpawn;
    public TextMesh txtDebug;
    public TextMesh txt2;

    void Update()
    {
        //Web
        if (Input.GetMouseButtonDown(0))
        {

            var bt = (GameObject)Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            bt.GetComponent<Rigidbody>().velocity = bt.transform.forward * bulletSpeed;

            Destroy(bt, 4.0f);
        }

        ////Android
        //if (Input.touchCount > 0)
        //{
        //    if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
        //        var bt = (GameObject)Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        //        bt.GetComponent<Rigidbody>().velocity = bt.transform.forward * bulletSpeed;

        //        Destroy(bt, 4.0f);
        //    }
        //}
    }
}