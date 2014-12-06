using UnityEngine;
using System.Collections;

public class avatarThrowing : MonoBehaviour {

    public GameObject throwingPrefab;
    public float secondsBetweenThrows;
    
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
            GameObject.Instantiate(throwingPrefab, transform.position, Quaternion.identity);
        }
	}
}
