using UnityEngine;
using System.Collections;

public class CameraRay : MonoBehaviour {

	public GameObject tree;
	public Renderer rende;

	// Use this for initialization
	void Start () {
		rende = tree.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerStay(Collider col)
	{	
		if(rende != null)
		rende.material.color = new Color(rende.material.color.r,rende.material.color.g,rende.material.color.b,0.5f);
	}
	void OnTriggerExit(Collider col)
	{
		if(rende != null)
		rende.material.color = new Color(rende.material.color.r,rende.material.color.g,rende.material.color.b,1f);
	}
	public void reSetTree()
	{
		rende= tree.GetComponent<Renderer> ();
	}
}
