using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SceneManager : MonoBehaviour {
	public int nb_tree;
	public List<GameObject> current_tree;
	public static bool end_game;
	public static int scorePlayer1 = 0;
	public static int scorePlayer2 = 0;
	public static bool start;
	private float timerForStart=3;
	private float t=0;
	private static float mana = 0;

	public static void addMana(int m){
		if ((m + mana) > 100) {
			mana = 100;
		} else {
			mana += m;
		}
	}

	public static float getMana(){
		return mana;
	}

	public static bool canUseMana(){
		if (mana >= 20) {
			return true;
		} else {
			return false;
		}
	}

	public static void useMana(){
		if (canUseMana ()) {
			addMana(-20);
		}
	}


	// Use this for initialization
	void Start () {
		start = true;
		end_game = false;
		Debug.Log ("I'm here");
		List<GameObject> current_tree = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
