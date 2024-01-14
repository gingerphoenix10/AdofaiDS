using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redplayer : MonoBehaviour {
	public GameObject blue; 
	private void OnTriggerEnter2D(Collider2D other) {
		blue.GetComponent<player>().RedTrigger(other, "enter");
	}
	private void OnTriggerExit2D(Collider2D other) {
		blue.GetComponent<player>().RedTrigger(other, "exit");
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
