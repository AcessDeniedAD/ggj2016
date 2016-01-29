using UnityEngine;
using System.Collections;

public class Item2 : ItemMain {

	private GameObject player;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override void getSkill (Transform playerPos)
	{
		playerPos.gameObject.GetComponent<Renderer> ().material.color = Color.red;
	}
}
