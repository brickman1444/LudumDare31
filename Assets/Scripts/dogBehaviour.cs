using UnityEngine;
using System.Collections;

public class dogBehaviour : MonoBehaviour {

    public float speed;
    public float biteTime;
    public float bitePushBack;

    private float functionalSpeed;

	// Use this for initialization
	void Start () {
        functionalSpeed = speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 toAvatar = avatarMovement.shittyInstance.transform.position - transform.position;
        toAvatar.Normalize();

        Vector3 velocity = toAvatar * functionalSpeed * Time.fixedDeltaTime;

        rigidbody2D.velocity = velocity;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;

        switch (go.tag)
        {
            case "ThrownObject": 
                Die(); 
                break;
            case "Player":
                Bite();
				Lives.LIVES -=1; //subtracts lives
			avatarMovement die =	go.GetComponent<avatarMovement>();
			die.ReSpawn();

                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject go = collider.gameObject;

        switch (go.tag)
        {
            case "ThrownObject":
                Die();
                break;
        }
    }

    void Die()
    {
        //Debug.Log("Die " + gameObject.name);
		GameObject dog = (GameObject)this.gameObject;
		dogSpawner.kennel.Remove(dog);
        Destroy(gameObject);
    }

    void Bite()
    {
        //Debug.Log("Bite " + gameObject.name);
        Vector3 avatarPos = avatarMovement.shittyInstance.transform.position;
        Vector3 dirAwayFromAvatar = transform.position - avatarPos;

        rigidbody2D.AddForce(dirAwayFromAvatar * bitePushBack);

        functionalSpeed = 0;
        Invoke("ResetFunctionalSpeed", biteTime);
    }

    void ResetFunctionalSpeed()
    {
        functionalSpeed = speed;
    }
}
