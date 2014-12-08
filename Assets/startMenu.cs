using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startMenu : MonoBehaviour {

    public GameObject[] thingsToActivate;
    public AudioSource pressSpaceSound;
    bool didStart = false;

	// Use this for initialization
	void Start () {
        foreach (GameObject go in thingsToActivate)
        {
            go.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && !didStart)
        {
            foreach (GameObject go in thingsToActivate)
            {
                go.SetActive(true);
            }

            Image image = GetComponent<Image>();
            image.enabled = false;

            pressSpaceSound.Play();

            Destroy(gameObject, 2);

            didStart = true;
        }
	}
}
