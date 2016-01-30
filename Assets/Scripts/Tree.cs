using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	#region Attributes creation 
	// Public attributes
	public float treelife;
	public float max_maturity;
	public float up_vitesse;

	// Private attributes
	private float _current_maturity = 0;
	private int _tree_level;
	private float _tree_life;
	private float timer = 0 ;// TODO delete
	#endregion

	#region Unity method 
	// Use this for initialization
	void Start () {
		_tree_life = treelife;
	}
	
	// Update is called once per frame
	void Update () {
		// TODO to delete
		timer += Time.deltaTime;
		if (timer > 0.5) {
			timer  = 0;
			up_maturity(3.5f);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			EnnemisMain enemy = other.GetComponent<EnnemisMain>();
			take_dammage(enemy);
			enemy.hasReachTheTree = true;

		}
	}
	#endregion

	#region Public method
	public void take_dammage(EnnemisMain enemy){

		_tree_life -= enemy.damage;
		if (_tree_life == 0) {
			// TODO Call loose scene 
			Debug.Log("Your tree is dead");
		}

	}

	/// <summary>
	/// Up the maturity tree value
	/// </summary>
	/// <param name="maturity_to_up">Float value to increase maturity tree</param>
	public void up_maturity(float maturity_to_up){
		if (_tree_life != 0) {
			if (max_maturity > _current_maturity && (_current_maturity + maturity_to_up) < max_maturity) {
				_current_maturity += maturity_to_up;
			}
			else if((_current_maturity + maturity_to_up) > max_maturity && _current_maturity < max_maturity){
				_current_maturity = max_maturity;
			}
			else{
				Debug.Log("You're fucking tree are full maturity");
			}

			if (_current_maturity == max_maturity) {
				up_level_tree();
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
		// TODO

		// Method to up level of tree
	}
	#endregion

	public float Current_maturity
	{
		get { return _current_maturity; }
		set { _current_maturity = value; }
	}
}