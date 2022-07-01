using UnityEngine;
using System.Collections;

public class Oxygen : MonoBehaviour 
{
	public float VelScale;

	public bool Aumentar;
	public static bool FinishOxygen;

	public static Player instance;
	
	// Use this for initialization
	void Start () 
	{
		Aumentar = false;
		VelScale = 0.05f;

		FinishOxygen = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Player.UpOxygen == false)
		{
			transform.localScale -= new Vector3(VelScale * Time.deltaTime,0,0);
		}
		if(Player.UpOxygen == true)
		{
			transform.localScale += new Vector3(VelScale * Time.deltaTime,0,0);
		}
		if(transform.localScale.x > 1.459f && Player.Position.y > 3.20f)
		{
			VelScale = 0;
		}
		if(transform.localScale.x > 1.459 && Player.Position.y < 3.20)
		{
			VelScale = 0.05f;
		}

		if (transform.localScale.x < 0) 
		{
			FinishOxygen = true;
			VelScale = 0;
		}
	}
}
