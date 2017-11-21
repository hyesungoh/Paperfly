using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_car_ingame : MonoBehaviour {

	public float fCarSpeed = 0f;
	public float fCarSpeed_s;
	public float fCarSpeed_e;
	void Start()
	{
		fCarSpeed = Random.Range(fCarSpeed_s, fCarSpeed_e);
	}

	void FixedUpdate () {
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
														 gameObject.transform.localPosition.y,
														 gameObject.transform.localPosition.z - fCarSpeed * Time.deltaTime);
		
		if (gameObject.transform.localPosition.z < -180f)
		{
			gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
															 gameObject.transform.localPosition.y, 580);
			fCarSpeed = Random.Range(fCarSpeed_s, fCarSpeed_e);
		}
	}
}
