﻿using UnityEngine;
using System.Collections;

public class thrownObject : MonoBehaviour {

    Vector3 velocity;
    float angularVelocity;
    float threshold = 0.001f;
    public int mailValue;

	// Use this for initialization
	void Start () {
        rigidbody2D.rotation = Random.Range(0,360);
	}

    public void Initialize(Vector3 _velocity, float _angularVelocity, int _mailValue)
    {
        velocity = _velocity;
        angularVelocity = _angularVelocity;
        mailValue = _mailValue;

        if (velocity.sqrMagnitude < threshold)
        {
            Destroy(gameObject);
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        rigidbody2D.velocity = velocity * Time.fixedDeltaTime;
        rigidbody2D.angularVelocity = angularVelocity * Time.fixedDeltaTime;
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject go = collider.gameObject;

        switch(go.tag)
        {
            case "House":
            case "Wall":
            case "Dog": Invoke("Die", 0.17f); break;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
