﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float playerId;
	public float damage;
	public  float speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward *Time.deltaTime*speed);
	}
}
