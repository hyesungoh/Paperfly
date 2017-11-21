using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_cloud_ingame : MonoBehaviour {

	public float fCloudSpeed = 0f;
	public float fCloudSpeed_s;
	public float fCloudSpeed_e;
	void Start()
	{
		fCloudSpeed = Random.Range(fCloudSpeed_s, fCloudSpeed_e);
	}

	void FixedUpdate () {
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
														 gameObject.transform.localPosition.y,
														 gameObject.transform.localPosition.z - fCloudSpeed * Time.deltaTime);
		
		if (gameObject.transform.localPosition.z < -180f)
		{
			gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
															 gameObject.transform.localPosition.y, 700);
			fCloudSpeed = Random.Range(fCloudSpeed_s, fCloudSpeed_e);
		}
	}
}
