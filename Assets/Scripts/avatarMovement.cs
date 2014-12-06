using UnityEngine;
using System.Collections;

public class avatarMovement : MonoBehaviour {

    public float acceleration;
    public float maxSpeed;

    public static avatarMovement shittyInstance = null;

    public Vector3 lastVelocity { get; private set; }

    void Awake()
    {
        shittyInstance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

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

        rigidbody2D.AddForce(direction * Time.fixedDeltaTime * acceleration);

        if (rigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
        }
	}
}
