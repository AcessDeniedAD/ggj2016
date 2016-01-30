using UnityEngine;
using System.Collections;

public class Letters : MonoBehaviour {

	[HideInInspector]public float speed;
	[HideInInspector]public bool lastLetters=false;
	[HideInInspector]public bool isOkay=false;
	public string id ="";
	// Use this for initialization
	void Start () {
		speed = 5;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3 (0, Screen.width/speed * Time.deltaTime, 0);
	}
	public void goDestroy()
	{
		StartCoroutine (setDestroy ());
	}
	IEnumerator setDestroy()
	{
		isOkay = true;
		float t = Time.deltaTime;
		while (gameObject.transform.localScale.y>0) 
		{
			gameObject.transform.localScale-=new Vector3(t*5,t*5,t*5);
			yield return 0 ;
		}
		Destroy(gameObject);
		yield return 0;
	}
}
