using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
	Animator littledog;
	// Use this for initialization
	void Start () {
		littledog = GetComponent<Animator>();
		littledog.SetInteger("LITTLE_Dog",0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E))
		{
			littledog.SetInteger("LITTLE_Dog",0);  //resets to idle
		}
		if (Input.GetKey (KeyCode.V))
		{
			littledog.SetInteger("LITTLE_Dog",6);  //resets to idle
		}

		if (Input.GetKey (KeyCode.W)) 
		{
			littledog.SetInteger("LITTLE_Dog",4);  
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			littledog.SetInteger("LITTLE_Dog",1);
		}

		if (Input.GetKey (KeyCode.S)) 
		{
			littledog.SetInteger("LITTLE_Dog",2);
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			littledog.SetInteger("LITTLE_Dog",3);
		}

		if (Input.GetKey (KeyCode.R)) 
		{
			littledog.SetInteger("LITTLE_Dog",5);
		}
	}
}
