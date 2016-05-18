using UnityEngine;
using System.Collections;

public class IllusionScript : MonoBehaviour {

	bool teleportation;    

    public float distance;
    public bool teleportAllowed = true;
    public PlayerScript player;
    public GameObject gun;
    public GameObject playerGun;
    public Color c;
    public float transparncy = .2f;

	Animator anim;
    SpriteRenderer sprite;    
    bool red = false;

	void Start(){
		anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();        
        switch(player.GetComponent<PlayerScript>().color)
        {
            case "Red":
                c = new Color(1f, 0f, 0f, transparncy);
                break;
            case "Blue":
                c = new Color(0f, 0f, 1f, transparncy);
                break;
            case "Yellow":
                c = new Color(1f, 1f, 0f, transparncy);
                break;
            case "Green":
                c = new Color(0f, 1f, 0f, transparncy);
                break;
            default:
                c = Color.black;
                break;
        }
    }

	void Update () {
        if (!red)
        {
            sprite.color = c;
            gun.GetComponent<SpriteRenderer>().color = c;
        }

        gun.transform.rotation = playerGun.transform.rotation;

		teleportation = player.tele;        
        if (!teleportation)
        {
            transform.position = new Vector3((player.transform.position.x + distance),
                                             (player.transform.position.y),
                                             (player.transform.position.z));
        }
        else 
        {
            transform.position = new Vector3((player.transform.position.x - distance),
                                             (player.transform.position.y),
                                             (player.transform.position.z));
        }

        Vector3 theScale = transform.localScale;
        theScale.x = player.transform.localScale.x;
        transform.localScale = theScale;
	}

    void OnTriggerStay2D (Collider2D other){
        if (other.tag == "Block")
        {
            teleportAllowed = false;
            red = true;
            sprite.color = Color.red;
            gun.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Block")
        {
            teleportAllowed = true;
            red = false;
        }
    }
}
