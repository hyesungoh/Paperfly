using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class act_over : MonoBehaviour {

	public bool isOver = false;
	// Use this for initialization
	void Start () {
		StartCoroutine(isOvered());
	}

	IEnumerator isOvered()
	{
		while (true)
		{
			yield return null;
			if (isOver == true)
			{
				StartCoroutine(OverAction());
			}
		}
	}

	IEnumerator OverAction()
	{

				while (gameObject.transform.localPosition.x > 0)
				{
					yield return null;
					gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + 1f,
																	 gameObject.transform.localPosition.y,
																	 gameObject.transform.localPosition.z);
				}
	}
}
