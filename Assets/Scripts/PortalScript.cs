using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {

    public GameObject outPortal;
    public float dist = 0.25f;
    public bool horizontal = false;
    public bool outLeft = true;
    public bool outUp = true;

    public bool GetHor()
    {
        return horizontal;
    }

	void OnTriggerEnter2D (Collider2D other){
        if (other.tag.Contains("Player") || other.tag.Contains("Bullet"))
        {            
            if (!horizontal)
            {
                if (outLeft)
                {
                    other.transform.position = new Vector2(outPortal.transform.position.x - dist,
                                                           outPortal.transform.position.y);
                }
                else
                {                    
                    other.transform.position = new Vector2(outPortal.transform.position.x + dist,
                                                           outPortal.transform.position.y);
                }
            }
            else
            {
                if (outUp && outLeft)
                {
                    other.transform.position = new Vector2(outPortal.transform.position.x - dist/2,
                                                           outPortal.transform.position.y + dist);
                }
                else if (outUp && !outLeft)
                {
                    other.transform.position = new Vector2(outPortal.transform.position.x + dist/2,
                                                           outPortal.transform.position.y + dist);
                }
                else if (!outUp && outLeft)
                {
                    other.transform.position = new Vector2(outPortal.transform.position.x - dist/2,
                                                           outPortal.transform.position.y - dist);
                }
                else if (!outUp && !outLeft)
                {
                    other.transform.position = new Vector2(outPortal.transform.position.x + dist/2,
                                                           outPortal.transform.position.y - dist);
                }
            }

        }
    }
}
