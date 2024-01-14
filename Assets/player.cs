using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

	public GameObject red;
	public float speed;
	public bool IsBlue;
	public GameObject up;
	public GameObject down;
	public GameObject left;
	public GameObject right;
	public GameObject directions;
	private bool isUp;
	private bool isDown;
	private bool isLeft;
	private bool isRight;
	public void RedTrigger(Collider2D other, string type)
	{
		if (type == "enter") OnTriggerEnter2D(other);
		if (type == "exit") OnTriggerExit2D(other);
	}
	private void OnTriggerEnter2D(Collider2D other) {
		//if (IsBlue) {
		if (GameObject.ReferenceEquals(up, other.gameObject)) isUp = true;
		if (GameObject.ReferenceEquals(down, other.gameObject)) isDown = true;
		if (GameObject.ReferenceEquals(left, other.gameObject)) isLeft = true;
		if (GameObject.ReferenceEquals(right, other.gameObject)) isRight = true;
		//}
	}

	private void OnTriggerExit2D(Collider2D other) {
		//if (IsBlue) {
		if (GameObject.ReferenceEquals(up, other.gameObject)) isUp = false;
		if (GameObject.ReferenceEquals(down, other.gameObject)) isDown = false;
		if (GameObject.ReferenceEquals(left, other.gameObject)) isLeft = false;
		if (GameObject.ReferenceEquals(right, other.gameObject)) isRight = false;
		//}
	}

	void hit() {
		if (SceneManager.GetActiveScene().name == "Lobby")
		{
			if (IsBlue)
			{
				if (isUp) {
					transform.position = up.transform.position;
					directions.GetComponent<lobbygrid>().move(directions.transform.position + new Vector3(0,(float)1.5,0));
				}
				if (isDown) {
					transform.position = down.transform.position;
					directions.GetComponent<lobbygrid>().move(directions.transform.position - new Vector3(0,(float)1.5,0));
				}
				if (isLeft) {
					transform.position = left.transform.position;
					directions.GetComponent<lobbygrid>().move(directions.transform.position - new Vector3((float)1.5,0,0));
				}
				if (isRight) {
					transform.position = right.transform.position;
					directions.GetComponent<lobbygrid>().move(directions.transform.position + new Vector3((float)1.5,0,0));
				}
				if (isUp || isDown || isLeft || isRight) IsBlue = !IsBlue;
				if (isUp) isUp = false;
				if (isDown) isDown = false;
				if (isLeft) isLeft = false;
				if (isRight) isRight = false;
			} else {
				if (isUp) {
					red.transform.position = up.transform.position;
					directions.transform.position = directions.transform.position + new Vector3(0,(float)1.5,0);
				}
				if (isDown) {
					red.transform.position = down.transform.position;
					directions.transform.position = directions.transform.position - new Vector3(0,(float)1.5,0);
				}
				if (isLeft) {
					red.transform.position = left.transform.position;
					directions.transform.position = directions.transform.position - new Vector3((float)1.5,0,0);
				}
				if (isRight) {
					red.transform.position = right.transform.position;
					directions.transform.position = directions.transform.position + new Vector3((float)1.5,0,0);
				}
				if (isUp || isDown || isLeft || isRight) IsBlue = !IsBlue;
				if (isUp) isUp = false;
				if (isDown) isDown = false;
				if (isLeft) isLeft = false;
				if (isRight) isRight = false;
			}
		}
		else
		{
			
		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (IsBlue == true) transform.RotateAround(red.transform.position, Vector3.back, speed * Time.deltaTime);
		if (IsBlue == false) red.transform.RotateAround(transform.position, Vector3.back, speed * Time.deltaTime);
		if (GamePad.GetButtonTrigger(N3dsButton.A) || Input.GetKeyDown("a")) hit(); 
	}
}
