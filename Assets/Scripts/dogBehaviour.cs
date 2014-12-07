using UnityEngine;
using System.Collections;

public class dogBehaviour : MonoBehaviour {

    public float speed;
    public float biteTime;
    public float bitePushBack;
    public string animationKey;
    public AnimationClip deathAnimation;
    public int maxHealth;
    public float hitStayTime;

    private float functionalSpeed;
    private Animator dogAnimator;
    private int lastAnimationSignal = -1;
    private int currHealth;

    private DogState currState;

    enum DogState
    {
        Chase,
        Die,
        Hit,
    }

	// Use this for initialization
	void Start () {
        functionalSpeed = speed;
        dogAnimator = GetComponent<Animator>();
        dogAnimator.SetInteger(animationKey, 0);
        currState = DogState.Chase;
        currHealth = maxHealth;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (currState)
        {
            case DogState.Chase:
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

                break;
            case DogState.Die: // Do nothing while animation plays
                rigidbody2D.velocity = Vector2.zero;
                break;
            case DogState.Hit:
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;

        switch (go.tag)
        {
            case "Player":
                if (currState != DogState.Hit && currState != DogState.Die)
                {
                    Bite();
                    avatarMovement die = go.GetComponent<avatarMovement>();
                    die.ReSpawn();
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject go = collider.gameObject;

        switch (go.tag)
        {
            case "ThrownObject":
                if (currState != DogState.Hit && currState != DogState.Die)
                {
                    thrownObject to = go.GetComponent<thrownObject>();
                    GetHit(to.mailValue);
                }
                break;
        }
    }

    void GetHit(int mailValue)
    {
        currHealth -= mailValue;

        Debug.Log(gameObject.name + " hit to: " + currHealth);

        if (currHealth <= 0)
        {
            Die();
        }
        else
        {
            currState = DogState.Hit;
            dogAnimator.SetInteger(animationKey, 0); // Set to idle
            Invoke("ReturnToChase", hitStayTime);
        }
    }

    void ReturnToChase()
    {
        currState = DogState.Chase;
    }

    void Die()
    {
        //Debug.Log("Die " + gameObject.name);
        currState = DogState.Die;

        dogAnimator.SetInteger(animationKey, 6);

        Invoke("KillGameObject", deathAnimation.length);
    }

    void KillGameObject()
    {
        Destroy(gameObject);
    }

    void Bite()
    {
        if (currState != DogState.Die)
        {
            //Debug.Log("Bite " + gameObject.name);

            dogAnimator.SetInteger(animationKey, 5);

            Lives.LIVES--; //subtracts lives

            Vector3 avatarPos = avatarMovement.shittyInstance.transform.position;
            Vector3 dirAwayFromAvatar = transform.position - avatarPos;

            rigidbody2D.AddForce(dirAwayFromAvatar * bitePushBack);

            functionalSpeed = 0;
            Invoke("ResetFunctionalSpeed", biteTime);
        }
    }

    void ResetFunctionalSpeed()
    {
        functionalSpeed = speed;
    }
}
