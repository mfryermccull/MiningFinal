using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject cubePrefab;
	private bool recentlySpawnedGold = false;

	public GameObject bronzePrefabCube;
	public GameObject silverPrefabCube;
	public GameObject goldPrefabCube;

	public static int bronzeCount = 0;
	public static int silverCount = 0;
	public static int goldCount = 0;

	public static int bronzePoints = 1;
	public static int silverPoints = 10;
	public static int goldPoints = 100;

	public static int score = 0;

	float spawnSilverTime = 12.0f;
	float spawnFrequency = 3f;
	float timeToAct = 0f;
	float stopSpawningTime = 6.0f;
	

	// Use this for initialization
	void Start () {
	
		timeToAct += spawnFrequency;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.time >= timeToAct){
			// Check to spawn gold first, since it's highest priority,
			// but never spawn 2 gold in a row
			if (bronzeCount == 2 && silverCount == 2 && recentlySpawnedGold == true) {
				Instantiate(goldPrefabCube,
				            new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 5f), 0),
				            Quaternion.identity);
				goldCount++;
				recentlySpawnedGold = true;
			}
			else if (bronzeCount < 4) {
				Instantiate(bronzePrefabCube,
				            new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 5f), 0),
				            Quaternion.identity);
				bronzeCount++;
				recentlySpawnedGold = false;
			}
			else if (bronzeCount >= 4) {
				Instantiate(silverPrefabCube,
				            new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 5f), 0),
				            Quaternion.identity);
				silverCount++;
				recentlySpawnedGold = false;
			}



			timeToAct += spawnFrequency;
			print ("spawnACube");
			print (Time.time);

		}


	}
}
