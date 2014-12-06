using UnityEngine;
using System.Collections;

public class avatarMovement : MonoBehaviour {

    public float acceleration;
    public float maxSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        rigidbody2D.AddForce(Vector3.right * Time.deltaTime * acceleration * Input.GetAxis("AD"));
        rigidbody2D.AddForce(Vector3.up * Time.deltaTime * acceleration * Input.GetAxis("WS"));

        if (rigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rigidbody2D.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
	}
}
