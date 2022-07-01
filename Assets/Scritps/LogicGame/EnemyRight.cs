using UnityEngine;
using System.Collections;

public class EnemyRight : MonoBehaviour 
{
	[Header("Transform Variables")]
	public Transform Submarine;
	public Transform Shark;
	public Transform Whale;

	[Header("Number Variables")]
	public int NumMin;
	public int NumMax;
	public float TimeSub;
	public float TimeShark;
	public float TimeBaleia;
	public int SortedNumber;
	public int SortedNumber2;
	public int SortedNumber3;
	public int TimeSortedMin;
	public int TimeSortedMax;
	public float CanStart;

	[Header("Boolean Variables")]
	public bool CanInstanceSubmarine;
	public bool CanInstanceShark;
	public bool CanInstanceWhale;
	public static bool Perdeu;

	// Use this for initialization
	void Start () 
	{
		CanInstanceSubmarine = true;
		CanInstanceShark = true;
		CanInstanceWhale = true;

		SortedNumber = (Random.Range (NumMin, NumMax));
		SortedNumber2 = (Random.Range (NumMin,NumMax));
		SortedNumber3 = (Random.Range(NumMin, NumMax));

		CanStart = 5;

		Perdeu = false;
	}
	// Update is called once per frame
	void Update () 
	{
		CanStart -= 1 * Time.deltaTime;
		if(CanStart < 1 && Perdeu == false)
		{
			SortedEnemy();
		}
	}
	void SortedEnemy ()
	{
		TimeSub -= 1 * Time.deltaTime;
		TimeShark -= 1 * Time.deltaTime;
		TimeBaleia -= 1 * Time.deltaTime;

		if(SortedNumber == 1 && CanInstanceSubmarine == true && TimeSub > 0)
		{
			Instantiate(Submarine, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			CanInstanceSubmarine = false;
			TimeSub = 5;
		}
		if(SortedNumber == 2 && CanInstanceShark == true && TimeShark > 0)
		{
			Instantiate(Shark, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			CanInstanceShark = false;
			TimeShark = 5;
		}
		if(SortedNumber == 3 && CanInstanceWhale == true && TimeBaleia > 0)
		{
			Instantiate(Whale, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			CanInstanceWhale = false;
			TimeBaleia = 5;
		}
		if(TimeSub < 0)
		{
			TimeSub += (Random.Range(TimeSortedMin,TimeSortedMax));
			CanInstanceSubmarine = true;
			SortedNumber = (Random.Range(NumMin,NumMax));
		}
		if(TimeShark < 0)
		{
			TimeShark += (Random.Range(TimeSortedMin,TimeSortedMax));
			CanInstanceShark = true;
			SortedNumber2 = (Random.Range(NumMin,NumMax));
		}
		if(TimeBaleia < 0)
		{
			TimeBaleia += (Random.Range(TimeSortedMin, TimeSortedMax));
			CanInstanceWhale = true;
			SortedNumber3 = (Random.Range(TimeSortedMin, TimeSortedMax));
		}
	}
}
