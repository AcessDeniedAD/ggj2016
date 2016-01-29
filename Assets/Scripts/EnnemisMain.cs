using UnityEngine;
using System.Collections;

public class EnnemisMain : MonoBehaviour {
	public float HP ;
	public float damage;
	public float speed;
	public GameObject tree;
	[HideInInspector]public bool isAlive = true;
	[HideInInspector]public Animator animator;
	[HideInInspector]public AudioSource audioSource;

	public AudioClip deathSound;

	
	public EnnemisMain()
	{

		HP = 100;
		damage = 10;
		speed = 100;
		isAlive = true;
		animator = animator;
	}
	// Use this for initialization
	void Start()
	{
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void takeDamage(float damage)
	{
		HP -= damage;
		if (HP <= 0 && isAlive) 
		{
			StartCoroutine(setDestroy());
		}
		Debug.Log ("enemy as : "+ HP+" HP");
	}
	IEnumerator setDestroy()
	{
		isAlive = false;
		audioSource.PlayOneShot (deathSound);
		//ici jouer les animations de mort avant la destruction 
		animator.SetBool ("canDie", true);
		yield return new WaitForEndOfFrame ();
		yield return new WaitForSeconds (3);
		Destroy(gameObject);
		yield return 0;
	}

	//Retrun the closest tree
	public GameObject findClosestTree() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Tree");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
	
}
