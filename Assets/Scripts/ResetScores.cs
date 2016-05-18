using UnityEngine;
using System.Collections;

public class ResetScores : MonoBehaviour {

	// Use this for initialization
	void Start () {

        PlayerPrefs.SetInt("P1SCORE", 0);
        PlayerPrefs.SetInt("P2SCORE", 0);
        PlayerPrefs.SetInt("P3SCORE", 0);
        PlayerPrefs.SetInt("P4SCORE", 0);
        PlayerPrefs.SetInt("CURRENTROUND", 0);
        PlayerPrefs.SetInt("Paused", 0);
        PlayerPrefs.Save();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
