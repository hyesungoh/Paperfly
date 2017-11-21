using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public Animator OverPop;
	public GameObject mng, move;
	ingame_mng smng;
	dinamic_move smove;
	public GameObject[] tiles = new GameObject[12];
	move_tile[] stiles = new move_tile[12];

	AudioSource OverAudio;
	public AudioClip OverSound;
	bool SoundAct = false;
	int SoundOpt;
	void Start()
	{
		OverAudio = gameObject.GetComponent<AudioSource>();
		SoundOpt = PlayerPrefs.GetInt("Sound");
		if (SoundOpt.Equals(0))
			OverAudio.volume = 0f;
		else
			OverAudio.volume = 1f;
		smng = mng.GetComponent<ingame_mng>();
		smove = move.GetComponent<dinamic_move>();
		for (int i = 0; i < 12; i++)
			stiles[i] = tiles[i].GetComponent<move_tile>();
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Over")
		{
			if (SoundAct.Equals(false))
				StartCoroutine(SoundStart());
			smng.mng_isover = true;
			smove.move_isover = true;
			for (int i = 0; i < 12; i++)
				stiles[i].tile_isover = true;
			OverPop.SetTrigger("over");
		}
	}

	IEnumerator SoundStart()
	{
		OverAudio.PlayOneShot(OverSound);
		SoundAct = true;
		yield return null;
	}
}
