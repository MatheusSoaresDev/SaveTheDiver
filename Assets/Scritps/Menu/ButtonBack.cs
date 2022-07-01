using UnityEngine;
using System.Collections;

public class ButtonBack : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	void OnMouseDown ()
	{
		if (PlayerPrefs.GetString ("UltimaCena") == "Home") 
		{
			Application.LoadLevel("Home");
		} else {
			Application.LoadLevel("GameOver");
		}
	}
}
