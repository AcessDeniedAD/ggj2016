using UnityEngine;
using System.Collections;

public class Enemy1 : EnnemisMain {

	private float timer = 0 ;
	private float timeBeetween2Frames;
	// Use this for initialization
	void Start () {
		HP = HPInit;

		//Init closest tree
		target = findClosestTree().transform.position;
		lifeIndicator = transform.Find("LifeIndicator").gameObject;
		lifeIndicator.GetComponent<Renderer>().enabled = HPInit != HP;
		
		animator =gameObject.GetComponent<Animator> ();
		audioSource =gameObject.GetComponent<AudioSource> ();
	}

	public void moveEnemy(){
		float step = speed * Time.deltaTime;
		transform.LookAt(target);
		transform.position = Vector3.MoveTowards(transform.position, target, step);
	}


	// Update is called once per frame
	void Update () {
		//Move object
		if (!hasReachTheTree && isAlive) { moveEnemy (); }



		if(lifeIndicator != null) {
			//Show only of hurt/wounded
			lifeIndicator.GetComponent<Renderer>().enabled = HPInit != HP;

			//Rotate life indicator to face the camera
			lifeIndicator.transform.LookAt(lifeIndicatorLookTarget.transform.position);
		}

		timeBeetween2Frames = Time.deltaTime;
		timer += timeBeetween2Frames;
		if (timer > 2) 
		{
			takeDamage(100);
			timer=0;
		}
	}
}
