using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pontuation : MonoBehaviour 
{
	public Text exp;
	public Text Record;

	public static Player instance;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		exp.text = " " + Player.exp;
		Record.text = " " + PlayerPrefs.GetInt("PlayerRecord");
	}
}
