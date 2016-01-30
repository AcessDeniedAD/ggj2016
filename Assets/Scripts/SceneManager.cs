using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SceneManager : MonoBehaviour {
	public int nb_tree;
	public List<GameObject> current_tree;
	public static bool end_game;
	public static int scorePlayer1 = 0;
	public static int scorePlayer2 = 0;
	public static float mana = 0;

	// Use this for initialization
	void Start () {
		Debug.Log ("I'm here");
		List<GameObject> current_tree = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
