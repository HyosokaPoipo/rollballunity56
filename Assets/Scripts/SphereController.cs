using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
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
}
