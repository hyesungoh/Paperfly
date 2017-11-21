using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class act_intro : MonoBehaviour {

	public int nSceneNum = 1;
	public float fWaittime = 6.5f;
	public float fFadetime = 3.0f;
	public Color FadeColor;
	public SpriteRenderer FadeImage;

	void Start()
	{
		// 아이폰 빌드
		 Screen.SetResolution(Screen.width, (Screen.width * 16) / 9 , false);
		// 데스크탑 빌드
		//Screen.SetResolution(450, 800, false);
		Camera.main.fieldOfView = 60f;
		PlayerPrefs.SetInt("Sound", 1);
		StartCoroutine(FadeOut());
	}

	IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        
        yield return new WaitForSeconds (fWaittime);
        
		FadeImage.transform.localPosition = new Vector3(0f, 0f, 0f);

        while(elapsedTime < fFadetime)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            FadeColor.a = Mathf.Clamp01(elapsedTime / fFadetime);
            FadeImage.color = FadeColor;
        }
		Application.LoadLevelAsync(nSceneNum);
    }
}
