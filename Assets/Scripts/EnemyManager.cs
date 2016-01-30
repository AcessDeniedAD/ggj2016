using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	
	public GameObject enemy;
	public GameObject bounds;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves(){

		while(true){
			for(int i = 0; i < 10 ; i++){
				Vector3 spawn_position = getSpawnPostion();
				Quaternion spawn_orientation = Quaternion.identity;

				Instantiate(enemy,spawn_position,spawn_orientation);

				yield return new WaitForSeconds (1);
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
	
	}
}
