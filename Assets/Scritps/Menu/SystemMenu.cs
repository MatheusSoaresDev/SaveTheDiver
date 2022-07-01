using UnityEngine;
using System.Collections;

public class SystemMenu : MonoBehaviour 
{
	public Vector2 Play;
	public Vector2 Credits;
	public Vector2 Quit;

	public int menu;

	public AudioSource TransitionSound;
	public AudioSource EnterSound;
	
	// Use this for initialization
	void Start () 
	{
		Play = transform.position = new Vector2(3.27f,0.84f);
		Credits = transform.position = new Vector2(1.12f,-1.35f);
		Quit = transform.position = new Vector2(3.43f,-3.63f);

		transform.position = new Vector2(Play.x,Play.y);

		menu = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			menu += 1;
			TransitionSound.audio.Play();
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			menu -= 1;
			TransitionSound.audio.Play();
		}

		if(menu == 1)
		{
			transform.position = Play;
			if(Input.GetKeyDown(KeyCode.Space))
			{
				//EnterSound.audio.Play();
				Application.LoadLevel("Loading");
			}
		}
		if(menu == 2)
		{
			transform.position = Credits;
			if(Input.GetKeyDown(KeyCode.Space))
			{
				Application.LoadLevel("Credits");
				PlayerPrefs.SetString("UltimaCena", "Home");
			}
		}
		if(menu == 3)
		{
			transform.position = Quit;
			if(Input.GetKeyDown(KeyCode.Space))
			{
				Application.Quit();
			}
		}
		if(menu > 3)
		{
			menu = 1;
		}
		if(menu < 1)
		{
			menu = 3;
		}*/
	}
}
