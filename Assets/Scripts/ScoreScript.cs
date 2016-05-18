using UnityEngine;
using System.Collections;
using stateEnum;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {

	int p1Score;
	int p2Score;
	int p3Score;
	int p4Score;
    int currRound;
    int numRounds;

    bool end = false;

	public PlayerScript p1;
	public PlayerScript p2;
	public PlayerScript p3;
	public PlayerScript p4;

	// Use this for initialization
	void Start () {
        p1Score = PlayerPrefs.GetInt("P1SCORE");
        p2Score = PlayerPrefs.GetInt("P2SCORE");
        p3Score = PlayerPrefs.GetInt("P3SCORE");
        p4Score = PlayerPrefs.GetInt("P4SCORE");
        currRound = PlayerPrefs.GetInt("CURRENTROUND");
        numRounds = PlayerPrefs.GetInt("NUMROUNDS");
    }

	// Update is called once per frame
	void Update () {
		if(p1.state == State.DEAD && p2.state == State.DEAD && p3.state == State.DEAD && !end)
		{            
			p4Score += 1;
            PlayerPrefs.SetInt("P4SCORE", p4Score);
            PlayerPrefs.SetInt("CURRENTROUND", currRound);
            PlayerPrefs.Save();
            end = true;
            StartCoroutine(Wait());              
            }
		else if(p1.state == State.DEAD && p2.state == State.DEAD && p4.state == State.DEAD && !end)
		{
			p3Score += 1;			
            PlayerPrefs.SetInt("P3SCORE", p3Score);
            PlayerPrefs.SetInt("CURRENTROUND", currRound);
            PlayerPrefs.Save();
            end = true;
            StartCoroutine(Wait());                             
            }
        else if (p1.state == State.DEAD && p4.state == State.DEAD && p3.state == State.DEAD && !end)
		{
			p2Score += 1;
            PlayerPrefs.SetInt("P2SCORE", p2Score);
            PlayerPrefs.SetInt("CURRENTROUND", currRound);
            PlayerPrefs.Save();
            end = true;
            StartCoroutine(Wait());              
            }
        else if (p4.state == State.DEAD && p2.state == State.DEAD && p3.state == State.DEAD && !end)
		{
			p1Score += 1;
            PlayerPrefs.SetInt("P1SCORE", p1Score);
            PlayerPrefs.SetInt("CURRENTROUND", currRound);
            PlayerPrefs.Save();
            end = true;
            StartCoroutine(Wait());              
        }
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}
