using UnityEngine;
using System.Collections;

public class avatarMovement : MonoBehaviour {

    public float acceleration;
    public float maxSpeed;

    public static avatarMovement shittyInstance = null;

    void Awake()
    {
        shittyInstance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (rigidbody2D.velocity.x * Input.GetAxis("AD") < 0)
        {
            rigidbody2D.velocity = new Vector3(0,rigidbody2D.velocity.y,0);
        }

        if (rigidbody2D.velocity.y * Input.GetAxis("WS") < 0)
        {
            rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x, 0, 0);
        }

        Vector3 direction = new Vector3();

        direction += Vector3.right * Input.GetAxis("AD");
        direction += Vector3.up * Input.GetAxis("WS");

        direction.Normalize();

        rigidbody2D.AddForce(direction * Time.deltaTime * acceleration);

        if (rigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
        }
	}
}
