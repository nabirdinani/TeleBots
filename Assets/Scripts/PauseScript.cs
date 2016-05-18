using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour{

    public GameObject pauseCanvas;

    public bool paused = false;

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("RedOptions") || Input.GetButtonDown("BlueOptions") || Input.GetButtonDown("YellowOptions") || Input.GetButtonDown("GreenOptions"))
        {
            Pause();
        }
	}

    public void Pause()
    {
        if (!paused)
        {
            PlayerPrefs.SetInt("Paused", 1);
            paused = true;
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PlayerPrefs.SetInt("Paused", 0);
            paused = false;
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
