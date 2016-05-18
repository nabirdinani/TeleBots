using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ArrowScript : MonoBehaviour {

    float pos;
    bool move = true;
	
	// Update is called once per frame
	void Update () {
        pos = transform.position.y;    

        if (Input.GetAxis("RedLVertical") > 0 && pos != 1 && move)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            move = false;
            StartCoroutine(ChangeMoveValue());
        }

        if (Input.GetAxis("RedLVertical") < 0 && pos != -3 && move)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
            move = false;
            StartCoroutine(ChangeMoveValue());
        }

        if (Input.GetButtonDown("RedCircle"))
        {
            SceneManager.LoadScene(1);
        }
	}

    IEnumerator ChangeMoveValue()
    {
        yield return new WaitForSeconds(0.25f);
        move = true;
    }
}
