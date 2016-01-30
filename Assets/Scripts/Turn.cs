using UnityEngine;
using System.Collections;

public class Turn : MonoBehaviour
{
	float mfX;
	float mfY;
	float mfZ;
	// Use this for initialization
	void Start ()
	{
		mfX = transform.position.x - transform.localScale.x/2.0f;
		mfY = transform.position.y - transform.localScale.y/2.0f;
		mfZ = transform.position.z;
	}
	
	     // Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Vector3 v3Scale = transform.localScale;
			transform.localScale = new Vector3(v3Scale.x + 0.1f , v3Scale.y , v3Scale.z);
			transform.position = new Vector3(mfX + transform.localScale.x / 2.0f, mfY, mfZ);
		}
	}
	 }
