using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour {

    public int numOfRounds;
    public Text select3Rounds;
    public Text select5Rounds;
    public Text select10Rounds;
    public Text selectPlay;

    // Use this for initialization
    void Start () {
        numOfRounds = 3;
	
	}
	
	// Update is called once per frame
	void Update () {

        if(selectPlay.text == ">")
        {
            if (Input.GetKeyDown("x"))
            {
                SceneManager.LoadScene(Random.Range(1, 4));
            }

            else if (Input.GetKeyDown("o"))
            {
                selectPlay.text = "";
                select3Rounds.text = "^";
            }
        }

        else if(select3Rounds.text == "^")
        {
            if (Input.GetKeyDown("x"))
            {
                PlayerPrefs.SetInt("NUMROUNDS", 3);
                select3Rounds.text = "";
                selectPlay.text = ">";
            }

            else if (Input.GetKeyDown("right"))
            {
                select5Rounds.text = "^";
                select3Rounds.text = "";
            }
        }

        else if (select5Rounds.text == "^")
        {
            if (Input.GetKeyDown("x"))
            {
                PlayerPrefs.SetInt("NUMROUNDS", 5);
                select5Rounds.text = "";
                selectPlay.text = ">";
            }

            else if (Input.GetKeyDown("left"))
            {
                select3Rounds.text = "^";
                select5Rounds.text = "";
            }

            else if (Input.GetKeyDown("right"))
            {
                select10Rounds.text = "^";
                select5Rounds.text = "";
            }
        }

        else if (select10Rounds.text == "^")
        {
            if (Input.GetKeyDown("x"))
            {
                PlayerPrefs.SetInt("NUMROUNDS", 10);
                select10Rounds.text = "";
                selectPlay.text = ">";
            }

            else if (Input.GetKeyDown("left"))
            {
                select5Rounds.text = "^";
                select10Rounds.text = "";
            }
        }

    }
}
