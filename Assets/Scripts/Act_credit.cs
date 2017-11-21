using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act_credit : MonoBehaviour {
	public float fWaittime = 4.8f;
	public float fFadetime = 3.0f;
	public Color FadeColor;
	public SpriteRenderer FadeImage;

	AudioSource CreditAudio;
	int SoundOpt;

	
	// Update is called once per frame
	void Start()
	{
		// 아이폰 빌드
		 Screen.SetResolution(Screen.width, (Screen.width * 16) / 9 , false);
		// 데스크탑 빌드
		//Screen.SetResolution(450, 800, false);
		Camera.main.fieldOfView = 60f;
		SoundOpt = PlayerPrefs.GetInt("Sound");
		CreditAudio = gameObject.GetComponent<AudioSource>();

		if (SoundOpt.Equals(0))
			CreditAudio.volume = 0f;
		else
			CreditAudio.volume = 1f;

		StartCoroutine(CreditAct());
	}

	IEnumerator Fadein_credit()
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

	IEnumerator Fadeout_toMenu()
	{
		float elapsedTime = 0f;

		yield return new WaitForSeconds (fWaittime);

		while(elapsedTime < fFadetime)
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime;
			FadeColor.a = Mathf.Clamp01(elapsedTime / fFadetime);
			CreditAudio.volume -= 0.01f;
			FadeImage.color = FadeColor;
		}
		Application.LoadLevelAsync(1);
	}
	IEnumerator CreditAct()
	{
		yield return StartCoroutine(Fadein_credit());
		while (true)
		{
			yield return null;
			if (Input.GetMouseButtonDown(0))
			{
					StartCoroutine(Fadeout_toMenu());
			}
		}
	}
}
