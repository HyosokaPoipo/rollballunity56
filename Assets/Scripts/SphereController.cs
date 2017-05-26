using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public GUIText score;
	public GUIText win;
	private int targetHit;

	private void showText() {
		score.text = "Point : "+targetHit.ToString ();
		if (targetHit >= 13) {
			win.text = "Congratulations...!\n You Wiiin...!";
		}
	}
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		targetHit = 0;
		win.text = "";
		showText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		float horizontalValue = Input.GetAxis ("Horizontal");
		float verticalValue = Input.GetAxis ("Vertical");

		Vector3 v3 = new Vector3 (horizontalValue, 0.0f, verticalValue);
		rb.AddForce (v3 * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider obj) {		
		if (obj.gameObject.tag == "hisoka_target") {
			GameObject FlareRsc = Resources.Load ("Flare") as GameObject;
			GameObject FlareObj = Instantiate (FlareRsc) as GameObject;
			FlareObj.transform.position = transform.position;

			//After ball hit the cube, we hide the cube and destroy FlareObj
			Destroy(FlareObj, 7);
			obj.gameObject.SetActive (false);
			targetHit++; //Increment by one when one cube is hit
			showText();
		}
	}
}
