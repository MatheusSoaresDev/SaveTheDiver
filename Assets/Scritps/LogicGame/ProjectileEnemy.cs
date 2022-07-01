using UnityEngine;
using System.Collections;

public class ProjectileEnemy : MonoBehaviour 
{
	public Rigidbody2D Force;
	// Use this for initialization
	void Start () 
	{
		Force = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Force.velocity -= new Vector2 (1, 0);
		if(transform.position.x < -10)
		{
			Destroy(gameObject);
		}
	}
}
