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
		Application.OpenURL("https://www.linkedin.com/in/rguerci?authType=NAME_SEARCH&authToken=ZJkp&locale=fr_FR&trk=tyah&trkInfo=clickedVertical%3Amynetwork%2CclickedEntityId%3A151262147%2CauthType%3ANAME_SEARCH%2Cidx%3A1-1-1%2CtarId%3A1454346733657%2Ctas%3Arichard%20guerci");
	}
	public void onClickButtonLI_JOHN()
	{
		Application.OpenURL("www.google.com");
	}

}
