using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsToMain : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("RedCircle"))
        {
            SceneManager.LoadScene(1);
        }
	}

}
