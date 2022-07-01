using UnityEngine;
using System.Collections;

public class Whale : MonoBehaviour 
{
	public Rigidbody2D baleia;
	private Vector2 speed;
	public Transform ExplosionEnemy;

	public float timeExploded;

	public static EnemyRight instance;


	// Use this for initialization
	void Start () 
	{
		baleia = GetComponent<Rigidbody2D>();
		speed = new Vector2(-3, 0);
		timeExploded = (Random.Range (2, 6));
	}
	
	// Update is called once per frame
	void Update () 
	{
		baleia.MovePosition (baleia.position + speed * Time.fixedDeltaTime);

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
