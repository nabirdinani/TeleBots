using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowScores : MonoBehaviour {

    public Text player1Score;
    public Text player2Score;
    public Text player3Score;
    public Text player4Score;    

    int maxWins;

    // Use this for initialization
    void Start () {
        player1Score.text = "RED: " + PlayerPrefs.GetInt("P1SCORE");
        player2Score.text = "BLUE: " + PlayerPrefs.GetInt("P2SCORE");
        player3Score.text = "YELLOW: " + PlayerPrefs.GetInt("P3SCORE");
        player4Score.text = "GREEN: " + PlayerPrefs.GetInt("P4SCORE");

        maxWins = Mathf.Max(PlayerPrefs.GetInt("P1SCORE"), PlayerPrefs.GetInt("P2SCORE"), PlayerPrefs.GetInt("P3SCORE"), PlayerPrefs.GetInt("P4SCORE"));
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("RedX") || Input.GetButtonDown("BlueX") || Input.GetButtonDown("YellowX") || Input.GetButtonDown("GreenX"))
        {
            if (maxWins >= PlayerPrefs.GetInt("NUMROUNDS"))
            {
                SceneManager.LoadScene("EndScene");
            }
            else
            {
                SceneManager.LoadScene(Random.Range(7, 18));
            }
        }
	
	}
}
