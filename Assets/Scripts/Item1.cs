using UnityEngine;
using System.Collections;

public class Item1 : ItemMain {
	public GameObject bullet;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	public override void getSkill (Transform playerPos)
	{
		GameObject go = Instantiate (bullet,playerPos.position,Quaternion.identity) as GameObject;
	}
}
