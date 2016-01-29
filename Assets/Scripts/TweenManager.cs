
using UnityEngine;
using System.Collections;

public class TweenManager : MonoBehaviour
{
	// Canvas

	public Canvas m_Canvas;
	public GEAnim Ricardo;
	public GEAnim John;
	public GEAnim Gamay;
	public GEAnim Strik;
	public GEAnim AccesLogo;

	void Awake ()
	{
		if(enabled)
		{
			GEAnimSystem.Instance.m_AutoAnimation = false;
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(MoveInTitleGameObjects());
		// Disable all scene switch buttons
		//GEAnimSystem.Instance.SetGraphicRaycasterEnable(m_Canvas, false);
		
	}
	// Update is called once per frame
	void Update ()
	{
		
	}
	// MoveIn m_Title1 and m_Title2
	IEnumerator MoveInTitleGameObjects()
	{
		yield return new WaitForSeconds(1.0f);
		
		// MoveIn m_Title1 and m_Title2
		Ricardo.MoveIn(eGUIMove.SelfAndChildren);
		John.MoveIn(eGUIMove.SelfAndChildren);
		Gamay.MoveIn(eGUIMove.SelfAndChildren);
		Strik.MoveIn(eGUIMove.SelfAndChildren);
		AccesLogo.MoveIn(eGUIMove.SelfAndChildren);

	}
	

	

}