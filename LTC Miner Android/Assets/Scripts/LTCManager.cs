using System.Collections;
using UnityEngine;

public class LTCManager : MonoBehaviour {

    public float gap = 2;
    public int menu_time = 2;

    private IEnumerator coroutine;

    private bool flag = false;
    private bool isPaused = false;

    System.Random random;

    public GameObject[] litecoins;

    void Start()
    {
        random = new System.Random();

        coroutine = LtcCoroutine();
        flag = true;
        StartCoroutine(coroutine);
    }

    void Update () {
		
        
	}

    IEnumerator LtcCoroutine()
    {
        while (flag)
        {
            //Debug.Log(litecoins.Length);
            int rno = random.Next(1, litecoins.Length + 1);
            //Debug.Log(rno);

            GameObject tempObj = litecoins[rno - 1];
            tempObj.GetComponentInChildren<showCoin>().makeItActive();

            yield return new WaitForSeconds(gap);

            //if(isPaused)
            //    yield return new Wait
        }

    }
}
