using UnityEngine;
using System.Collections;

public class ProjectileLeft : MonoBehaviour 
{
	public Rigidbody2D Force;
	public static Player instance;
	// Use this for initialization
	void Start () 
	{
		Force = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameObject.tag == "ProjectileLeft")
		{
			Force.velocity -= new Vector2 (15, 0);
		}
		if(transform.position.x > 10)
		{
			Destroy(gameObject);
		}
		if(transform.position.x < -10)
		{
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Shark")
		{
			Player.exp += 20;
			Destroy(gameObject);
		}
		if(coll.gameObject.tag == "Submarine")
		{
			Player.exp += 10;
			Destroy(gameObject);
		}
		if(coll.gameObject.tag == "Whale")
		{
			Player.exp += 30;
			Destroy(gameObject);
		}
	}
}