using UnityEngine;
using UnityEngine.VR;
using ProgressBar;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public ProgressRadialBehaviour radialScript;

    private IEnumerator coroutine;
    public int ScoreUp = 7;

    [HideInInspector]
    public bool timeUp = false;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {

        StartCoroutine(LoadDevice("cardboard"));
        radialScript.IncrementValue(100);

        coroutine = timeCoroutine();
        StartCoroutine(coroutine);

    }

    IEnumerator LoadDevice(string newDevice)
    {
        VRSettings.LoadDeviceByName(newDevice);
        yield return null;

        VRSettings.enabled = false;
        Camera.main.ResetAspect();
        Camera.main.GetComponent<Transform>().localRotation = InputTracking.GetLocalRotation(VRNode.CenterEye);
    }


    void Update () {

        Camera.main.GetComponent<Transform>().localRotation = InputTracking.GetLocalRotation(VRNode.CenterEye);
    }

    IEnumerator timeCoroutine()
    {
        while (!timeUp)
        {
            if (radialScript.Value == 0)
                timeUp = true;

            radialScript.DecrementValue(3);
            yield return new WaitForSeconds(1);
        }
        Debug.Log("TimeUp");
    }

    public void increaseScore()
    {
        radialScript.IncrementValue(ScoreUp);
        //Increase score as well here
    }
}
