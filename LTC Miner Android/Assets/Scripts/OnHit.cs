﻿using UnityEngine;

public class OnHit : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit an object!");
        //Debug.Log(collision.collider.gameObject.name);

        this.GetComponent<Rigidbody>().useGravity = true;

        if (collision.collider.gameObject.tag == "Litecoin")
        {
            GameManager.instance.increaseScore();
        }
        else if(collision.collider.gameObject.tag == "NextScreen")
        {
            GameManager.instance.increaseTimeWithShoot();
            ScreenManager.instance.NewScreen(collision.collider.gameObject);
        }
        
    }
}
