using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	#region Attributes creation 
	// Public attributes
	public float treelife;
	public float max_maturity;

	// Private attributes
	private float current_maturity;
	private int tree_level;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	#endregion

	#region Public method
	public void take_dammage(GameObject ennemy){
				
		EnnemisMain enemy = ennemy.GetComponent<EnnemisMain>();
		treelife -= enemy.damage;

	}

	/// <summary>
	/// Up the maturity tree value
	/// </summary>
	/// <param name="maturity_to_up">Float value to increase maturity tree</param>
	public void up_maturity(float maturity_to_up){

		if (max_maturity > current_maturity && (current_maturity + maturity_to_up) < max_maturity) {
			current_maturity += max_maturity;
		}
		else if((current_maturity + maturity_to_up) > max_maturity && current_maturity < max_maturity){
			current_maturity = max_maturity;
		}
		else{
			Debug.LogError("You're fucking tree are full maturity");
		}

		if (current_maturity == max_maturity) {
			up_level_tree()
		}

	}

	/// <summary>
	/// Down the maturity tree value
	/// </summary>
	/// <param name="maturity_to_down">Float value to reduce maturity tree</param>
	public void down_maturity(float maturity_to_down){

		if (current_maturity != 0 && (current_maturity - maturity_to_down) >= 0) {
			current_maturity -= max_maturity;
		}
		else if((current_maturity - maturity_to_down) < max_maturity && current_maturity != 0){
			current_maturity = max_maturity;
		}
		else{
			Debug.LogError("You're fucking tree has no maturity");
		}
	}
	#endregion

	#region Private method
	private void up_level_tree(){
		// Method to up level of tree
	}
	#endregion
}