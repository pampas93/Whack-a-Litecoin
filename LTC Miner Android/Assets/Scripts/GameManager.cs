using UnityEngine;
using UnityEngine.VR;
using ProgressBar;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public ProgressBarBehaviour barScript;
    public ProgressRadialBehaviour radialScript;

    private IEnumerator coroutine;

    public bool timeUp = false;

    private void Awake()
    {
        instance = this;
        
    }

    // Use this for initialization
    void Start () {

        VRSettings.enabled = false;
        Camera.main.ResetAspect();
        Camera.main.GetComponent<Transform>().localRotation = InputTracking.GetLocalRotation(VRNode.CenterEye);

        barScript.IncrementValue(100);
        radialScript.IncrementValue(100);

        coroutine = timeCoroutine();
        StartCoroutine(coroutine);

    }
	
	// Update is called once per frame
	void Update () {

        Camera.main.GetComponent<Transform>().localRotation = InputTracking.GetLocalRotation(VRNode.CenterEye);
    }

    IEnumerator timeCoroutine()
    {
        while (!timeUp)
        {
            if (barScript.Value == 0)
                timeUp = true;

            barScript.DecrementValue(2);
            radialScript.DecrementValue(2);
            yield return new WaitForSeconds(1);
        }

        Debug.Log("TimeUp");
        
    }
}
