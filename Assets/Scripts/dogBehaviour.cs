using UnityEngine;
using System.Collections;

public class dogBehaviour : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 toAvatar = avatarMovement.shittyInstance.transform.position - transform.position;
        toAvatar.Normalize();

        Vector3 velocity = toAvatar * speed * Time.fixedDeltaTime;

        rigidbody2D.velocity = velocity;
	}
}
