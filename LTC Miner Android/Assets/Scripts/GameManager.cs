using UnityEngine;
using UnityEngine.VR;
using ProgressBar;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public ProgressRadialBehaviour radialScript;

    private IEnumerator coroutine;
    public int ScoreUp = 7;

    public Text ScoreText;

    [HideInInspector]
    public float score = 0.0f;

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
        ScoreText.text = score + "";

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

    public void decreaseTimeWithShoot()
    {
        radialScript.DecrementValue(2);
    }

    public void increaseScore()
    {
        if(score == 99.5f)
        {
            score = 100.0f;
            ScoreText.text = "ATH";
        }
        else
        {
            score = score + 0.5f;
            ScoreText.text = score + "";
        }
        

        radialScript.IncrementValue(ScoreUp);
        
    }
}
