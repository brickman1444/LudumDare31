using UnityEngine;
using System.Collections;

public class Mail_Man_ANI : MonoBehaviour {
	Animator Mailman;
	// Use this for initialization
	void Start () {
		Mailman = GetComponent<Animator>();
		Mailman.SetInteger("MAIL_man",0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E))
		{
			Mailman.SetInteger("MAIL_man",0);  //resets to idle
		}
		if (Input.GetKey (KeyCode.V))
		{
			Mailman.SetInteger("MAIL_man",6);  //sets to die
		}
		
		if (Input.GetKey (KeyCode.W))     
		{
			Mailman.SetInteger("MAIL_man",4);  
		}
		
		if (Input.GetKey (KeyCode.D)) 
		{
			Mailman.SetInteger("MAIL_man",1);
		}
		
		if (Input.GetKey (KeyCode.S)) 
		{
			Mailman.SetInteger("MAIL_man",2);
		}
		
		if (Input.GetKey (KeyCode.A)) 
		{
			Mailman.SetInteger("MAIL_man",3);
		}
		
		if (Input.GetKey (KeyCode.R)) 
		{
			Mailman.SetInteger("MAIL_man",5);
		}
	}
}