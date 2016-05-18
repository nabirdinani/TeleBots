using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonsScript : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene(5);
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
#if UNITY_STANDALONE
        // Quit the application
        Application.Quit();
#endif



        // If we are running in the editor
#if UNITY_EDITOR
        // Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ThreeRounds()
    {
        PlayerPrefs.SetInt("NUMROUNDS", 3);
        PlayerPrefs.Save();
        SceneManager.LoadScene(4);
    }

    public void FiveRounds()
    {
        PlayerPrefs.SetInt("NUMROUNDS", 5);
        PlayerPrefs.Save();
        SceneManager.LoadScene(4);
    }

    public void TenRounds()
    {
        PlayerPrefs.SetInt("NUMROUNDS", 10);
        PlayerPrefs.Save();
        SceneManager.LoadScene(4);
    }

    public void BackToMain()
    {
        PlayerPrefs.SetInt("Paused", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        Camera.main.GetComponent<PauseScript>().Pause();
    }
}
