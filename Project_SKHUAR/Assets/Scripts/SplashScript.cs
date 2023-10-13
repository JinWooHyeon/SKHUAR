using UnityEngine;
using System.Collections;

public class SplashScript : MonoBehaviour {
    float DelayTime = 3;

	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(DelayTime);

        UnityEngine.SceneManagement.SceneManager.LoadScene("ImageTracking");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
