using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class ShootScript : MonoBehaviour {

	// Use this for initialization
	public GameObject bullet;	
    public float bulletSpeed = 700f;
	public string color;
    bool playerFacingRight = true;
    bool gunFacingRight = true;
    float offset = 90f;
    int paused = 0;

    //ALL TIMER MATH IS DONE IN MILLISECONDS 1000 milliseconds = 1 second
    Stopwatch timer;
    const int cooldown = 2500;
    const int overheatLimit = 2000;
    const int heatNum = 667;
    int currentHeat;
    double overModify = 1;
    bool overheat = false;
    Animator anim;

    public GameObject halo;
	
	void Start () {
        anim = GetComponent<Animator>();
        timer = new Stopwatch();
        paused = PlayerPrefs.GetInt("Paused");
	}
	
	// Update is called once per frame
	void Update () {
        paused = PlayerPrefs.GetInt("Paused");
        if (paused != 1)
        {
            playerFacingRight = GetComponentInParent<PlayerScript>().getFacingRight();

            if (playerFacingRight)
            {
                offset = 90f;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                offset = -90f;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }


            if (Input.GetAxis(color + "AnalogX") != 0 || Input.GetAxis(color + "AnalogY") != 0)
            {
                var angle = Mathf.Atan2(Input.GetAxis(color + "AnalogX"), Input.GetAxis(color + "AnalogY")) * Mathf.Rad2Deg - offset;
                if (playerFacingRight)
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                else
                    transform.rotation = Quaternion.Euler(0, 0, -angle);
            }

            // constant timer monitor
            if (timer.IsRunning)
            {
                if (currentHeat >= overheatLimit * overModify)
                {

                    if (timer.ElapsedMilliseconds > overheatLimit * overModify)
                    {
                        timer.Reset();
                        currentHeat = 0;
                        overheat = false;
                        halo.SetActive(false);
                    }
                }
                else if (timer.ElapsedMilliseconds >= currentHeat)
                {

                    currentHeat = 0;
                    timer.Reset();
                }
            }

            if (Input.GetButtonDown(color + "RTrigger") && !overheat)
            {
                GameObject bul;
                double rotationDegrees;

                anim.SetTrigger("Shoot");

                if (playerFacingRight)
                {
                    bul = (Instantiate(bullet, transform.position, transform.rotation)) as GameObject;
                    rotationDegrees = transform.rotation.eulerAngles.z;
                }
                else
                {
                    bul = (Instantiate(bullet, transform.position, transform.rotation)) as GameObject;
                    rotationDegrees = 180 - transform.rotation.eulerAngles.z;
                }

                //find the x, y directional magnitudes
                float xMagnitude = (float)System.Math.Cos((System.Math.PI / 180) * rotationDegrees);
                float yMagnitude = (float)System.Math.Sin((System.Math.PI / 180) * rotationDegrees);
                //apply the force
                bul.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed * xMagnitude, bulletSpeed * yMagnitude));

                // cooldown math
                currentHeat += heatNum;
                if (currentHeat > overheatLimit * overModify)
                {
                    overheat = true;
                    halo.SetActive(true);
                }

                if (!timer.IsRunning)
                    timer.Start();
            }
        }
	}
    public void burst()
    {
        overModify = 2;        
    }
    public void Flip()
    {        
        gunFacingRight = !gunFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}