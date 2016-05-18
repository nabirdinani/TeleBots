using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

    public AudioClip music1, music2, music3;

    void Awake()
    {
        int choice = Random.Range(1, 4);        

        if (choice == 1)
        {
            GetComponent<AudioSource>().clip = music1;
        }
        else if (choice == 2)
        {
            GetComponent<AudioSource>().clip = music2;
        }
        else if (choice == 3)
        {
            GetComponent<AudioSource>().clip = music3;
        }

        GetComponent<AudioSource>().Play();
    }
}
