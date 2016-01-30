using UnityEngine;
using System.Collections;

public class EnnemisMain : MonoBehaviour {
	public float HPInit ;
	protected float HP ;
	public float damage;
	public float speed;
	public GameObject lifeIndicatorLookTarget; 
	protected Vector3 target;
	protected GameObject lifeIndicator;
	public bool hasReachTheTree = false;
	[HideInInspector]public bool isAlive = true;
	[HideInInspector]public Animator animator;
	[HideInInspector]public AudioSource audioSource;

	public AudioClip deathSound;

	
	public EnnemisMain()
	{	
		HPInit = 100;
		HP = HPInit;
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
		if (HP < 0) { HP = 0; }
		
		//Change size of life indicator
		if (lifeIndicator != null) {
			StartCoroutine (reduceLifeIndicator (new Vector3 (HP / HPInit, 0, 0)));
		}

		if (HP <= 0 && isAlive) 
		{
			StartCoroutine(setDestroy());
		}
	}
	
	IEnumerator reduceLifeIndicator(Vector3 target)
	{
		float deltaTimeToEnd = 0.3f;
		while (lifeIndicator.transform.localScale.x > target.x) {
			float scaleXToRemove = Time.deltaTime * target.x / deltaTimeToEnd;
			if (scaleXToRemove == 0) { scaleXToRemove = 0.01f; }
			if (lifeIndicator.transform.localScale.x - scaleXToRemove < 0) { scaleXToRemove = lifeIndicator.transform.localScale.x; }
			lifeIndicator.transform.localScale -= new Vector3(scaleXToRemove, 0, 0);
			yield return new WaitForEndOfFrame ();
		}
		yield return 0;
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
	protected GameObject findClosestTree() {
		return findClosestGameObject("Tree");
	}

	protected GameObject findClosestGameObject(string tag) {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag(tag);
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

	//return the gameobject of the player number in parameter
	protected PlayerMain findPlayerNumber(float playerNum) {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Player");
		PlayerMain result = null;
		foreach (GameObject go in gos) {
			if (go.GetComponent<PlayerMain>().playerNum == playerNum) {
				result = go.GetComponent<PlayerMain>();
			}
		}
		return result;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "bullet") {
			GameObject bulletGO = other.gameObject;
			takeDamage(bulletGO.GetComponent<Bullet>().damage);
			PlayerMain pm = findPlayerNumber(bulletGO.GetComponent<Bullet>().playerNum);
			if (pm != null){
				//pm.score += 1;
			}
			StartCoroutine(DestroyBullet(bulletGO));
		}
	}

	IEnumerator DestroyBullet(GameObject b)
	{
		//ici jouer les animations de mort avant la destruction
		Destroy(b);
		//yield return new WaitForEndOfFrame ();
		yield return 0;
	}

}
