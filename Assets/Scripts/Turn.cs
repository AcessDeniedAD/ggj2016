using UnityEngine;
using System.Collections;

public class Turn : MonoBehaviour
{
	float mfX;
	float mfY;
	float mfZ;
	float OriScale100Pourcent;
	public GameObject tree;
	// Use this for initialization
	void Start ()
	{

		OriScale100Pourcent = transform.localScale.x;
		mfX = transform.position.x - transform.localScale.x/2.0f;
		mfY = transform.position.y ;
		mfZ = transform.position.z;
	}
	
	     // Update is called once per frame
	void Update () 
	{
		 //tree.GetComponent<Tree>().total_maturity
		Vector3 v3Scale =new Vector3 (tree.GetComponent<Tree>().total_maturity*OriScale100Pourcent/100,transform.localScale.y,transform.localScale.z);
		transform.localScale = new Vector3(v3Scale.x + Time.deltaTime , v3Scale.y , v3Scale.z);
		transform.position = new Vector3(mfX + transform.localScale.x / 2.0f, mfY, mfZ);
	}
}
