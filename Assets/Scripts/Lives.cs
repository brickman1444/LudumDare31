using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

	public int startingLives;
	public GameObject newLives; //lives prefab
	public float spacingX;  //for formating
	public static int LIVES; // number of player lives
	private ArrayList lives = new ArrayList(); //holds the number of lives
	public Vector3 placement;
	// Use this for initialization
	void Start () {
		spacingX = 0.2f;
		placement = new Vector3(-1.63f,1f,-8.4f);
		AddLives (startingLives);
		LIVES = startingLives;
	}
	
	// Update is called once per frame
	void Update () {
		if (LIVES != lives.Count)
		{
			LoseLives();
			LIVES = lives.Count;
		}
	}

	public void AddLives(int n) 
	{
		for (int i = 0; i < n; i ++) 
		{
			Transform NewLives =  ((GameObject)Instantiate(newLives.gameObject)).transform;
			NewLives.position = placement;
			placement.x += spacingX;
			lives.Add (NewLives);  //adding to array
			NewLives.parent = transform;
		}
	}
	public void LoseLives()
	{   //Debug.Log("Ran the loselives");
		int childs = transform.childCount;

		if (childs >1 )
		{
			GameObject.Destroy(transform.GetChild(childs-1).gameObject);
		}
		else if (LIVES == 0)
		{
			//Debug.Log("Ran the scene change");
			Application.LoadLevel("theGame2");  //make this whatever you want
		}
	}	
}

