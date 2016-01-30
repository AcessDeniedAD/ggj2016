using UnityEngine;
using System.Collections;

public class CameraRay : MonoBehaviour {

	public GameObject player;
	private Renderer rende;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3  screenPos = Camera.main.WorldToScreenPoint (player.transform.position);
		Ray ray = Camera.main.ScreenPointToRay(screenPos);
		//Debug.DrawRay (ray.origin, ray.direction *  50, Color.yellow);
		//float distanceToGround = 0;
		
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100)) {
			Debug.DrawLine(ray.origin, hit.point);
			if(hit.collider.tag =="Tree")
			{
				rende = hit.collider.gameObject.GetComponent<Renderer>();
				rende.material.color = new Color(rende.material.color.r,rende.material.color.g,rende.material.color.b,0.5f);
				
			}
			else
			{
				//rende = hit.collider.gameObject.GetComponent<Renderer>();
				if(rende!=null)
					rende.material.color = new Color(rende.material.color.r,rende.material.color.g,rende.material.color.b,1f);
			}
		}
		
		
		




	}
}
