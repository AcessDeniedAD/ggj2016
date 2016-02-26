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
		enemySpeed = 4.5f;
		timeElapsed = 0.0f;
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves(){
		
		yield return new WaitForSeconds (3);//Wait before enemies start to pop.
		if (!SceneManager.end_game) 
		{
			while(true){
				float enemySpeedFactor = 1.0f;
				float spawnWaitFactor = 1.0f;
				Vector3 spawn_position = getSpawnPostion();
				Quaternion spawn_orientation = Quaternion.identity;
				
				GameObject enemyGO = Instantiate(enemy,spawn_position,spawn_orientation) as GameObject;
				
				if (timeElapsed < 20) {
					enemySpeedFactor = 1.0f;
					spawnWaitFactor = 1.0f;
				}
				else if (timeElapsed >= 20 && timeElapsed < 40) {
					enemySpeedFactor = 1.15f;
					spawnWaitFactor = 0.95f;
				}
				else if (timeElapsed >= 40 && timeElapsed < 60) {
					enemySpeedFactor = 1.25f;
					spawnWaitFactor = 0.90f;
				}
				else if (timeElapsed >= 60 && timeElapsed < 80) {
					enemySpeedFactor = 1.35f;
					spawnWaitFactor = 0.85f;
				}
				else if (timeElapsed >= 80 && timeElapsed < 100) {
					enemySpeedFactor = 1.45f;
					spawnWaitFactor = 0.75f;
				}
				else if (timeElapsed >= 100 && timeElapsed < 130) {
					enemySpeedFactor = 1.55f;
					spawnWaitFactor = 0.70f;
				}
				else if (timeElapsed >= 130 && timeElapsed < 200) {
					enemySpeedFactor = 1.60f;
					spawnWaitFactor = 0.60f;
				}
				else {
					enemySpeedFactor = 1.70f;
					spawnWaitFactor = 0.50f;
				}
				
				//Speed ranzomization
				if (Random.Range(0, 3) == 1) {
					enemySpeedFactor += 0.2f;
				}
				if (Random.Range(0, 3) == 1) {
					enemySpeedFactor += 0.2f;
				}
				if (Random.Range(0, 5) == 1) {
					enemySpeedFactor += 0.4f;
				}
				
				//Spawn wait randomisation
				if (Random.Range(0, 3) == 1) {
					spawnWaitFactor -= 0.10f;
				}
				if (Random.Range(0, 3) == 1) {
					spawnWaitFactor -= 0.10f;
				}
				if (Random.Range(0, 5) == 1) {
					spawnWaitFactor -= 0.30f;
				}
				//safe
				if (spawnWaitFactor < 0) {
					spawnWaitFactor = 0;
				}
				
				enemyGO.GetComponent<EnnemisMain>().speed = enemySpeed * enemySpeedFactor;
				yield return new WaitForSeconds (spawnWait * spawnWaitFactor);
			}
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
