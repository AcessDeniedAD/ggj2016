using UnityEngine;
using System.Collections;

public class TriggerBarForUI : MonoBehaviour {

	public GameObject player;
	private bool isOccuped=false; 
	[HideInInspector] public PlayerMain playerMain;

	// Use this for initialization
	void Start () {
		playerMain=	player.GetComponent<PlayerMain>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isOccuped) 
		{
			playerMain.LettersId = "none";
		}
	}
	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "letters") 
		{
			playerMain.LettersId = other.gameObject.GetComponent<Letters>().id;
			playerMain.LettersGameObj = other.gameObject;
			isOccuped = true;
		}
		
	}
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "letters") 
		{
			isOccuped=false;
			
		}
		
	}
}
