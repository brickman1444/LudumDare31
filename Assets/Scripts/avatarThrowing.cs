using UnityEngine;
using System.Collections;

public class avatarThrowing : MonoBehaviour {

    public GameObject throwingPrefab;
    public float secondsBetweenThrows;
    public float throwingSpeed;
    public float throwOffset;

    private float lastThrowTime = 0;
    private avatarMovement mAvatarMovement;

	// Use this for initialization
	void Start () {
        mAvatarMovement = gameObject.GetComponent<avatarMovement>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time - lastThrowTime > secondsBetweenThrows && Input.GetAxis("Fire1") > 0.5f)
        {
            Debug.Log("Fire");
            lastThrowTime = Time.time;
            
            Vector3 throwDirection = mAvatarMovement.lastVelocity.normalized;
            
            GameObject thrownObject = (GameObject) GameObject.Instantiate(throwingPrefab, transform.position + throwDirection * throwOffset, Quaternion.identity);

            Debug.Log(throwDirection);

            thrownObject.GetComponent<thrownObject>().Initialize(throwDirection * throwingSpeed);
        }
	}
}
