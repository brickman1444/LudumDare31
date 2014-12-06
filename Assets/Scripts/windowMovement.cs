using UnityEngine;
using System.Collections;

public class windowMovement : MonoBehaviour {

    public float speed;
    public GameObject maxObject;
    public GameObject minObject;

    Vector3 maxPos;
    Vector3 minPos;

	// Use this for initialization
	void Start () {
        maxPos = maxObject.transform.position;
        minPos = minObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 velocity = new Vector3();

        velocity += Vector3.right * Time.deltaTime * speed * Input.GetAxis("RightLeft");
        velocity += Vector3.up * Time.deltaTime * speed * Input.GetAxis("UpDown");

        Vector3 newPos = transform.position + velocity;

        if (newPos.x > maxPos.x)
        {
            newPos.x = maxPos.x;
        }
        else if (newPos.x < minPos.x)
        {
            newPos.x = minPos.x;
        }

        if (newPos.y > maxPos.y)
        {
            newPos.y = maxPos.y;
        }
        else if (newPos.y < minPos.y)
        {
            newPos.y = minPos.y;
        }

        transform.position = newPos;
	}
}
