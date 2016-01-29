using UnityEngine;
using System.Collections;

public class Enemy1 : EnnemisMain {

	private float timer = 0 ;
	private float timeBeetween2Frames;
	// Use this for initialization
	void Start () {
		//Init closest tree
		tree = findClosestTree();

		animator =gameObject.GetComponent<Animator> ();
		audioSource =gameObject.GetComponent<AudioSource> ();
	}

	public void moveEnemy(){
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, tree.transform.position, step);
	}


	// Update is called once per frame
	void Update () {
		if (!hasReachTheTree) { moveEnemy (); }
		timeBeetween2Frames = Time.deltaTime;
		timer += timeBeetween2Frames;
		if (timer > 2) 
		{
			takeDamage(100);
			timer=0;
		}
	}
}
