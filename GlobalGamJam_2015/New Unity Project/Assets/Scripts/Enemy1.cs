﻿using UnityEngine;
using System.Collections;

public class Enemy1 : EnnemisMain {

	private float timer = 0 ;
	private float timeBeetween2Frames;
	// Use this for initialization
	void Start () {
		animator =gameObject.GetComponent<Animator> ();
		audioSource =gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeBeetween2Frames = Time.deltaTime;
		timer += timeBeetween2Frames;
		if (timer > 2) 
		{
			takeDamage(100);
			timer=0;
		}
	}
}