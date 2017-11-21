using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act_ingame : MonoBehaviour {
	public float fWaittime = 4.8f;
	public float fFadetime = 3.0f;
	public Color FadeColor;
	public SpriteRenderer FadeImage;

	AudioSource IngameAudio;
	int SoundOpt;
	void Start () {
		IngameAudio = gameObject.GetComponent<AudioSource>();
		SoundOpt = PlayerPrefs.GetInt("Sound");
		if (SoundOpt.Equals(0))
			IngameAudio.volume = 0f;
		else
			IngameAudio.volume = 1f;
		StartCoroutine(Fadein_ingame());
	}
	
	IEnumerator Fadein_ingame()
	{
		float elapsedTime = 0f;
        
        while(elapsedTime < fFadetime)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            
			FadeColor.a = 1.0f - Mathf.Clamp01(elapsedTime / fFadetime);
            FadeImage.color = FadeColor;
        }
	}

	public IEnumerator Fadeout_toRestart()
	{
		float elapsedTime = 0f;

		yield return new WaitForSeconds (fWaittime);

		while(elapsedTime < fFadetime)
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime;
			FadeColor.a = Mathf.Clamp01(elapsedTime / fFadetime);
			IngameAudio.volume -= 0.01f;
			FadeImage.color = FadeColor;
		}
		Application.LoadLevelAsync(2);
	}

	public IEnumerator Fadeout_toMenu()
	{
		float elapsedTime = 0f;

		yield return new WaitForSeconds (fWaittime);

		while(elapsedTime < fFadetime)
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime;
			FadeColor.a = Mathf.Clamp01(elapsedTime / fFadetime);
			IngameAudio.volume -= 0.01f;
			FadeImage.color = FadeColor;
		}
		Application.LoadLevelAsync(1);
	}
}
