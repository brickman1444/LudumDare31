using UnityEngine;
using System.Collections;

public class avatarMovement : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 velocity = new Vector3();

        velocity += Vector3.right * Time.deltaTime * speed * Input.GetAxis("AD");
        velocity += Vector3.up * Time.deltaTime * speed * Input.GetAxis("WS");

        transform.position += velocity;
	}
}
