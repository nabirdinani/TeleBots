using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using stateEnum;

public class PlayerScript : MonoBehaviour {


    public State state;

    public float jumpForce;
	public float maxSpeed;
    public float distance;
    public float spawnDelay = 2f;
    public string color;
    public int paused = 0;

	public bool tele = false;    

    public GameObject illusion;
    public GameObject gun;
    public GameObject particles;
    public GameObject halo;

    public AudioClip dieAudio, shieldAudio;

	bool facingRight = true;

	Animator anim;

	float move;
	float currentPos;
	float previousPos;
	float initialPos;
    
    bool jump = false;
    bool jumped = false;
    bool grounded = false;
    bool crouch = false;
    bool shield = false;
    
    int health = 0;

    Vector3 respawnPoint;

    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    void Awake()
    {
        state = State.ALIVE;

        int redReady = PlayerPrefs.GetInt("RED");
        int blueReady = PlayerPrefs.GetInt("BLUE");
        int yellowReady = PlayerPrefs.GetInt("YELLOW");
        int greenReady = PlayerPrefs.GetInt("GREEN");

        if (color == "Red")
        {
            if (redReady == 0)
            {
                ChangeState();
                Destroy(illusion);
                Destroy(this.gameObject);
            }
        }
        else if (color == "Blue")
        {
            if (blueReady == 0)
            {
                ChangeState();
                Destroy(illusion);
                Destroy(this.gameObject);
            }
        }
        else if (color == "Yellow")
        {
            if (yellowReady == 0)
            {
                ChangeState();
                Destroy(illusion);
                Destroy(this.gameObject);
            }
        }
        else if (color == "Green")
        {
            if (greenReady == 0)
            {
                ChangeState();
                Destroy(illusion);
                Destroy(this.gameObject);
            }
        }
    }

	void Start()
    {
        respawnPoint = transform.position;

		anim = GetComponent<Animator> ();

        paused = PlayerPrefs.GetInt("Paused");
	}


	void FixedUpdate () 
    {
        paused = PlayerPrefs.GetInt("Paused");
        if (paused != 1)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            move = Input.GetAxis(color + "LHorizontal");

            GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed * move, GetComponent<Rigidbody2D>().velocity.y);

            anim.SetFloat("hSpeed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
            if (illusion != null)
                illusion.GetComponent<Animator>().SetFloat("hSpeedFollow", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

            if (!crouch && !jump && Input.GetAxis(color + "LVertical") > 0)
            {
                jump = true;
                jumped = false;
            }

            if (!crouch && grounded && jump && !jumped)
            {
                anim.SetTrigger("Jump");
                illusion.GetComponent<Animator>().SetTrigger("JumpFollow"); //actually the jump animation for the shadow
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                jumped = true;
            }

            if (grounded && jumped && Input.GetAxis(color + "LVertical") < 1)
            {
                jump = false;
                jumped = false;
            }

            if (!crouch && Input.GetAxis(color + "LVertical") < 0)
            {
                crouch = true;
            }
            else if (crouch && Input.GetAxisRaw(color + "LVertical") >= 0)
            {
                StartCoroutine(StandUp());
            }

            anim.SetBool("Crouch", crouch);

            if (crouch)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                GetComponent<BoxCollider2D>().size = new Vector2(0.98f, 1.89f);
                GetComponent<BoxCollider2D>().offset = new Vector2(0.45f, 0f);

                if (gun != null)
                    gun.transform.localPosition = new Vector3(0.57f, 0.341f, 0f);
            }
            else
            {
                GetComponent<CircleCollider2D>().enabled = true;
                GetComponent<BoxCollider2D>().size = new Vector2(0.49f, 1.86f);
                GetComponent<BoxCollider2D>().offset = new Vector2(-0.03f, 0.34f);

                if (gun != null)
                    gun.transform.localPosition = new Vector3(0.092f, 0.68f, 0f);
            }

            if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();
        }
	}

	void Update(){
        paused = PlayerPrefs.GetInt("Paused");
        if (paused != 1)
        {
            if (transform.position.x > 0)
            {
                tele = true;
            }
            else
            {
                tele = false;
            }

            if (Input.GetButtonDown(color + "X") || Input.GetButtonDown(color + "AnalogButton"))
            {
                bool allowed = illusion.GetComponent<IllusionScript>().teleportAllowed;
                if (allowed)
                {
                    gun.GetComponent<SpriteRenderer>().enabled = false;
                    anim.SetTrigger("Teleport");
                }
            }

            if (shield)
            {
                halo.SetActive(true);
            }
            else
            {
                GetComponent<AudioSource>().clip = dieAudio;
                halo.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;        
	}

	public void Teleport(){            
        if (!tele)
        {
            transform.position = new Vector3((transform.position.x + distance), (transform.position.y), (transform.position.z));
            tele = true;                    
        }
        else 
        {
            transform.position = new Vector3((transform.position.x - distance), (transform.position.y), (transform.position.z));
            tele = false;                    
        }
        
	}

    public void DoTeleport()
    {
        Teleport();
        gun.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void DoDestroy()
    {        
        Destroy(gameObject);        
    }

    public void DestroyGun()
    {
        Destroy(gun);
    }

    public void ChangeState()
    {
        state = State.DEAD;
    }

    public bool getFacingRight()
    {
        return facingRight;
    }

    public void setFacingRight(bool newFacing)
    {
        facingRight = newFacing;
    }

    IEnumerator StandUp()
    {                
        yield return new WaitForSeconds (0.2f);
        crouch = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Burst")
        {            
            gun.GetComponent<ShootScript>().burst();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Shield")
        {            
            shield = true;
            GetComponent<AudioSource>().clip = shieldAudio;
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject, shieldAudio.length/50);            
        }

        if (collision.gameObject.tag == "Health")
        {
            health++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Lava")
        {
            GetComponent<AudioSource>().Play();
            Destroy(GameObject.FindGameObjectWithTag(this.tag.Substring(0, 3) + "Illusion"));
            DestroyGun();
            ChangeState();
            GetComponent<Animator>().SetTrigger("Die");
        }
    }

    public void SetShield(bool s)
    {
        shield = s;
    }

    public bool GetShield()
    {
        return shield;
    }

    public void DecreamentHealth()
    {
        health--;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Respawn()
    {
        //StartCoroutine(RespawnEffect());        
        transform.position = respawnPoint;
        GameObject spawnParticles = Instantiate(particles, transform.position, Quaternion.identity) as GameObject;
        Destroy(spawnParticles, 2f);
    }

    IEnumerator RespawnEffect()
    {
        yield return new WaitForSeconds(spawnDelay);

        GameObject spawnParticles = Instantiate(particles, transform.position, Quaternion.identity) as GameObject;
        Destroy(spawnParticles, 3f);
    }
}
