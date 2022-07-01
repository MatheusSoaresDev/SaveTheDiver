using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{
	public float time;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		time += 1 * Time.deltaTime;
		if (time > 1) 
		{
			Destroy(gameObject);
		}
	}
}
