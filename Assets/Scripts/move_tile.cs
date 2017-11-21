using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_tile : MonoBehaviour {


	public bool tile_isover = false;

	public float fRepositon = 540.0f;

	public GameObject Mng;
	ingame_mng MngScr;
	int Score;
	float Level;


	public GameObject[] HighBuildings = new GameObject[2];
	public GameObject[] MediumBuildings = new GameObject[3];
	public GameObject[] LowBuildings = new GameObject[2];
	GameObject Building;

	public GameObject tile0, tile1, tile2;

	int nPopu = 1;
	public int nPopuUp = 100, LBpop = 1, MBpop = 1, HBpop = 2;





	void Start()
	{
		MngScr = Mng.GetComponent<ingame_mng>();
	}

	void FixedUpdate () {
		if (tile_isover.Equals(false))
		{
			Poping();
			Move_tile();
			Remaining();
		}
	}

	void Poping()
	{
		Score = MngScr.nScore;
		Level = MngScr.fLevel;

		if (((Score / nPopuUp) + 1) > nPopu)
			nPopu += 1;
	}

	void Move_tile()
	{
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
														 gameObject.transform.localPosition.y,
														 gameObject.transform.localPosition.z - Level * Time.deltaTime);
	}

	void Remaining()
	{
		if (gameObject.transform.localPosition.z < -60)
		{
			int temp_Pos = -1;
			int tempSum = 0;
			int conSum = 0;
			gameObject.transform.localPosition = new Vector3(0f, 0f, fRepositon);

			while(true)
			{
				int temp = Random.Range(1, 4);
				int temp2 = Random.Range(0, 3);

				if (temp == 1)
					tempSum += LBpop;
				else if (temp == 2)
					tempSum += MBpop;
				else
					tempSum += HBpop;

				if (temp_Pos == temp2)
				{
					conSum += 1;
					continue;
				}

				if (nPopu < tempSum || conSum > 2)
					break;
				
				Build(temp, temp2);
				temp_Pos = temp2;
			}

		}
	}

	void Build(int kind, int Pos)
	{

		if (kind == 1)
			Building = GameObject.Instantiate(LowBuildings[Random.Range(0,2)]);
		else if (kind == 2)
			Building = GameObject.Instantiate(MediumBuildings[Random.Range(0,3)]);
		else
			Building = GameObject.Instantiate(HighBuildings[Random.Range(0,2)]);
		
		if (Pos == 0)
			Building.transform.parent = tile0.transform;
		else if (Pos == 1)
			Building.transform.parent = tile1.transform;
		else
			Building.transform.parent = tile2.transform;

		Building.transform.localPosition = new Vector3(0f, 0f, 0f);
		Building.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
	}
}
