using UnityEngine;
using System.Collections;
using InControl;

public class PlayerMain : MonoBehaviour
{
	public float HP ;
	public int playerNum;
	public AudioClip deathSound;
	public float speed=5;
	public GameObject buttonXSign;
	public GameObject bullet;
	public GameObject JaugeInputPlayer1;
	public GameObject iconSign;
	public RythmeScript rythmeScript;
	[HideInInspector]public string LettersId ="none";
	[HideInInspector]public bool isAlive = true;
	[HideInInspector]public Animator animator;
	[HideInInspector]public AudioSource audioSource;
	[HideInInspector] public GameObject LettersGameObj;
	[HideInInspector]public bool defeatIncant;
	private float rateOfFire=0.19f;
	//[HideInInspector]public 
	private float timeBeetween2Frames = 0;
	private float timer;
	private float timerForShoot=0.3f;
	public GameObject InOnThisTree;
	[HideInInspector]public bool canIncant=false;
	private bool isIncant = false;
	private Transform forAnimate;
	private Animator forAnimateAnimator;
	public GameObject rainGo;


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
		forAnimate = transform.FindChild("Chara");
		forAnimateAnimator = forAnimate.GetComponent<Animator> ();
		animator =gameObject.GetComponent<Animator> ();
		audioSource =gameObject.GetComponent<AudioSource> ();
	}
	void Update()
	{
		if (isIncant) {

			rainGo.GetComponent<ParticleSystem>().enableEmission=true;

		} else 
		{
			rainGo.GetComponent<ParticleSystem>().enableEmission = false;
		}
		//----------------Si le joueur rate un incantation
		if (defeatIncant) 
		{
			defeatIncant=false;
			JaugeInputPlayer1.GetComponent<Animator>().SetBool("canDie",true);
			isIncant = false;
			LettersId="none";
			rythmeScript.DestroyLetters();
		}
		//------------------------------------------------
		var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
		if (inputDevice == null)
		{
			//Debug.LogError("Pas de manette detectée");
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
			//takeDamage(50);
			timer=0;
		}
		//-------------------------------------
	}
	void UpdateCubeWithInputDevice( InputDevice inputDevice )
	{
		// Set object material color based on which action is pressed.
		/*if (inputDevice.Action1.WasPressed)
		{
			if(skill1 != null && isAlive)
			skill1(transform);
		}*/
		if (canIncant && inputDevice.Action3.WasPressed && SceneManager.canUseMana()) 
		{
			SceneManager.useMana();
			buttonXSign.SetActive(false);
			JaugeInputPlayer1.SetActive(true);
			JaugeInputPlayer1.GetComponent<Animator>().SetBool("canDie",false);
			rythmeScript.SetInputPos();
			isIncant = true;
			canIncant=false;
		}
		if ( isIncant && inputDevice.Action1.WasPressed && LettersId=="a" ) 
		{

			InOnThisTree.GetComponent<Tree>().up_maturity(3);
			StartCoroutine(iconOK());
			if(LettersGameObj!=null)
			LettersGameObj.GetComponent<Letters>().goDestroy();
			if(LettersGameObj.GetComponent<Letters>() != null && LettersGameObj.GetComponent<Letters>().lastLetters)
			{

				JaugeInputPlayer1.GetComponent<Animator>().SetBool("canDie",true);
				isIncant = false;
				LettersId="none";
				rythmeScript.DestroyLetters();
				canIncant = true;
				buttonXSign.SetActive(true);

			}
		}
		if (isIncant && inputDevice.Action2.WasPressed && LettersId=="b") 
		{
			InOnThisTree.GetComponent<Tree>().up_maturity(3);
			StartCoroutine(iconOK());
			if(LettersGameObj!=null)
			LettersGameObj.GetComponent<Letters>().goDestroy();
			if(LettersGameObj.GetComponent<Letters>().lastLetters)
			{
				JaugeInputPlayer1.GetComponent<Animator>().SetBool("canDie",true);
				isIncant = false;
				LettersId="none";
				rythmeScript.DestroyLetters();
				canIncant = true;
				buttonXSign.SetActive(true);
			}
		}
		if (isIncant && inputDevice.Action3.WasPressed && LettersId=="x") 
		{
			InOnThisTree.GetComponent<Tree>().up_maturity(3);
			StartCoroutine(iconOK());
			if(LettersGameObj!=null)
			LettersGameObj.GetComponent<Letters>().goDestroy();
			if(LettersGameObj.GetComponent<Letters>().lastLetters)
			{
				JaugeInputPlayer1.GetComponent<Animator>().SetBool("canDie",true);
				isIncant = false;
				LettersId="none";
				rythmeScript.DestroyLetters();
				canIncant = true;
				buttonXSign.SetActive(true);
			}
		}
		if (isIncant && inputDevice.Action4.WasPressed && LettersId=="y") 
		{
			InOnThisTree.GetComponent<Tree>().up_maturity(3);
			StartCoroutine(iconOK());
			if(LettersGameObj!=null)
			LettersGameObj.GetComponent<Letters>().goDestroy();
			if(LettersGameObj.GetComponent<Letters>().lastLetters)
			{

				JaugeInputPlayer1.GetComponent<Animator>().SetBool("canDie",true);
				isIncant = false;
				LettersId="none";
				rythmeScript.DestroyLetters();
				canIncant = true;
				if(SceneManager.canUseMana())
				buttonXSign.SetActive(true);
			}
		}
		//----DEPLACEMENT
		if (!isIncant) 
		{
			gameObject.transform.position += new Vector3 (inputDevice.LeftStickX * Time.deltaTime*speed, 0, inputDevice.LeftStickY * Time.deltaTime*speed );
			if (Mathf.Abs (inputDevice.LeftStickX) >= 0.19 || Mathf.Abs (inputDevice.LeftStickY) >= 0.19) {
				forAnimateAnimator.SetBool("isWalking",true);
				transform.rotation = Quaternion.Euler (new Vector3 (0, Mathf.Atan2 (inputDevice.LeftStickX, inputDevice.LeftStickY) * Mathf.Rad2Deg, 0));
			}
			else
			{
				forAnimateAnimator.SetBool("isWalking",false);
			}
			if (Mathf.Abs (inputDevice.RightStickX) >= 0.65 || Mathf.Abs (inputDevice.RightStickY) >= 0.65) {
				//timer += Time.deltaTime;
				
				transform.rotation = Quaternion.Euler (new Vector3 (0, Mathf.Atan2 (inputDevice.RightStickX, inputDevice.RightStickY) * Mathf.Rad2Deg, 0));
				
				//___________SHOOTING__________________
				shootBullet();
				//______________________________________
				
			}
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
	//_________________TRIGGERING_____________________________________
	void OnTriggerEnter(Collider col)
	{

		if (col.tag == "IncatationArea") {
			InOnThisTree =  col.gameObject.GetComponent<IncantationArea>().assignedTree;
			buttonXSign.SetActive(true);
			canIncant = true;
		}
		else if(col.tag=="Enemy")
		{
			Destroy (col.gameObject);
			//setSkill1 (col.gameObject.GetComponent<ItemMain> ().getSkill); 
		}
	}
	void OnTriggerExit(Collider col)
	{
		if (col.tag == "IncatationArea") {
			buttonXSign.SetActive(false);
			canIncant = false;
		}
	}
	//_____________________________________________________________________

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
				GameObject bulletGO = Instantiate (bullet, new Vector3( transform.position.x, transform.position.y+2,transform.position.z), transform.rotation) as GameObject;
				bulletGO.GetComponent<Bullet>().playerNum = playerNum;
				bulletGO.GetComponent<Bullet>().damage = 100;
				timerForShoot = 0;
			}	
		}
	}
	IEnumerator iconOK()
	{
		if (LettersId != "none") 
		{
			float t= Time.deltaTime;
			iconSign.SetActive (true);
			Vector3 saveScale = iconSign.transform.localScale;
			while (iconSign.transform.localScale.x<saveScale.x *1.5) 
			{
				iconSign.transform.localScale+=new Vector3(t*2.5f,t*2.5f,t*2.5f);
				yield return 0 ;
			}
			yield return 0;
			iconSign.SetActive (false);
			iconSign.transform.localScale = saveScale;
		}

	}
}
