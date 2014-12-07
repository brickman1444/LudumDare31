using UnityEngine;
using System.Collections;

public class mailbox : MonoBehaviour {

    public Sprite openSprite;
    public Sprite closedSprite;
    public float closeTime;

    SpriteRenderer spriteRenderer;

    bool isOpen;

	// Use this for initialization
	void Start () {
        spriteRenderer = (SpriteRenderer)renderer;

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
            Close();
        }
    }

    void Open()
    {
        spriteRenderer.sprite = openSprite;
        isOpen = true;
    }
}
