 using UnityEngine;
using System.Collections;

public class SpawnMultipleObject : MonoBehaviour
{

		private Vector3 startPosition;
		public float moveSpeed = 1.0f;
		public float moveDistance = 4.0f;
	
		public GameObject[] gameObjectSet;
	
		public float timeLeftUntilSpawn = 0f;
		public static float startTime = 0f;
	
		public float timeBetweenSpawn = 10f;
		private bool overcamePreviousObstacle;

		public int objectsSpawned = 0;
	
		// Use this for initialization
		void Start ()
		{
				startPosition = transform.position;
		}

		public void spawnRandomObject (int objIndexToSpawn)
		{
			int randInt = Random.Range (0, 3);
			Debug.Log ("Spawning object at: " + randInt);
			GameObject myObj = Instantiate (gameObjectSet [randInt]) as GameObject;
			myObj.transform.position = transform.position;

				objectsSpawned++;
		}

		// Update is called once per frame
		void Update ()
		{
			timeLeftUntilSpawn = Time.time - startTime;
			int objIndexToSpawn = -1;
			//GameObject player = GameObject.Find ("temp_character");
			//PlayerMove anotherScript = player.GetComponent<PlayerMove> ();
			//var gotValue = anotherScript.destroyedPrevious;
			overcamePreviousObstacle = PlayerMove.destroyedPrevious;
			//Debug.Log ("Destroyed Previous? : " + overcamePreviousObstacle);
		
			if (timeLeftUntilSpawn >= timeBetweenSpawn && overcamePreviousObstacle == true) {
				Debug.Log (timeLeftUntilSpawn + " " + overcamePreviousObstacle);
				startTime = Time.time;
				timeLeftUntilSpawn = 0;
				spawnRandomObject (objIndexToSpawn);
				PlayerMove.destroyedPrevious = false;
			}


				if (objectsSpawned > 10)
						Application.LoadLevel ("Credits");
		}
}
