using UnityEngine;
using System.Collections;

public class thrownObject : MonoBehaviour {

    Vector3 velocity;
    float angularVelocity;

	// Use this for initialization
	void Start () {
	    
	}

    public void Initialize(Vector3 _velocity, float _angularVelocity)
    {
        velocity = _velocity;
        angularVelocity = _angularVelocity;
    }

	// Update is called once per frame
	void FixedUpdate () {
        rigidbody2D.velocity = velocity * Time.fixedDeltaTime;
        rigidbody2D.angularVelocity = angularVelocity * Time.fixedDeltaTime;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;

        switch(go.tag)
        {
            case "House":
            case "Wall": Destroy(gameObject); break;
        }
    }
}
