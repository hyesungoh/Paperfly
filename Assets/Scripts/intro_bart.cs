using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro_bart : MonoBehaviour {

	float fdt = 0.0f;
	bool isSoundplay = false;
	public AudioClip bart;
	AudioSource Dev;
	
	void Start () {
		Dev = gameObject.GetComponent<AudioSource>();
	}
	void Update () {
		if (isSoundplay.Equals(false))
		{
			fdt += Time.deltaTime;
			if (fdt > 7.05f)
			{
				isSoundplay = true;
				StartCoroutine(Bartin());
			}
		}
	}

	IEnumerator Bartin()
	{
		Dev.PlayOneShot(bart);
		yield return new WaitForSeconds(1.0f);
	}
}
