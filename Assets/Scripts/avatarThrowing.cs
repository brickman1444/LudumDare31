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
    private avatarMovement mAvatarMovement;

	// Use this for initialization
	void Start () {
        mAvatarMovement = gameObject.GetComponent<avatarMovement>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time - lastThrowTime > secondsBetweenThrows && (!requireSpace || Input.GetAxis("Fire1") > 0.5f) )
        {
            Debug.Log("Fire");
            lastThrowTime = Time.time;
            
            Vector3 throwDirection = mAvatarMovement.lastVelocity.normalized;

            if (throwDirection == Vector3.zero)
            {
                throwDirection = Vector3.right;
            }
            
            GameObject thrownObject = (GameObject) GameObject.Instantiate(throwingPrefab, transform.position + throwDirection * throwOffset, Quaternion.identity);

            thrownObject.GetComponent<thrownObject>().Initialize(throwDirection * throwingSpeed, throwingAngularSpeed);
        }
	}
}
