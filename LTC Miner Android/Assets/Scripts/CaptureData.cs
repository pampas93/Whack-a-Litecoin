using UnityEngine;

public class CaptureData : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

//public class CaptureData : MonoBehaviour
//{

//    // Update is called once per frame
//    void Update()
//    {

//        try
//        {
//            WebClient client = new WebClient();
//            string url = "http://localhost:3000/captureData";
//            string jsonResponse = client.DownloadString(url);

//            var dataFromServer = JSON.Parse(jsonResponse);

//            var mode = dataFromServer["mode"];

//            if (mode != Settings.instance.Mode)
//            {
//                Settings.instance.ChangeSky(mode);
//            }

//            //Debug.Log(x["mode"]);
//            //Console.WriteLine(jsonResponse);
//        }
//        catch (WebException ex)
//        {
//            //Debug.Log("Exception Occured");
//            //Console.WriteLine("Exception occured");
//        }
//    }
//}