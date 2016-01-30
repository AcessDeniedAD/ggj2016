using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SceneManager : MonoBehaviour {
	public int nb_tree;
	public List<GameObject> current_tree;
	public static bool end_game;

	// Use this for initialization
	void Start () {
		Debug.Log ("I'm here");
		List<GameObject> current_tree = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
