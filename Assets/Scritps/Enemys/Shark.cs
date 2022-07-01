using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour 
{
	public Rigidbody2D shark;
	private Vector2 speed;

	public Transform ExplosionEnemy;

	public static EnemyRight instance;

	public float timeExploded;
	
	// Use this for initialization
	void Start () 
	{
		shark = GetComponent<Rigidbody2D>();

		speed = new Vector2(-3, 0);
		timeExploded = (Random.Range (2, 6));
	}
	
	// Update is called once per frame
	void Update () 
	{
		shark.MovePosition (shark.position + speed * Time.fixedDeltaTime);

		if(transform.position.x < -10)
		{
			Destroy(gameObject);
		}
		if(transform.position.x < -10)
		{
			Destroy(gameObject);
		}
		if (EnemyRight.Perdeu == true) 
		{
			timeExploded -= 1 * Time.deltaTime;
		}
		if (timeExploded < 0)
		{
			Instantiate(ExplosionEnemy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D (Collider2D coll)
	{
		if(coll.gameObject.tag == "ProjectileLeft")
		{
			Instantiate(ExplosionEnemy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Destroy(gameObject);
		}
		if(coll.gameObject.tag == "ProjectileRight")
		{
			Instantiate(ExplosionEnemy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
