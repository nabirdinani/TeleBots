using UnityEngine;
using System.Collections;

public class scrollQuad : MonoBehaviour {

	public float scrollSpeed = 0.2f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (0, Time.time * scrollSpeed);
		GetComponent<Renderer>().material.mainTextureOffset = offset;

	}
}

