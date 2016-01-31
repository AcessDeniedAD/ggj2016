using UnityEngine;
using System.Collections;

public class Enemy1 : EnnemisMain {
	
	private float timer = 2.1f;
	private float timeBetweenAttacks = 2.0f;
	private float timeAnimationAttack = 1.0f;

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
			
		if (hasReachTheTree && isAlive) { 
			timer += Time.deltaTime;
			if (timer > timeBetweenAttacks) {
				StartCoroutine(attack());
				timer=0;
			}
		}

		if(lifeIndicator != null) {
			//Show only of hurt/wounded
			lifeIndicator.GetComponent<Renderer>().enabled = HPInit != HP;

			//Rotate life indicator to face the camera
			lifeIndicator.transform.LookAt(lifeIndicatorLookTarget.transform.position);
		}

		/*
		// Commit suicide
		timer += Time.deltaTime;
		if (timer > 1) 
		{
			SceneManager.addMana(5);
			takeDamage(100);
			timer=0;
		}*/
	}

	IEnumerator attack()
	{
		//ici jouer les animations de mort avant la destruction 

		yield return new WaitForEndOfFrame ();
		
		GameObject go = findClosestTree() as GameObject;
		if (go != null) {
			Tree tgo = go.GetComponent<Tree>();
			tgo.take_dammage(this);
			Debug.Log(tgo.Tree_life);
		}

		yield return 0;
	}

}
