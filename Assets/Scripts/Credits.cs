using UnityEngine;
using System.Collections;
using InControl;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var inputDevice = InputManager.ActiveDevice;

		if (inputDevice.Action2.WasPressed) 
		{
			Application.LoadLevel("Menu");
		}
	}
	public void onClickButtonFB_RICHARD()
	{
		Application.OpenURL("https://www.facebook.com/guerci?fref=tsm");
	}
	public void onClickButtonFB_STRIK()
	{
		Application.OpenURL("https://www.facebook.com/StRiK.WTF?fref=ts");
	}
	public void onClickButtonFB_GAMAY()
	{
		Application.OpenURL("https://www.facebook.com/maxime.gammaitoni1");
	}
	public void onClickButtonFB_John()
	{
		Application.OpenURL("https://www.facebook.com/john.touba?fref=ts");
	}
	public void onClickButtonTW_RICHARD()
	{
		Application.OpenURL("www.google.com");
	}
	public void onClickButtonTW_JOHN()
	{
		Application.OpenURL("www.google.com");
	}
	public void onClickButtonTW_STRIK()
	{
		Application.OpenURL("www.google.com");
	}
	public void onClickButtonTW_GAMAY()
	{
		Application.OpenURL("https://twitter.com/YourGamay");
	}
	public void onClickButtonLI_GAMAY()
	{
		Application.OpenURL("");
	}
	public void onClickButtonLI_STRIK()
	{
		Application.OpenURL("www.google.com");
	}
	public void onClickButtonLI_RICHARD()
	{
		Application.OpenURL("www.google.com");
	}
	public void onClickButtonLI_JOHN()
	{
		Application.OpenURL("www.google.com");
	}

}
