using UnityEngine;
using System.Collections;

public class SpawnMultipleObject : MonoBehaviour {

	private Vector3 startPosition;
	public float moveSpeed = 1.0f;
	public float moveDistance = 4.0f;

	public GameObject[] gameObjectSet;

	public float timeLeftUntilSpawn = 0f;
	public float startTime = 0f;

	public float timeBetweenSpawn = 3f;
	public bool overcamePreviousObstacle = true;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}

	void spawnRandomObject()
	{
		int randInt = Random.Range (0, 2);
		Debug.Log ("Random Integer: " + randInt);
		GameObject myObj = Instantiate (gameObjectSet[randInt]) as GameObject;
		myObj.transform.position = transform.position;
	}

	// Update is called once per frame
	void Update () {
	
		timeLeftUntilSpawn = Time.time - startTime;

		if (timeLeftUntilSpawn >= timeBetweenSpawn && overcamePreviousObstacle == true) {
			startTime = Time.time;
			timeLeftUntilSpawn = 0;
			spawnRandomObject ();
				}
	}
}
