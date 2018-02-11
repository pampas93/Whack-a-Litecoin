using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScript : MonoBehaviour {

    // the image you want to fade, assign in inspector
    public Image img;

    private void Start()
    {
        StartCoroutine(FadeImage(false));
        StartCoroutine(fadingGap());
        StartCoroutine(startGame());
    }


    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime / 3)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;

            }

            //Move to NextScene
            Debug.Log("Time to move?");
            
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime / 2)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }

    IEnumerator fadingGap()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(FadeImage(true));
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadSceneAsync("MiningScene");
        //SceneManager.LoadScene("MiningScene", LoadSceneMode.Single);
    }
}
