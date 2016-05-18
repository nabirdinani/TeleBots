using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

    public Text timerText;

    public float time = 10f;

    public GameObject red, blue, yellow, green;

    public static int numPlayers = 0;

    void Start()
    {
        time = 10f;

        PlayerPrefs.SetInt("RED", 0);
        PlayerPrefs.SetInt("BLUE", 0);
        PlayerPrefs.SetInt("YELLOW", 0);
        PlayerPrefs.SetInt("GREEN", 0);
    }
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("RedX"))
        {
            red.SetActive(true);
            PlayerPrefs.SetInt("RED", 1);
            numPlayers++;
        }

        if (Input.GetButtonDown("BlueX"))
        {
            blue.SetActive(true);
            PlayerPrefs.SetInt("BLUE", 1);
            numPlayers++;
        }

        if (Input.GetButtonDown("YellowX"))
        {
            yellow.SetActive(true);
            PlayerPrefs.SetInt("YELLOW", 1);
            numPlayers++;
        }

        if (Input.GetButtonDown("GreenX"))
        {
            green.SetActive(true);
            PlayerPrefs.SetInt("GREEN", 1);
            numPlayers++;
        }

        //Update timer
        if (time >= 0)
        {

            timerText.text = time.ToString().Substring(0,1);

            time -= Time.deltaTime;
        }
        else
        {
            int numRounds = PlayerPrefs.GetInt("NUMROUNDS");            
            SceneManager.LoadScene(Random.Range(7, 18));
        }
	}
}
