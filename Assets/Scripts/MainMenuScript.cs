using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    Image mainMenuImage;
    public Sprite menu_beta_1;
    public Sprite menu_beta_2;
    public Sprite menu_beta_3;

    public int creditsScreen = 4;
    public int optionsScreen = 6;

    // Use this for initialization
    void Start () {
        mainMenuImage = GetComponent<Image>();
	}

    void startImage ()
    {
        mainMenuImage.sprite = menu_beta_1;
    }

    void quitImage ()
    {
        mainMenuImage.sprite = menu_beta_2;
    }

    void creditsImage()
    {
        mainMenuImage.sprite = menu_beta_3;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("left"))
        {
            startImage();
        }

        if (Input.GetKeyDown("right"))
        {
            quitImage();
        }

        if (Input.GetKeyDown("down"))
        {
            creditsImage();
        }


        if (Input.GetKeyDown("x"))
        {
            if (mainMenuImage.sprite == menu_beta_1)
            {
                SceneManager.LoadScene(optionsScreen);
            }

            if (mainMenuImage.sprite == menu_beta_2)
            {
                //Application.Quit();
                //UnityEditor.EditorApplication.isPlaying = false;
                // If we are running in a standalone build of the game
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

            if (mainMenuImage.sprite == menu_beta_3)
            {
                SceneManager.LoadScene(creditsScreen);
            }
        }

    }
}
