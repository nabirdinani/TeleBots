using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndScript : MonoBehaviour {

    int numRounds = 0;

    public Text winText;

	// Use this for initialization
	void Start () 
    {
        numRounds = PlayerPrefs.GetInt("NUMROUNDS");

        if (numRounds == PlayerPrefs.GetInt("P1SCORE"))
        {
            winText.text = "Red Wins!";
        }
        else if (numRounds == PlayerPrefs.GetInt("P2SCORE"))
        {
            winText.text = "Blue Wins!";
        }
        else if (numRounds == PlayerPrefs.GetInt("P3SCORE"))
        {
            winText.text = "Yellow Wins!";
        }
        else if (numRounds == PlayerPrefs.GetInt("P4SCORE"))
        {
            winText.text = "Green Wins!";
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        StartCoroutine(Wait());        
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }
}
