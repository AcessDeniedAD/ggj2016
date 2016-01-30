using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	
	public GameObject enemy;
	public GameObject bounds;
	private float spawnWait;
	private float enemySpeed;
	private float timeElapsed;

	// Use this for initialization
	void Start () {
		spawnWait = 2.0f;
		enemySpeed = 5.0f;
		timeElapsed = 0.0f;
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves(){

		while(true){
			for(int i = 0; i < 10 ; i++){
				float enemySpeedFactor = 1.0f;
				float spawnWaitFactor = 1.0f;
				Vector3 spawn_position = getSpawnPostion();
				Quaternion spawn_orientation = Quaternion.identity;

				GameObject enemyGO = Instantiate(enemy,spawn_position,spawn_orientation) as GameObject;

				if (timeElapsed < 10) {
					enemySpeedFactor = 1.0f;
					spawnWaitFactor = 1.0f;
				}
				else if (timeElapsed >= 10 && timeElapsed < 20) {
					enemySpeedFactor = 1.2f;
					spawnWaitFactor = 0.95f;
				}
				else if (timeElapsed >= 20 && timeElapsed < 30) {
					enemySpeedFactor = 1.25f;
					spawnWaitFactor = 0.95f;
				}
				else if (timeElapsed >= 30 && timeElapsed < 40) {
					enemySpeedFactor = 1.35f;
					spawnWaitFactor = 0.85f;
				}
				else if (timeElapsed >= 40 && timeElapsed < 50) {
					enemySpeedFactor = 1.40f;
					spawnWaitFactor = 0.8f;
				}
				else if (timeElapsed >= 50 && timeElapsed < 60) {
					enemySpeedFactor = 1.50f;
					spawnWaitFactor = 0.7f;
				}
				else {
					enemySpeedFactor = 1.60f;
					spawnWaitFactor = 0.65f;
				}

				enemyGO.GetComponent<EnnemisMain>().speed = enemySpeed * enemySpeedFactor;
				yield return new WaitForSeconds (spawnWait * spawnWaitFactor);
				//yield return 0;
			}

			//yield return new WaitForSeconds (10);
			yield return 0;
		}

	}

	//Return a radom postion around BoundsObjects
	private Vector3 getSpawnPostion()
	{
		float minX = bounds.GetComponent<Collider>().bounds.min.x;
		float maxX = bounds.GetComponent<Collider>().bounds.max.x;
		float minZ = bounds.GetComponent<Collider>().bounds.min.z;
		float maxZ = bounds.GetComponent<Collider>().bounds.max.z;
		Vector3 result = new Vector3 ();

		if (Random.Range (0, 2) == 1) {
			if (Random.Range (0, 2) == 1) {
				result = new Vector3 (Random.Range (minX, maxX), enemy.transform.position.y, minZ);
			} else {
				result = new Vector3 (Random.Range (minX, maxX), enemy.transform.position.y, maxZ);
			}
		} else {
			if (Random.Range (0, 2) == 1) {
				result = new Vector3 (minX, enemy.transform.position.y, Random.Range (minZ, maxZ));
			} else {
				result = new Vector3 (maxX, enemy.transform.position.y, Random.Range (minZ, maxZ));
			}
		}
		return result;
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
	}
}
