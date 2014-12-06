using UnityEngine;
using System.Collections;

public class thrownObject : MonoBehaviour {

    Vector3 velocity;

	// Use this for initialization
	void Start () {
	
	}

    public void Initialize(Vector3 _velocity)
    {
        velocity = _velocity;
    }

	// Update is called once per frame
	void FixedUpdate () {
        rigidbody2D.velocity = velocity * Time.fixedDeltaTime;
	}
}
