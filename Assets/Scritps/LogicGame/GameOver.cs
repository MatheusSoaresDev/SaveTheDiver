using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour 
{
	public static EnemyRight instance;

	public Text gameover;

	public float LoseTime;
	// Use this for initialization
	void Start () 
	{
		gameover = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (EnemyRight.Perdeu == true) 
		{
			LoseTime += 1 * Time.deltaTime;
		}
		if (LoseTime > 3) 
		{
			gameover.text = "GameOver";
		}
		if (LoseTime > 8) 
		{
			Application.LoadLevel("GameOver");
		}
	}
}
