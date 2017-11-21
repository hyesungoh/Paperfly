using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_cloud : MonoBehaviour {

	public float fCloudSpeed = 2.0f;
	public float fChangePoint = 0.0f;
	public float fChangedPoint = 0.0f;

	// Update is called once per frame
	void Update () {
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + fCloudSpeed * Time.deltaTime,
														 gameObject.transform.localPosition.y,
														 gameObject.transform.localPosition.z);
		
		if (gameObject.transform.localPosition.x > fChangePoint)
			gameObject.transform.localPosition = new Vector3(fChangedPoint, gameObject.transform.localPosition.y,
																 gameObject.transform.localPosition.z);
	}
}
