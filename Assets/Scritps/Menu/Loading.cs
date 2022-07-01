using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour 
{
	public float time;
	// Use this for initialization
	void Start () 
	{
		time = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		time += 1 * Time.deltaTime;

		if (time > 7) 
		{
			Application.LoadLevel("Game");
		}
	}
}
