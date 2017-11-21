using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_car01 : MonoBehaviour {

	public float fSpeed = 2.0f;
	// Update is called once per frame
	void Update () {
		Anim_Move();
	}

	void Anim_Move()
	{
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - fSpeed * Time.deltaTime,
														 gameObject.transform.localPosition.y,
														 gameObject.transform.localPosition.z);

		if (gameObject.transform.localPosition.x < -6.0f)
		{
			gameObject.transform.localPosition = new Vector3(15.0f, gameObject.transform.localPosition.y,
																	gameObject.transform.localPosition.z);
		}
	}
}
