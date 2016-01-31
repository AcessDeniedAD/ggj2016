using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaBar : MonoBehaviour {

	private Image image;

	// Use this for initiaslization
	void Start () {
		image = GetComponent<Image>();
	}

	// Update is called once per frame
	void Update () {
		image.fillAmount = SceneManager.getMana()/100.0f;
		if (SceneManager.canUseMana ()) {
			image.gameObject.GetComponent<Animator>().SetBool("becomeYellow", true);
		} else {
			image.gameObject.GetComponent<Animator>().SetBool("becomeYellow", false);
		}
	}
}
