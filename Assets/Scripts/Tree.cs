using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Tree : MonoBehaviour {
	public static bool test;
	#region Attributes creation 
	// Public attributes
	public float treelife;
	public float max_maturity;
	public float up_vitesse;
	public GameObject[] treeObject;
	public GameObject effect_up;
	public float total_maturity = 0;
	private CameraRay cameraRay;
	private GameObject player1;
	private GameObject player2;
	// Private attributes
	private float _current_maturity = 0;
	private int _tree_level = 1;
	private float _tree_life;


	#endregion

	#region Unity method 
	// Use this for initialization
	void Start () {
		_tree_life = treelife;
		GameObject.Find ("Player").GetComponent<PlayerMain> ().InOnThisTree = gameObject;
		GameObject.Find ("Player2").GetComponent<PlayerMain> ().InOnThisTree = gameObject;
		GameObject.Find ("Jauge1Mat").GetComponent<Turn> ().tree = gameObject;
		GameObject floor = GameObject.FindGameObjectWithTag("floor");
		floor.GetComponent<SceneManager>().current_tree.Add(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			EnnemisMain enemy = other.GetComponent<EnnemisMain>();
			//take_dammage(enemy);
			enemy.hasReachTheTree = true;
		}
		if (other.tag == "bullet") {
			GameObject bulletGO = other.gameObject;
			StartCoroutine(DestroyBullet(bulletGO));
		}
	}
	IEnumerator DestroyBullet(GameObject b)
	{
		//ici jouer les animations de mort avant la destruction
		Destroy(b);
		//yield return new WaitForEndOfFrame ();
		yield return 0;
	}

	#endregion

	#region Public method
	public void take_dammage(EnnemisMain enemy){
		_tree_life -= enemy.damage;


		if (_tree_life <= 0){
			Application.LoadLevel("Menu");
			Debug.Log ("End game");
		}

	}
	/// <summary>
	/// Up the maturity tree value
	/// </summary>
	/// <param name="maturity_to_up">Float value to increase maturity tree</param>
	public void up_maturity(float maturity_to_up){
		if (_tree_life != 0) {
			if (max_maturity > _current_maturity && (_current_maturity +  (maturity_to_up*treeObject.Length)) < max_maturity) {
				total_maturity += maturity_to_up;
				_current_maturity += (maturity_to_up * treeObject.Length);
			}
			else if((_current_maturity + (maturity_to_up*treeObject.Length)) > max_maturity && _current_maturity < max_maturity){
				total_maturity += maturity_to_up;
				_current_maturity = max_maturity;
			}
			else{
				Debug.Log("You're fucking tree are full maturity");
			}
			Debug.Log(_current_maturity);
			if (total_maturity > max_maturity)
				total_maturity = max_maturity;
			if (_current_maturity == max_maturity) {
				up_level_tree();
				_current_maturity = total_maturity % (max_maturity / treeObject.Length);
			}
		}

	}
	
	/// <summary>
	/// Down the maturity tree value
	/// </summary>
	/// <param name="maturity_to_down">Float value to reduce maturity tree</param>
	public void down_maturity(float maturity_to_down){
		if (_tree_life != 0) {
			if (_current_maturity != 0 && (_current_maturity - maturity_to_down) >= 0) {
				_current_maturity -= maturity_to_down;
			} else if ((_current_maturity - maturity_to_down) < max_maturity && _current_maturity != 0) {
				_current_maturity = max_maturity;
			} else {
				Debug.Log ("You're fucking tree has no maturity");
			}
		}
	}
	#endregion

	#region Private method
	private void up_level_tree(){
		if (treeObject.Length != _tree_level) {
			int before_level = _tree_level;
			float before_life = _tree_life;
			float before_total_maturity = total_maturity;
			GameObject[] before_treeObject = treeObject;
			Vector3 spawn_position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
			Destroy (this.gameObject);
			Quaternion spawn_orientation = Quaternion.identity;
			GameObject go = Instantiate (treeObject [before_level], spawn_position, spawn_orientation) as GameObject;
			Tree tree = go.GetComponent<Tree>();
			tree.Tree_level = before_level +1 ;
			tree.Tree_life = before_life ;
			tree.total_maturity = before_total_maturity ;
			tree.treeObject = before_treeObject ;
			GameObject floor = GameObject.FindGameObjectWithTag("floor");
			int i;
			for(i=0; i < floor.GetComponent<SceneManager>().current_tree.Count;i++){
				GameObject curr_tree = floor.GetComponent<SceneManager>().current_tree[i];
				if (curr_tree.GetComponent<Tree>().Current_maturity == tree.max_maturity){
					floor.GetComponent<SceneManager>().current_tree[i] = go;
					Vector3 spawn_position2 = new Vector3 (go.transform.position.x, go.transform.position.y +1, go.transform.position.z);
					Quaternion spawn_orientation2 = Quaternion.identity;
					GameObject goTemp = Instantiate (effect_up, spawn_position2, spawn_orientation2) as GameObject;
					goTemp.GetComponent<up_effect>()._launch_effect();
				}

			}
		} else {
			//TODO end the game
			bool is_end_game = true;
			GameObject floor = GameObject.FindGameObjectWithTag("floor");
			foreach (GameObject tree in floor.GetComponent<SceneManager>().current_tree)
			{
				if(tree.GetComponent<Tree>().total_maturity != 100){
					is_end_game = false;
					break;
				}
			}
			if (is_end_game == true){
				SceneManager.end_game = true;
				Debug.Log ("End game");
			}
		}

	}



	#endregion

	public float Current_maturity
	{
		get { return _current_maturity ; }
	}

	public int Tree_level
	{
		get { return _tree_level ; }
		set { _tree_level = value; }
	}

	public float Tree_life
	{
		get { return _tree_life ; }
		set { _tree_life = value; }
	}
}