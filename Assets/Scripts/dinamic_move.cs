using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinamic_move : MonoBehaviour {
	public bool move_isover = false;
	
	public GameObject PaperFly;
	public float fSpeed = 0.5f;
	float fDiffX, fDiffY;
	float fDownX, fDownY;
	
	void Update () 
	{
		if (move_isover.Equals(false))
			Moving();
	}

	void Moving()
	{
		if (Input.GetMouseButtonDown(0))
		{
			fDownX = Input.mousePosition.x;
			fDownY = Input.mousePosition.y;
		}
		else if (Input.GetMouseButton(0))
		{
			fDiffX = Input.mousePosition.x - fDownX;
			fDiffY = Input.mousePosition.y - fDownY;

			gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + fDiffX * Time.deltaTime * fSpeed,
															 gameObject.transform.localPosition.y + fDiffY * Time.deltaTime * fSpeed,
															 gameObject.transform.localPosition.z);
			
			PaperFly.transform.localEulerAngles = new Vector3(PaperFly.transform.localRotation.x + fDiffY * 0.1f, -180f,
															  PaperFly.transform.localRotation.z + (fDiffX + fDiffY) * 0.1f);

			gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.localRotation.x,
																gameObject.transform.localRotation.y,
																gameObject.transform.localRotation.z + -1f * (fDiffX + fDiffY) * 0.1f);
		}
	}
}
