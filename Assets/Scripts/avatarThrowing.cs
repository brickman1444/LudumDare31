using UnityEngine;
using System.Collections;

public class avatarThrowing : MonoBehaviour {

    public GameObject throwingPrefab;
    public float secondsBetweenThrows;
    public float throwingSpeed;
    public float throwingAngularSpeed;
    public float throwOffset;
    public bool requireSpace;
    public bool allowThrowing;

    private float lastThrowTime = 0;
    private Vector3 lastThrowDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (allowThrowing && (Time.time - lastThrowTime > secondsBetweenThrows && (!requireSpace || Input.GetAxis("Fire1") > 0.5f) ) )
        {
            //Debug.Log("Fire");
            lastThrowTime = Time.time;

            Vector3 throwDirection = new Vector3();

            throwDirection += Vector3.right * Input.GetAxis("AD");
            throwDirection += Vector3.up * Input.GetAxis("WS");

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
