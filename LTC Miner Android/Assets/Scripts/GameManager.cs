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

    public Material[] skies;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {

        StartCoroutine(LoadDevice("cardboard"));

        System.Random random = new System.Random();
        int rno = random.Next(0, skies.Length+1);
        RenderSettings.skybox = skies[rno];

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
        //Debug.Log(Camera.main.transform.rotation.eulerAngles.y);
        float y_angle = Camera.main.transform.rotation.eulerAngles.y;

        if((y_angle > 257 && y_angle < 292.54) || (y_angle > 93.5 && y_angle < 128))
        {
            //Pause the timer
            if(coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            } 
        }
        else
        {
            if(coroutine == null)
            {
                coroutine = timeCoroutine();
                StartCoroutine(coroutine);
            }
        }
        
    }

    IEnumerator timeCoroutine()
    {
        while (!timeUp)
        {
            if (radialScript.Value == 0)
                timeUp = true;

            radialScript.DecrementValue(2);
            yield return new WaitForSeconds(1);
        }
        Debug.Log("TimeUp");
    }

    public void decreaseTimeWithShoot()
    {
        radialScript.DecrementValue(2);
    }

    public void increaseTimeWithShoot()
    {
        radialScript.DecrementValue(3);
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
