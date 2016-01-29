using UnityEngine;
using System.Collections;
using InControl;

public class PlayerMain : MonoBehaviour
{
	public float HP ;
	public int playerNum;
	public AudioClip deathSound;
	public float speed=5;
	public GameObject bullet;
	[HideInInspector]public bool isAlive = true;
	[HideInInspector]public Animator animator;
	[HideInInspector]public AudioSource audioSource;
	private float rateOfFire=0.2f;
	//[HideInInspector]public 

	private float timeBeetween2Frames = 0;
	private float timer;
	private float timerForShoot=0;

	public delegate void CallBackMethode(Transform playerPos);
	CallBackMethode skill1;

	public PlayerMain()
	{
		HP = 100;
		isAlive = true;
		animator = animator;
		speed = 5;
	}
	void Start()
	{
		animator =gameObject.GetComponent<Animator> ();
		audioSource =gameObject.GetComponent<AudioSource> ();
	}
	void Update()
	{
		var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
		if (inputDevice == null)
		{
			Debug.LogError("Pas de manette detectée");
		}
		else
		{
			UpdateCubeWithInputDevice( inputDevice );//LES INPUT SONT DANS CETTE METHODE
		}
		//---------TEST TAKE DAMAGE-----------
		timeBeetween2Frames = Time.deltaTime;
		timer += timeBeetween2Frames;
		if (timer > 2) 
		{
			takeDamage(50);
			timer=0;
		}
		//-------------------------------------
	}
	void UpdateCubeWithInputDevice( InputDevice inputDevice )
	{
		// Set object material color based on which action is pressed.
		if (inputDevice.Action1.WasPressed)
		{
			if(skill1 != null && isAlive)
			skill1(transform);
		}
		//----DEPLACEMENT
		gameObject.transform.position += new Vector3 (inputDevice.LeftStickX * Time.deltaTime*speed, 0, inputDevice.LeftStickY * Time.deltaTime*speed );
		if (Mathf.Abs (inputDevice.LeftStickX) >= 0.19 || Mathf.Abs (inputDevice.LeftStickY) >= 0.19) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, Mathf.Atan2 (inputDevice.LeftStickX, inputDevice.LeftStickY) * Mathf.Rad2Deg, 0));
		}
		if (Mathf.Abs (inputDevice.RightStickX) >= 0.65 || Mathf.Abs (inputDevice.RightStickY) >= 0.65) {
			//timer += Time.deltaTime;

			transform.rotation = Quaternion.Euler (new Vector3 (0, Mathf.Atan2 (inputDevice.RightStickX, inputDevice.RightStickY) * Mathf.Rad2Deg, 0));

			//___________SHOOTING__________________
			shootBullet();
			//______________________________________
				
		}
	}
	public void takeDamage(float damage)//---------------PRISE DE DEGAT (ou gain si la value en parametre est negative)
	{
		HP -= damage;
		if (HP <= 0 && isAlive) 
		{
			StartCoroutine(setDestroy());
		}
		Debug.Log ("player as : "+ HP+" HP");
	}
	IEnumerator setDestroy()//------------------- ANIMATION PUIS DESTRUCTION DE L'OBJET
	{
		isAlive = false;
		audioSource.PlayOneShot (deathSound);
		//ici jouer les animations de mort avant la destruction 
		animator.SetBool ("canDie", true);
		yield return new WaitForSeconds (3);
		Destroy(gameObject);
		yield return 0;
	}
	void OnTriggerEnter(Collider col)
	{

		if (col.tag == "IncantationArea") {
			Debug.Log ("doihfeiughfdiuoghfduykgveyfd,hngin,fdmohtrfminhhniov");
		}
		else 
		{
			Destroy (col.gameObject);
			setSkill1 (col.gameObject.GetComponent<ItemMain> ().getSkill); 
		}
	}
	public void setSkill1(CallBackMethode p_callBackExecution)
	{
		skill1 = new CallBackMethode (p_callBackExecution);//set le comportement du skill 
	}
	public void shootBullet()
	{
		if(isAlive)
		{
			timerForShoot += Time.deltaTime;
			Debug.Log (rateOfFire);
			if (timerForShoot >= rateOfFire) 
			{
				GameObject go = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
				timerForShoot = 0;
			}	
		}
	}
}
