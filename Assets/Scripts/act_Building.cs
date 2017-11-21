using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class act_Building : MonoBehaviour {

	
	// Update is called once per frame
	void FixedUpdate () {
		if (gameObject.transform.position.z < -60)
		{
			Destroy(gameObject);
		}
	}
}
