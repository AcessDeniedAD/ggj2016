using UnityEngine;
using System.Collections;

public class up_effect : MonoBehaviour {
	private float timer = 0 ;// TODO delete
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void _launch_effect()
	{
		StartCoroutine (launch_effect ());
	}
	IEnumerator launch_effect(){
		Vector3 target = new Vector3 (10, 15, 10); //(tree.transform.localScale.x+2,tree.transform.localScale.y+2,tree.transform.localScale.z+2);
		float deltaTimeToEnd = 0.3f;
		while (transform.localScale.x < target.x) {
			float scaleXToAdd = Time.deltaTime * target.x / deltaTimeToEnd;
			float scaleYToAdd = Time.deltaTime * target.y / deltaTimeToEnd;
			float scaleZToAdd = Time.deltaTime * target.z / deltaTimeToEnd;
			transform.localScale += new Vector3 (scaleXToAdd, scaleYToAdd, scaleZToAdd);
			yield return 0 ;
		}
		Renderer renderer = gameObject.GetComponent<Renderer> ();
		while (renderer.material.color.a > 0) {

			renderer.material.color -= new Color(0,0,0,5*Time.deltaTime);
			yield return 0 ;
		}
		Destroy (gameObject);
		yield return 0;
		
	}
}
