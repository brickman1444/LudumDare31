using UnityEngine;
using System.Collections;

public class avatarThrowing : MonoBehaviour {

    public GameObject throwingPrefab;
    public float secondsBetweenThrows;
    public float throwingSpeed;
    public float throwingAngularSpeed;
    public float throwOffset;
    public bool requireSpace;

    private float lastThrowTime = 0;
    private Vector3 lastThrowDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time - lastThrowTime > secondsBetweenThrows && (!requireSpace || Input.GetAxis("Fire1") > 0.5f) )
        {
            Debug.Log("Fire");
            lastThrowTime = Time.time;

            Vector3 throwDirection = rigidbody2D.velocity.normalized;

            if (throwDirection == Vector3.zero)
            {
                if (lastThrowDirection != Vector3.zero)
                {
                    throwDirection = lastThrowDirection;
                }
            }

            if (throwDirection != Vector3.zero)
            {
                GameObject thrownObject = (GameObject)GameObject.Instantiate(throwingPrefab, transform.position + throwDirection * throwOffset, Quaternion.identity);
                thrownObject.GetComponent<thrownObject>().Initialize(throwDirection * throwingSpeed, throwingAngularSpeed);
            }

            lastThrowDirection = throwDirection;
        }
	}
}
