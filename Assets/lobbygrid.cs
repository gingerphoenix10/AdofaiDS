using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lobbygrid : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		UnityEngine.Debug.Log(other.gameObject.name);
	}

	public void move(Vector3 coords) {
		if (gameObject.name == "Directions")
		{
			transform.position = coords;
		}
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
