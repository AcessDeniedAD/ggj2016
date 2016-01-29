using UnityEngine;
using System.Collections;

public class EnnemisMain : MonoBehaviour {
	public float HP ;
	public float dammage;
	[HideInInspector]public bool isAlive = true;
	[HideInInspector]public Animator animator;
	[HideInInspector]public AudioSource audioSource;

	public AudioClip deathSound;

	
	public EnnemisMain()
	{
		HP = 100;
		dammage = 10;
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
	
}
