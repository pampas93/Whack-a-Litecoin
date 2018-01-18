using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        
    }

    // Use this for initialization
    void Start () {

        VRSettings.enabled = false;
        Camera.main.ResetAspect();
        Camera.main.GetComponent<Transform>().localRotation = InputTracking.GetLocalRotation(VRNode.CenterEye);

    }
	
	// Update is called once per frame
	void Update () {

        Camera.main.GetComponent<Transform>().localRotation = InputTracking.GetLocalRotation(VRNode.CenterEye);
    }
}
