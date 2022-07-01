using UnityEngine;
using System.Collections;

public class SubmarineEnemy : MonoBehaviour 
{
	private Rigidbody2D enemySubmarine;
	private Vector2 speed;

	private float Shoot;
	private bool CanShoot;

	public Transform Projectile;
	public Transform ExplosionEnemy;

	public static EnemyRight instance;

	public float timeExploded;

	// Use this for initialization
	void Start () 
	{
		enemySubmarine = GetComponent<Rigidbody2D>();
		speed = new Vector2(-3, 0);

		Shoot = 3;
		CanShoot = true;
		timeExploded = (Random.Range (2, 6));
	}
	
	// Update is called once per frame
	void Update () 
	{
		enemySubmarine.MovePosition (enemySubmarine.position + speed * Time.fixedDeltaTime);

		Shoot -= 1 * Time.deltaTime;
		if(Shoot < 1 && CanShoot == true)
		{
			Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			CanShoot = false;
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
