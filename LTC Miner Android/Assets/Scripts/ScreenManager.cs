using UnityEngine;
using SimpleJSON;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;

public class ScreenManager : MonoBehaviour {

    [HideInInspector]
    public bool downloadedData = false;

    JSONNode data;
    int count;
    public string url = "https://litecoinproject-361b7.firebaseio.com/Litecoin.json";
    private string raw_data;

    bool screen1_video = false;

    public Text text_Screen1;
    public Text text_Screen2;

    public GameObject screen1_canvas;
    public GameObject video_screen1;

    public GameObject VideoPlayer;

    public VideoClip video_1;
    public VideoClip video_2;
    public AudioClip audio_1;
    public AudioClip audio_2;

    public static ScreenManager instance;

    System.Random random;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        random = new System.Random();
        StartCoroutine(downloadData());

    }

    IEnumerator downloadData()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;

            raw_data = www.text;
            data = JSON.Parse(raw_data);
            count = data["count"];

            downloadedData = true;
        }
    }

    public void NewScreen(GameObject parent_screen)
    {
        if (!downloadedData)
        {
            return;
        }

        Debug.Log(count);
        int rno = random.Next(0, count);

        string type = data[rno]["type"];
        string value = data[rno]["value"];

        if (type.Equals("video") && parent_screen.name == "Screen1")
        {
            if (screen1_video)
                return;
            else
            {
                video_screen1.SetActive(true);
                screen1_canvas.SetActive(false);

                PlayVideo(value);
            }
        }
        else if(type.Equals("information"))
        {
            if(parent_screen.name == "Screen1")
            {
                screen1_video = false;
                video_screen1.SetActive(false);
                screen1_canvas.SetActive(true);

                stopVideo();

                text_Screen1.text = value;
            }
            else if(parent_screen.name == "Screen2")
            {
                text_Screen2.text = value;
            }
        }
        
        Debug.Log(parent_screen.name);
        Debug.Log(data[rno]);
    }

    public void PlayVideo(string name)
    {
        var x = VideoPlayer.GetComponent<VideoPlayer>();
        var y = VideoPlayer.GetComponent<AudioSource>();

        if (x.source.ToString().Equals(name))
            return;

        switch (name)
        {
            case "video_1":
                x.clip = video_1;
                y.clip = audio_1;
                break;
            case "video_2":
                x.clip = video_2;
                y.clip = audio_2;
                break;
            default:
                break;
        }

        x.Play();
        y.Play();
    }

    public void stopVideo()
    {
        var v = VideoPlayer.GetComponent<VideoPlayer>();
        var a = VideoPlayer.GetComponent<AudioSource>();

        v.Stop();
        a.Stop();

        v.clip = null;
        a.clip = null;
    }

}
