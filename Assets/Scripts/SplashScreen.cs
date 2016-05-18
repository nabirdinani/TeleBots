using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Wait());
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
