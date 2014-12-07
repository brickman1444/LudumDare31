using UnityEngine;
using System.Collections;

public class MediumDog_ANI : MonoBehaviour {
	Animator mediumdog;
	// Use this for initialization
	void Start () {
		mediumdog = GetComponent<Animator>();
		mediumdog.SetInteger("MEDIUM_Dog",0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E))
		{
			mediumdog.SetInteger("MEDIUM_Dog",0);  //resets to idle
		}
		if (Input.GetKey (KeyCode.V))
		{
			mediumdog.SetInteger("MEDIUM_Dog",6);  //resets to idle
		}

		if (Input.GetKey (KeyCode.W)) 
		{
			mediumdog.SetInteger("MEDIUM_Dog",4);  
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			mediumdog.SetInteger("MEDIUM_Dog",1);
		}

		if (Input.GetKey (KeyCode.S)) 
		{
			mediumdog.SetInteger("MEDIUM_Dog",2);
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			mediumdog.SetInteger("MEDIUM_Dog",3);
		}

		if (Input.GetKey (KeyCode.R)) 
		{
			mediumdog.SetInteger("MEDIUM_Dog",5);
		}
	}
}
