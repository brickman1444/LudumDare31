using UnityEngine;
using System.Collections;

public class dogSpawner : MonoBehaviour {

    public GameObject[] dogPrefabs;
    public float timeBetweenDogs;
    public float offscreenCheckTime;
    public float minDistanceToWindow;
	public int maxDog;
    public GameObject window;
	GameObject dog;
	public static ArrayList kennel = new ArrayList(); //holds the number of dogs on screen
	//System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();  //used to track time change
	public float timeBetweenLevels;  // time to level up dogs 
	public int doglevel;   //level of dog, goes from big to small ex 2->0
	// Use this for initialization
	void Start () {
		maxDog = 10;  //delete this for inspector only code
		timeBetweenLevels = 2000;
		doglevel = 2;
        StartCoroutine(SpawnerRoutine());
		new WaitForSeconds(5);
		StartCoroutine(DogTimeRoutine());
	}

    IEnumerator SpawnerRoutine()  // coroutine
    {

        while (true)
        {
            Vector3 diffToWindow = window.transform.position - transform.position;

            // Check if outside the window
            if (diffToWindow.sqrMagnitude < minDistanceToWindow * minDistanceToWindow)
            {

               // Debug.Log(diffToWindow.sqrMagnitude);

                yield return new WaitForSeconds(offscreenCheckTime);
                continue;
            }
			if (kennel.Count < maxDog)
			{
				int index = Random.Range(0+doglevel, dogPrefabs.Length); //  adjust to follow time
            	dog = ((GameObject)Instantiate(dogPrefabs[index], transform.position, Quaternion.identity));   // used spawn dogs
				kennel.Add(dog); 
				
			}
            yield return new WaitForSeconds(timeBetweenDogs);  // returns the co routnine
        }
    }
	IEnumerator DogTimeRoutine()  // coroutine
	{
		//Debug.Log("running Dog Routine");
		while (true)
		{
			if (doglevel !=0)
			{
				doglevel-=1;
			}
			//Debug.Log("finished routine"+Time.time);
			yield return new WaitForSeconds(10);
		}
	}

}
