using UnityEngine;
using System.Collections;

public class ItemMain : MonoBehaviour {

	public ItemMain()
	{

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public virtual void getSkill(Transform playerPos)
	{
		Debug.LogError ("------------NO SKILL SET FOR THIS ITEM  : "+gameObject.name+" ----------------");
		Debug.Break ();
	}
}
