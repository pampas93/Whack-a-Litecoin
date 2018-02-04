using UnityEngine;


public class Shoot : MonoBehaviour
{

    public GameObject bullet;
    public float bulletSpeed;
    public Transform bulletSpawn;

    void Update()
    {
        if (!GameManager.instance.timeUp)
        {
            //Web
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.decreaseTimeWithShoot();

                var bt = (GameObject)Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                bt.GetComponent<Rigidbody>().velocity = bt.transform.forward * bulletSpeed;
                Destroy(bt, 2.5f);

            }

            ////Android
            //if (Input.touchCount > 0)
            //{
            //    if (Input.GetTouch(0).phase == TouchPhase.Began)
            //    {
            //        GameManager.instance.decreaseTimeWithShoot();
            //
            //        var bt = (GameObject)Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            //        bt.GetComponent<Rigidbody>().velocity = bt.transform.forward * bulletSpeed;

            //        Destroy(bt, 4.0f);
            //    }
            //}
        }
    }
}