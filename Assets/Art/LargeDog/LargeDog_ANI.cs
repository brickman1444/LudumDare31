using UnityEngine;
using System.Collections;

public class LargeDog_ANI : MonoBehaviour {
	Animator largedog;
	// Use this for initialization
	void Start () {
		largedog = GetComponent<Animator>();
		largedog.SetInteger("LARGE_Dog",0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E))
		{
			largedog.SetInteger("LARGE_Dog",0);  //resets to idle
		}
		if (Input.GetKey (KeyCode.V))
		{
			largedog.SetInteger("LARGE_Dog",6);  //resets to idle
		}
		
		if (Input.GetKey (KeyCode.W)) 
		{
			largedog.SetInteger("LARGE_Dog",4);  
		}
		
		if (Input.GetKey (KeyCode.D)) 
		{
			largedog.SetInteger("LARGE_Dog",1);
		}
		
		if (Input.GetKey (KeyCode.S)) 
		{
			largedog.SetInteger("LARGE_Dog",2);
		}
		
		if (Input.GetKey (KeyCode.A)) 
		{
			largedog.SetInteger("LARGE_Dog",3);
		}
		
		if (Input.GetKey (KeyCode.R)) 
		{
			largedog.SetInteger("LARGE_Dog",5);
		}
	}
}
