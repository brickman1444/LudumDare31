using UnityEngine;
using System.Collections;

public class dogSpawner : MonoBehaviour {

    public GameObject[] dogPrefabs;
    public float timeBetweenDogs;
    public float offscreenCheckTime;
    public float minDistanceToWindow;
    public GameObject window;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnerRoutine());
	}

    IEnumerator SpawnerRoutine()
    {
        while (true)
        {
            /*Vector3 diffToWindow = window.transform.position - transform.position;

            // Check if outside the window
            if (diffToWindow.sqrMagnitude < minDistanceToWindow * minDistanceToWindow)
            {
                yield return new WaitForSeconds(offscreenCheckTime);
                continue;
            }*/

            int index = Random.Range(0, dogPrefabs.Length);

            GameObject.Instantiate(dogPrefabs[index], transform.position, Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenDogs);
        }
    }
}
