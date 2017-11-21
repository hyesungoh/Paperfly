using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit_rotate : MonoBehaviour {

	float fRotateSpeed = 10f;
	// Use this for initialization
	void Start () {
		fRotateSpeed = Random.Range(10f, 50f);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.localEulerAngles.x,
															gameObject.transform.localEulerAngles.y + fRotateSpeed * Time.deltaTime,
															gameObject.transform.localEulerAngles.z);
	}
}
