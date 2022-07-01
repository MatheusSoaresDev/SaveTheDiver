using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	public static EnemyRight instance;
	public static Oxygen instanciar;
	
	[Header("Boolean Variables")]
	public bool ShootRight;
	public bool dead;
	public bool CanShoot;
	public bool reloading;
	public static bool UpOxygen;

	[Header("Transform, GameObjects Variables")]
	public Transform projectileLeft;
	public Transform projectileRight;
	public GameObject Explosion;
	public static Vector3 Position;
	public GameObject MunitionGO;

	[Header("Sprite Variables")]
	public Sprite Left;
	public Sprite Right;
	public SpriteRenderer LeftComponent;
	public SpriteRenderer RightComponent;
	public Animator Exploded;

	[Header("Numbers Variables")]
	public float velocity;
	public float TimeReloadingMunition;
	public int munition;
	public static int exp;
	public static int Record;

	[Header("Text Variables")]
	public GUIStyle ExpStyle;
	public Text Points;
	public Text MunitionText;
	
	[Header("Sound Variables")]
	public AudioSource ExplosionSound;
	
	// Use this for initialization
	void Start () 
	{
		LeftComponent = GetComponent<SpriteRenderer>();
		RightComponent = GetComponent<SpriteRenderer>();

		ExplosionSound = Explosion.GetComponent<AudioSource> ();

		MunitionText = MunitionGO.GetComponent<Text> ();

		Explosion = GameObject.Find("Explosion");

		UpOxygen = false;
		ShootRight = true;

		Exploded.enabled = false;

		exp = 0;
		dead = false;

		CanShoot = true;
		munition = 15;

		reloading = false;
	}

	// Update is called once per frame
	void Update () 
	{
		Organizar ();
		Munition ();

		if(Input.GetKey(KeyCode.RightArrow) && dead == false)
		{
			transform.position += new Vector3(velocity * Time.deltaTime,0,0);
			LeftComponent.sprite = Right;
			ShootRight = true;
		}
		if(Input.GetKey(KeyCode.LeftArrow) && dead == false)
		{
			transform.position -= new Vector3(velocity * Time.deltaTime,0,0);
			RightComponent.sprite = Left;
			ShootRight = false;
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += new Vector3(0,velocity * Time.deltaTime,0);
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.position -= new Vector3(0,velocity * Time.deltaTime,0);
		}
		if (Input.GetKeyDown (KeyCode.Space) && ShootRight == true && dead == false && CanShoot == true) 
		{
			Instantiate (projectileRight, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			munition -= 1;
		}
		if(Input.GetKeyDown(KeyCode.Space) && ShootRight == false && dead == false && CanShoot == true)
		{
			Instantiate(projectileLeft, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			munition -= 1;
		}
		if(transform.position.y > 3.20f)
		{
			transform.position = new Vector3(transform.position.x,3.21f,transform.position.z);
			UpOxygen = true;
		}
		if(transform.position.y < 3.20f)
		{
			UpOxygen = false;
		}
		if(transform.position.y < -3.35f)
		{
			transform.position = new Vector3(transform.position.x,-3.36f,transform.position.z);
		}
		if(transform.position.x < -8.21f)
		{
			transform.position = new Vector3(-8.20f,transform.position.y, transform.position.z);
		}
		if(transform.position.x > 8.17f)
		{
			transform.position = new Vector3(8.18f,transform.position.y, transform.position.z);
		}
		if (Oxygen.FinishOxygen == true) 
		{
			loseGame ();
		}
	}
	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Submarine") 
		{
			Exploded.enabled = true;
			Destroy (gameObject);
			loseGame ();
			ExplosionSound.enabled = true;
		}
		if (coll.gameObject.tag == "Shark") 
		{
			Exploded.enabled = true;
			Destroy (gameObject);
			loseGame ();
			ExplosionSound.enabled = true;
		}
		if (coll.gameObject.tag == "Whale") 
		{
			Exploded.enabled = true;
			Destroy (gameObject);
			loseGame ();
			ExplosionSound.enabled = true;
		}
		if (coll.gameObject.tag == "ProjectileEnemy") 
		{
			Exploded.enabled = true;
			Destroy (gameObject);
			loseGame ();
			ExplosionSound.enabled = true;
		}
		if (coll.gameObject.tag == "Explosion") 
		{
			Exploded.enabled = true;
			Destroy (gameObject);
			loseGame ();
			ExplosionSound.enabled = true;
		}
	}
	void Munition ()
	{
		if (reloading == true) 
		{
			MunitionText.text = "Reloading: ";
		} 
		if (munition > 0) 
		{
			MunitionText.text = "Munition:  "+ munition;
		}
		if (munition < 1) 
		{
			reloading = true;
			CanShoot = false;
			TimeReloadingMunition += 1 * Time.deltaTime;
		}
		if (TimeReloadingMunition > 5) 
		{
			munition = 15;
			CanShoot = true;
			TimeReloadingMunition -= 5;
		}
	}

	void loseGame ()
	{
		velocity = 0;
		dead = true;

		EnemyRight.Perdeu = true;

		if (exp > Record) 
		{
			Record = exp;
			PlayerPrefs.SetInt("PlayerRecord", Record);
		}
	}
	void Organizar ()
	{
		Points.text = "Points: " + exp;
		
		Position.y = transform.position.y;

		Explosion.transform.position = transform.position;
	}
}










