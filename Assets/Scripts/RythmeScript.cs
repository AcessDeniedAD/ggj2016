using UnityEngine;
using System.Collections;

public class RythmeScript : MonoBehaviour {

	public GameObject a;
	public GameObject b;
	public GameObject x;
	public GameObject y;	
	private int nbrInput=10;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void DestroyLetters()
	{
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Letters");
		for (int i = 0; i<=gos.Length; i++) 
		{
			Destroy(gos[i]);
		}
		
	}
	public void SetInputPos()
	{
		StartCoroutine (setInputPos ());
	}
	IEnumerator setInputPos()
	{
		yield return new WaitForSeconds (1f);
		for (int i = 0; i<=nbrInput; i++)
		{
			int rand =Random.Range(1,5);
			if(rand==1)
			{
				GameObject go = Instantiate(a,new Vector3(transform.position.x,transform.position.y+((Screen.height*15/100)*i),transform.position.z),Quaternion.identity) as GameObject;
				go.transform.SetParent(transform);
				go.transform.localScale = new Vector3(6,0.6f,0);
				go.transform.position+=new Vector3(0,Screen.height*50/100,0);
				go.GetComponent<Letters>().id = "a";
				if(i==nbrInput)
				{
					go.GetComponent<Letters>().lastLetters = true;
				}

				
			}
			else if(rand==2)
			{
				GameObject go = Instantiate(b,new Vector3(transform.position.x,transform.position.y+((Screen.height*15/100)*i),transform.position.z),Quaternion.identity) as GameObject;
				go.transform.SetParent(transform);
				go.transform.localScale = new Vector3(6,0.6f,0);
				go.transform.position+=new Vector3(0,Screen.height*50/100,0);
				go.GetComponent<Letters>().id = "b";
				if(i==nbrInput)
				{
					go.GetComponent<Letters>().lastLetters = true;
				}
			}
			else if(rand==3)
			{
				GameObject go = Instantiate(x,new Vector3(transform.position.x,transform.position.y+((Screen.height*15/100)*i),transform.position.z),Quaternion.identity) as GameObject;
				go.transform.SetParent(transform);
				go.transform.localScale = new Vector3(6,0.6f,0);
				go.transform.position+=new Vector3(0,Screen.height*50/100,0);
				go.GetComponent<Letters>().id = "x";
				if(i==nbrInput)
				{
					go.GetComponent<Letters>().lastLetters = true;
				}
			}
			else if(rand==4)
			{
				GameObject go = Instantiate(y,new Vector3(transform.position.x,transform.position.y+((Screen.height*15/100)*i),transform.position.z),Quaternion.identity) as GameObject;
				go.transform.SetParent(transform);
				go.transform.localScale = new Vector3(6,0.6f,0);
				go.transform.position+=new Vector3(0,Screen.height*50/100,0);
				go.GetComponent<Letters>().id = "y";
				if(i==nbrInput)
				{
					go.GetComponent<Letters>().lastLetters = true;
				}
			}
		}
	}
}
