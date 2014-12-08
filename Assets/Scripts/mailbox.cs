using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mailbox : MonoBehaviour {

    public Sprite openSprite;
    public Sprite closedSprite;
    public float closeTime;
    public GameObject textObject;

    public AudioSource delivered;

    Text mailText;
    SpriteRenderer spriteRenderer;

    static uint mailDelivered = 0;

    bool isOpen;

    static uint[] throwableArray = { 20, 50 };
    static uint throwableIndex = 0;

	// Use this for initialization
	void Start () {
        spriteRenderer = (SpriteRenderer)renderer;
        mailText = textObject.GetComponent<Text>();

        Open();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject go = collider.gameObject;

        switch (go.tag)
        {
            case "ThrownObject":
                FillMailbox();
                break;
        }
    }

    void Close()
    {
        spriteRenderer.sprite = closedSprite;
        isOpen = false;
        Invoke("Open", closeTime);
    }

    void FillMailbox()
    {
        if (isOpen)
        {
            IncreaseMailDelivered((uint)avatarThrowing.shittyInstance.currentThrowingObject.mailValue);
            Close();
        }
    }

    void Open()
    {
        spriteRenderer.sprite = openSprite;
        isOpen = true;
    }

    void IncreaseMailDelivered(uint mailJustDelivered)
    {
        mailDelivered += mailJustDelivered;
        mailText.text = "Mail Delivered: " + mailDelivered;
        delivered.Play();

        if (throwableIndex < throwableArray.Length)
        {
            if (mailDelivered >= throwableArray[throwableIndex])
            {
                Debug.Log("Increase thrown object " + throwableIndex);
                throwableIndex++;
                avatarThrowing.shittyInstance.IncrementThrownObject();
            }
        }
    }
}
