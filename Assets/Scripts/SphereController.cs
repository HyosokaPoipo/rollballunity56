using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public GUIText score;
	public GUIText win;
	private int targetHit;
	private AudioSource sound;

	private void firingFireworks() {
		GameObject FireRsc = Resources.Load ("Fireworks") as GameObject;
		GameObject FireObj1 = Instantiate (FireRsc) as GameObject;
		GameObject FireObj2 = Instantiate (FireRsc) as GameObject;
		GameObject FireObj3 = Instantiate (FireRsc) as GameObject;
		GameObject FireObj4 = Instantiate (FireRsc) as GameObject;
		GameObject FireObj5 = Instantiate (FireRsc) as GameObject;


		FireObj1.transform.position = new Vector3(-13.99f, 1 , -13.25f);
		FireObj2.transform.position = new Vector3(13.01f, 1, -13.25f);
		FireObj3.transform.position = new Vector3(-13.76f, 1 , 7.7f);
		FireObj4.transform.position = new Vector3(13.09f, 1 , 13.88f);
		FireObj5.transform.position = new Vector3(2.01f, 1 , 2.88f);
	}
	private void showText() {
		score.text = "Point : "+targetHit.ToString ();
		if (targetHit >= 13) {
			win.text = "Congratulations...!\n You Wiiin...!";
			firingFireworks ();
			sound.Play ();
		}
	}
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		targetHit = 0;
		win.text = "";
		showText ();
		sound = GameObject.Find("WinnerFireworkVoice").GetComponent<AudioSource>();
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
			Destroy(FlareObj, 13);
			obj.gameObject.SetActive (false);
			targetHit++; //Increment by one when one cube is hit
			showText();
		}
	}
}
