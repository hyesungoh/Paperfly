using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class act_menu : MonoBehaviour {

	public Animator paper, arm;
	public int nSceneNum = 1;
	public float fWaittime = 4.8f;
	public float fFadetime = 3.0f;
	public Color FadeColor;
	public SpriteRenderer FadeImage;

	public Ray ray;
	public RaycastHit rayhit;

	AudioSource MenuAudio;
	public AudioClip StartSound;
	public AudioClip Soundin;
	int SoundOpt;
	public GameObject Building_OFF;
	
	void Start()
	{
		// 아이폰 빌드
		 Screen.SetResolution(Screen.width, (Screen.width * 16) / 9 , false);
		// 데스크탑 빌드
		//Screen.SetResolution(450, 800, false);
		Camera.main.fieldOfView = 60f;
		MenuAudio = gameObject.GetComponent<AudioSource>();
		SoundOpt = PlayerPrefs.GetInt("Sound");

		if (SoundOpt.Equals(0))
		{
			Building_OFF.SetActive(true);
			MenuAudio.volume = 0f;
		}
		else
		{
			Building_OFF.SetActive(false);
			MenuAudio.volume = 1f;
		}

		StartCoroutine(MenuAct());
	}

	IEnumerator Fadein_menu()
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

	IEnumerator Fadeout_menu()
	{
		float elapsedTime = 0f;
		MenuAudio.PlayOneShot(StartSound);
		yield return new WaitForSeconds (fWaittime);

		while(elapsedTime < fFadetime)
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime;
			FadeColor.a = Mathf.Clamp01(elapsedTime / fFadetime);
			MenuAudio.volume -= 0.01f;
			FadeImage.color = FadeColor;
		}
		Application.LoadLevelAsync(nSceneNum);
	}

	IEnumerator Fadeout_toCredit()
	{
		float elapsedTime = 0f;

		yield return new WaitForSeconds (0f);

		while(elapsedTime < fFadetime)
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime;
			FadeColor.a = Mathf.Clamp01(elapsedTime / fFadetime);
			MenuAudio.volume -= 0.01f;
			FadeImage.color = FadeColor;
		}
		Application.LoadLevelAsync(3);
	}
	IEnumerator MenuAct()
	{
		yield return StartCoroutine(Fadein_menu());
		while (true)
		{
			yield return null;
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Input.GetMouseButtonDown(0))
			{
				if (Physics.Raycast(ray, out rayhit))
				{
					if (rayhit.transform.gameObject.name == "Credit")
					{
						StartCoroutine(Fadeout_toCredit());
					}
					else if (rayhit.transform.gameObject.name.Equals("Sound"))
					{
						if (SoundOpt.Equals(1))
						{
							MenuAudio.PlayOneShot(Soundin);
							Building_OFF.SetActive(true);
							PlayerPrefs.SetInt("Sound", 0);
							SoundOpt = 0;
							MenuAudio.volume = 0f;
						}
						else
						{
							MenuAudio.PlayOneShot(Soundin);
							Building_OFF.SetActive(false);
							PlayerPrefs.SetInt("Sound", 1);
							SoundOpt = 1;
							MenuAudio.volume = 1f;
						}
					}
				}
				else
				{ 
					paper.SetTrigger("goingame");
					arm.SetTrigger("goingame");
					StartCoroutine(Fadeout_menu());
				}
			}
		}
	}
}
