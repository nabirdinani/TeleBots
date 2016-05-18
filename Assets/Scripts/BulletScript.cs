using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    void Awake()
    {
        GetComponent<AudioSource>().Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Substring(0, 3) != this.tag.Substring(0, 3))
        {
            if (other.tag.Contains("Player"))
            {
                if (!other.GetComponent<PlayerScript>().GetShield() && other.GetComponent<PlayerScript>().GetHealth() == 0)
                {
                    other.GetComponent<AudioSource>().Play();
                    Destroy(GameObject.FindGameObjectWithTag(other.tag.Substring(0, 3) + "Illusion"));
                    other.GetComponent<PlayerScript>().DestroyGun();
                    other.GetComponent<PlayerScript>().ChangeState();
                    other.GetComponent<Animator>().SetTrigger("Die");                                      
                }
                else if (other.GetComponent<PlayerScript>().GetShield())
                {
                    other.GetComponent<PlayerScript>().SetShield(false);
                }
                else if (other.GetComponent<PlayerScript>().GetHealth() > 0)
                {
                    other.GetComponent<PlayerScript>().DecreamentHealth();
                    other.GetComponent<PlayerScript>().Respawn();
                }
            }

            if (other.tag != "Portal" && !other.tag.Contains("Illusion"))
            {
                Destroy(this.gameObject);
            }
            else if (other.tag == "Portal")
            {
                if (other.GetComponent<PortalScript>().GetHor())
                {
                    //transform.Rotate(0f, 90f, 0f);
                    GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -700f));
                }
            }
                     
        }
    }
}
