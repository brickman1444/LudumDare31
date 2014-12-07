using UnityEngine;
using System.Collections;

public class dogBehaviour : MonoBehaviour {

    public float speed;
    public float biteTime;
    public float bitePushBack;
    public string animationKey;

    private float functionalSpeed;
    private Animator dogAnimator;
    private int lastAnimationSignal = -1;

	// Use this for initialization
	void Start () {
        functionalSpeed = speed;
        dogAnimator = GetComponent<Animator>();
        dogAnimator.SetInteger(animationKey, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 toAvatar = avatarMovement.shittyInstance.transform.position - transform.position;
        toAvatar.Normalize();

        Vector3 velocity = toAvatar * functionalSpeed * Time.fixedDeltaTime;

        int animationSignal = -1;

        // find major axis of velocity
        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
        {
            if (velocity.x > 0)
            {
                animationSignal = 1;
            }
            else
            {
                animationSignal = 3;
            }
        }
        else if (Mathf.Abs(velocity.y) > Mathf.Abs(velocity.x))
        {
            if (velocity.y > 0)
            {
                animationSignal = 4;
            }
            else
            {
                animationSignal = 2;
            }
        }

        if (animationSignal != -1 && animationSignal != lastAnimationSignal)
        {
            dogAnimator.SetInteger(animationKey, animationSignal);
        }


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
